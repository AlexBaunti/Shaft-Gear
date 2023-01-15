using ShaftGearPlugin.Model;

namespace ShaftGearPlugin.Wrapper
{
    /// <summary>
    /// Класс, отвечающий за построение вала-шестерни.
    /// </summary>
    public class ShaftGearBuilder
    {
        /// <summary>
        /// Связь с Компас-3D.
        /// </summary>
        private readonly KompasWrapper _wrapper = new KompasWrapper();

        /// <summary>
        /// Построение детали по заданным параметрам.
        /// </summary>
        /// <param name="parameters">Объект заданных параметров шестерни.</param>
        public void BuildDetail(ShaftGearParameters parameters)
        {
            _wrapper.StartKompas();
            _wrapper.CreateDocument();
            _wrapper.SetDetailProperties();
            var gearWidth =
                parameters.GetParameterValue(ShaftGearParametersType.GearWidth);
            var gearDiameter =
                parameters.GetParameterValue(ShaftGearParametersType.GearDiameter);
            var connectorDiameter =
                parameters.GetParameterValue(ShaftGearParametersType.ConnectorDiameter);
            var baseDiameter =
                parameters.GetParameterValue(ShaftGearParametersType.BaseDiameter);
            var tipDiameter =
                parameters.GetParameterValue(ShaftGearParametersType.TipDiameter);
            var tipLength =
                parameters.GetParameterValue(ShaftGearParametersType.TipLength);
            var rotationAngle =
                parameters.GetParameterValue(ShaftGearParametersType.RotationAngle);
            BuildGear(gearDiameter, gearWidth, rotationAngle);
            BuildShaft(connectorDiameter, baseDiameter,
                tipDiameter, tipLength);
        }

        /// <summary>
        /// Построение шестерни.
        /// </summary>
        /// <param name="gearDiameter">Диаметр шестерни.</param>
        /// <param name="gearWidth">Ширина шестерни.</param>
        private void BuildGear(double gearDiameter, double gearWidth, double rotationAngle)
        {
            // Построение смещенных плоскостей.

            _wrapper.CreateOffsetPlane(0);
            _wrapper.CreateOffsetPlane(gearWidth / 2);
            _wrapper.CreateOffsetPlane(gearWidth);

            // Координаты точек зубца шестерни.
            // 0 элемент - координата по X;
            // 1 элемент - координата по Y;

            double[,] points =
            {
                { -8.096194, 19.545942 },
                { -7, 21},
                { -2, gearDiameter/2 },
                { 2, gearDiameter/2 },
                { 7, 21  },
                { 8.096194, 19.545942 }
            };

            // Построение маленького эскиза шестерни.
            _wrapper.CreatePolyline(points, gearWidth);

            // Построение среднего эскиза шестерни. 

            points = MatricesWorking.RotatePoint(points, rotationAngle / 2.4);
            points = MatricesWorking.ChangeScale(points, 1.4);
            _wrapper.CreatePolyline(points, gearWidth / 2);

            // Построение большего эскиза шестерни.

            points = MatricesWorking.RotatePoint(points, rotationAngle / 2);
            points = MatricesWorking.ChangeScale(points, 1.4);
            _wrapper.CreatePolyline(points, 0);
            _wrapper.ExtrudeBySections();
        }

        /// <summary>
        /// Построение вала.
        /// </summary>
        /// <param name="connectorDiameter">Диаметр соединителя.</param>
        /// <param name="baseDiameter">Диаметр основания вала.</param>
        /// <param name="tipDiameter">Диаметр вращательного цилиндра вала.</param>
        /// <param name="tipLength">Длина вращательного цилиндра вала.</param>
        private void BuildShaft(double connectorDiameter, double baseDiameter,
            double tipDiameter, double tipLength)
        {
            // Создания тела вала.

            // Координаты точек ломаной.
            // 0 элемент - координата по X;
            // 1 элемент - координата по Y;
            double[,] points =
            {
                { 83, 36 },
                { 131, 36 },
                { 131, tipDiameter/2 },
                { 131 + tipLength, tipDiameter/2 },
                { 131 + tipLength, 0 },
                { 0, 0 },
                { 0, connectorDiameter/2 },
                { 5, connectorDiameter/2 },
                { 5, baseDiameter/2 },
                { 51, baseDiameter/2 },
                { 51, 38 },
                { 61.411168, 38 }
            };

            // Параметры дуги.
            // 0 элемент - координата центра по X;
            // 1 элемент - координата центра по Y;
            // 2 элемент - радиус дуги;
            // 3 элемент - координата начала по X;
            // 4 элемент - координата центра по Y;
            // 5 элемент - координата конца по X;
            // 6 элемент - координата конца по Y;
            // 7 элемент - направление дуги.
            double[] arc =
            {
                72.37768, 38.857677, 11,
                61.411168, 38,
                83, 36, 1
            };
            var entitySketch = _wrapper.CreateCurve(points, arc);
            _wrapper.ExtrudeByRotation(entitySketch);

            // Скругление ребер вала.

            // Массив первых координат ребер для скругления.
            // 0 элемент - координата по X;
            // 1 элемент - координата по Y;
            // 2 элемент - координата по Z.
            double[,] firstEdgeCoordinates =
            {
                { 0, 36, -83 },
                { 0, 36, -131 },
                { 0, tipDiameter / 2, -131 },
                { 0, tipDiameter / 2, -131 - tipLength },
                { 0, baseDiameter / 2, 51 },
                { 0, 38, 61.411168 }
            };

            // Первый радиус для скругления.
            const int firstFilletRadius = 1;
            _wrapper.CreateFillet(firstEdgeCoordinates, firstFilletRadius);

            // Массив вторых координат ребер для скругления.
            // 0 элемент - координата по X;
            // 1 элемент - координата по Y;
            // 2 элемент - координата по Z.
            double[,] secondEdgeCoordinates =
            {
                { 0, connectorDiameter / 2, -5 },
                { 0, baseDiameter / 2, -51 },
                { 0, 38, -51 }
            };
            // Второй радиус для скругления.
            const double secondFilletRadius = 0.5;
            _wrapper.CreateFillet(secondEdgeCoordinates, secondFilletRadius);
        }
    }
}