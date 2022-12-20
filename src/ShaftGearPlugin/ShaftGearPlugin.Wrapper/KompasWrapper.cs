using System;
using System.Runtime.InteropServices;
using Kompas6API5;
using Kompas6Constants3D;

namespace ShaftGearPlugin.Wrapper
{
    /// <summary>
    /// Класс для запуска библиотеки в Компас-3D.
    /// </summary>
    class KompasWrapper
    {
        /// <summary>
        /// Объект Компас API.
        /// </summary>
        private KompasObject _kompas;

        /// <summary>
        /// Деталь.
        /// </summary>
        private ksPart _part;

        /// <summary>
        /// Документ-модель.
        /// </summary>
        private ksDocument3D _document;

        /// <summary>
        /// Коллекция эскизов на смещенных плоскостях.
        /// </summary>
        private ksEntityCollection _offsetSketchCollection;

        /// <summary>
        /// Запуск Компас-3D.
        /// </summary>
        public void StartKompas()
        {
            try
            {
                if (_kompas != null)
                {
                    _kompas.Visible = true;
                    _kompas.ActivateControllerAPI();
                }
                if (_kompas != null) return;
                var kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
                _kompas = (KompasObject)Activator.CreateInstance(kompasType);
                StartKompas();
                if (_kompas == null)
                {
                    throw new Exception("Не удается открыть Компас-3D.");
                }
            }
            catch (COMException)
            {
                _kompas = null;
                StartKompas();
            }
        }

        /// <summary>
        /// Создание документа в Компас-3D.
        /// </summary>
        public void CreateDocument()
        {
            try
            {
                _document = _kompas.Document3D();
                _document.Create();
                _document = _kompas.ActiveDocument3D();
            }
            catch
            {
                throw new ArgumentException("Не удается построить деталь");
            }
        }

        /// <summary>
        /// Установка свойств детали.
        /// </summary>
        public void SetDetailProperties()
        {
            _part = _document.GetPart((short)Part_Type.pTop_Part);
            _part.name = "Вал-шестерня";
            _part.SetAdvancedColor(4737096, 0.5, 0.6,
                0.8, 0.8, 1, 0.5);
            _part.Update();
            _offsetSketchCollection = _part.EntityCollection((short)Obj3dType.o3d_sketch);
        }

        /// <summary>
        /// Создания скругления.
        /// </summary>
        /// <param name="edgeCoordinatesArray">Массив координат ребер,
        /// где будет скругление.</param>
        /// <param name="radius">Радиус скругления.</param>
        public void CreateFillet(double[,] edgeCoordinatesArray, double radius)
        {
            ksEntity sketch = _part.NewEntity((short)Obj3dType.o3d_fillet);
            ksFilletDefinition definition = sketch.GetDefinition();
            definition.radius = radius;
            definition.tangent = false;
            ksEntityCollection array = definition.array();
            for (var i = 0; i < edgeCoordinatesArray.GetLength(0); i++)
            {
                ksEntityCollection collection =
                    _part.EntityCollection((short)Obj3dType.o3d_edge);
                collection.SelectByPoint(edgeCoordinatesArray[i, 0],
                    edgeCoordinatesArray[i, 1],
                    edgeCoordinatesArray[i, 2]);
                ksEntity edge = collection.Last();
                array.Add(edge);
            }
            sketch.Create();
        }

        /// <summary>
        /// Создание смещенной плоскости.
        /// </summary>
        /// <param name="offset">Смещение плоскости относительно XOY.</param>
        public void CreateOffsetPlane(double offset)
        {
            ksEntity sketch = _part.NewEntity((short)Obj3dType.o3d_planeOffset);
            ksEntity basePlane = _part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            ksPlaneOffsetDefinition offsetDefinition = sketch.GetDefinition();
            offsetDefinition.offset = offset;
            offsetDefinition.direction = true;
            sketch.hidden = true;
            offsetDefinition.SetPlane(basePlane);
            sketch.Create();
        }

        /// <summary>
        /// Создание ломаной.
        /// </summary>
        /// <param name="points">Координаты </param>
        /// <param name="offset">Смещение плоскости, где находится эскиз.</param>
        public void CreatePolyline(double[,] points, double offset)
        {
            ksEntity sketch = _part.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition definition = sketch.GetDefinition();
            ksEntityCollection collection =
                _part.EntityCollection((short)Obj3dType.o3d_planeOffset);
            collection.SelectByPoint(0, 0, offset);
            ksEntity plane = collection.First();
            definition.SetPlane(plane);
            sketch.Create();
            ksDocument2D sketchEdit = definition.BeginEdit();
            var angle = 0;
            while (angle < 360)
            {
                // Создание и поворот кривой 8 раз относительно начала координат.

                points = MatricesWorking.RotatePoint(points, angle);
                for (var i = 0; i < points.GetLength(0) - 1; i++)
                {
                    sketchEdit.ksLineSeg(points[i, 0], points[i, 1],
                        points[i + 1, 0], points[i + 1, 1], 1);
                }

                angle += 45;
            }

            definition.EndEdit();
            _offsetSketchCollection.Add(sketch);
        }

        /// <summary>
        /// Создание кривой.
        /// </summary>
        /// <param name="points">Координаты точек.</param>
        /// <param name="arc">Параметры дуги.</param>
        /// <returns>Сформированный эскиз.</returns>
        public ksEntity CreateCurve(double[,] points, double[] arc)
        {
            ksEntity sketch = _part.NewEntity((short)Obj3dType.o3d_sketch);
            ksEntity plane = _part.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ);
            ksSketchDefinition definition = sketch.GetDefinition();
            definition.SetPlane(plane);
            sketch.Create();
            ksDocument2D sketchEdit = definition.BeginEdit();
            sketchEdit.ksArcByPoint(arc[0], arc[1], arc[2],
                arc[3], arc[4], arc[5], arc[6], (short)arc[7], 1);
            for (var i = 0; i < points.GetLength(0) - 1; i++)
            {
                sketchEdit.ksLineSeg(points[i, 0], points[i, 1],
                    points[i + 1, 0], points[i + 1, 1], 1);
            }

            // Ось вращения.
            sketchEdit.ksLineSeg(points[4, 0], points[4, 1],
                points[5, 0], points[5, 1], 3);
            definition.EndEdit();
            return sketch;
        }

        /// <summary>
        /// Выдавливание по сечениям смещенных эскизов.
        /// </summary>
        public void ExtrudeBySections()
        {
            ksEntity entity = _part.NewEntity((short)Obj3dType.o3d_bossLoft);
            ksBossLoftDefinition definition = entity.GetDefinition();
            ksEntityCollection collection = definition.Sketchs();
            collection.Add(_offsetSketchCollection.GetByIndex(2));
            collection.Add(_offsetSketchCollection.GetByIndex(1));
            collection.Add(_offsetSketchCollection.GetByIndex(0));
            entity.Create();
        }

        /// <summary>
        /// Выдавливание вращением.
        /// </summary>
        /// <param name="sketch">Эскиз.</param>
        public void ExtrudeByRotation(ksEntity sketch)
        {
            ksEntity entity = _part.NewEntity((short)Obj3dType.o3d_bossRotated);
            ksBossRotatedDefinition definition = entity.GetDefinition();
            definition.directionType = (short)Direction_Type.dtNormal;
            definition.SetSketch(sketch);
            definition.SetSideParam(true, 360);
            entity.Create();
        }
    }
}