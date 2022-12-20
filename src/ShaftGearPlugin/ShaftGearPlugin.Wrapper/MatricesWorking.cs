using System;

namespace ShaftGearPlugin.Wrapper
{
    /// <summary>
    /// Сервисный класс для работы с матрицами координат.
    /// </summary>
    class MatricesWorking
    {
        /// <summary>
        /// Повернуть матрицу координат вокруг центра координат.
        /// </summary>
        /// <param name="points">Матрица координат.</param>
        /// <param name="angle">Угол поворота матрицы.</param>
        /// <returns></returns>
        public static double[,] RotatePoint(double[,] points, double angle)
        {
            // Преобразование градусов в радианы.
            angle = angle * Math.PI / 180;
            double[,] rotateMatrix =
            {
                { Math.Cos(angle), Math.Sin(angle) },
                { -Math.Sin(angle), Math.Cos(angle) }
            };
            var resultMatrix = MultiplyMatrices(points, rotateMatrix);
            return resultMatrix;
        }

        /// <summary>
        /// Изменить масштаб координат матрицы.
        /// </summary>
        /// <param name="points">Матрица координат.</param>
        /// <param name="scale">Масштаб.</param>
        /// <returns>Матрицу с измененным масштабом.</returns>
        public static double[,] ChangeScale(double[,] points, double scale)
        {
            double[,] rotateMatrix =
            {
                { scale, 0 },
                { 0, scale }
            };
            var resultMatrix = MultiplyMatrices(points, rotateMatrix);
            return resultMatrix;
        }

        /// <summary>
        /// Умножение матриц.
        /// </summary>
        /// <param name="firstMatrix">Первая матрица.</param>
        /// <param name="secondMatrix">Вторая матрица.</param>
        /// <returns>Результирующая матрица.</returns>
        private static double[,] MultiplyMatrices(double[,] firstMatrix,
            double[,] secondMatrix)
        {
            var resultMatrix =
                new double[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
            for (var i = 0; i < firstMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < secondMatrix.GetLength(1); j++)
                {
                    resultMatrix[i, j] = 0;
                    for (var k = 0; k < firstMatrix.GetLength(1); k++)
                    {
                        resultMatrix[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                    }
                }
            }
            return resultMatrix;
        }
    }
}