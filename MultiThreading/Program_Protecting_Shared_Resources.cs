using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    /// <summary>
    /// Protecting shared resources from concurrent access in multithreading
    /// </summary>
    class Program_Protecting_Shared_Resources
    {
        static int Total;
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread has started.");
            Stopwatch stopwatch = Stopwatch.StartNew();

            ////Non threadded execution
            //AddOneMillion();
            //AddOneMillion();
            //AddOneMillion();

            //using thread on non protected shared resource
            Thread thread1 = new Thread(AddOneMillion);
            Thread thread2 = new Thread(AddOneMillion);
            Thread thread3 = new Thread(AddOneMillion);

            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();
            Console.WriteLine($"Total is {Total}");

            stopwatch.Stop();
            Console.WriteLine($"Total Execution Time: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Main thread completed.");
            Console.ReadKey();
        }

        static object _lock = new object();
        public static void AddOneMillion()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                //Total++;//++ is not a thread safe operator

                //Protecting shared resource using Interlocked.Increment
                //Interlocked.Increment(ref Total);

                //Protecting shared resource using lock
                lock (_lock)
                {
                    Total++;
                }
            }
        }
    }
}
