using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using ShaftGearPlugin.Model;
using ShaftGearPlugin.Wrapper;

namespace ShaftGearPlugin.LoadTest
{
    /// <summary>
    /// Класс нагрузочного теста.
    /// </summary>
    class LoadTestProgram
    {
        /// <summary>
        /// Главный метод класса для нагрузочного тестирования.
        /// </summary>
        private static void Main()
        {
            var shaftGearBuilder = new ShaftGearBuilder();
            var shaftGearParameters = new ShaftGearParameters();
            var streamWriter = new StreamWriter($"LoadTestLog.txt", true);


            long modelCounter = 0;
            shaftGearBuilder.BuildDetail(shaftGearParameters);

            var myProcess = Process.GetProcessesByName("kStudy").FirstOrDefault();

            do
            {
                if (!myProcess.HasExited)
                {
                    shaftGearBuilder.BuildDetail(shaftGearParameters); ;
                    modelCounter++;
                    myProcess.Refresh();
                    Console.WriteLine();
                    Console.WriteLine($"{myProcess} -");
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine($"  Details Count        : {modelCounter}");
                    Console.WriteLine($"  Physical Memory Usage     : {myProcess.WorkingSet64}");
                    Console.WriteLine($"  User Processor Time       : {myProcess.UserProcessorTime}");
                    streamWriter.WriteLine($"{modelCounter} {myProcess.WorkingSet64} {myProcess.UserProcessorTime}");
                    streamWriter.Flush();

                    Console.WriteLine(myProcess.Responding ? "Status = Running" : "Status = Not Responding");
                }
            }
            while (modelCounter != 50);
        }
    }
}
