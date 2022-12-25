using System.IO;
using System.Diagnostics;
using Microsoft.VisualBasic.Devices;
using ShaftGearPlugin.Model;
using ShaftGearPlugin.Wrapper;


namespace ShaftGearPlugin.StressTest
{
    /// <summary>
    /// Класс стресс теста.
    /// </summary>
    class StressTestProgram
    {
        /// <summary>
        /// Главный метод класса для загрузочного тестирования.
        /// </summary>
        private static void Main()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var shaftGearBuilder = new ShaftGearBuilder();
            var shaftGearParameters = new ShaftGearParameters();
            var streamWriter = new StreamWriter($"StressTest.txt", true);
            var modelCounter = 0;
            var computerInfo = new ComputerInfo();
            ulong usedMemory = 0;
            while (usedMemory * 0.96 <= computerInfo.TotalPhysicalMemory)
            {
                shaftGearBuilder.BuildDetail(shaftGearParameters);
                usedMemory = (computerInfo.TotalPhysicalMemory - computerInfo.AvailablePhysicalMemory);
                streamWriter.WriteLine(
                    $"{++modelCounter}\t{stopWatch.Elapsed:hh\\:mm\\:ss}\t{usedMemory}");
                streamWriter.Flush();
            }
            stopWatch.Stop();
            streamWriter.WriteLine("END");
            streamWriter.Close();
            streamWriter.Dispose();
        }
    }
}
