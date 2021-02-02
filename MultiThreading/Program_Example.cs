using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MultiThreading
{
    class Program_Example
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread has started.");
            Stopwatch stopwatch = Stopwatch.StartNew();



            stopwatch.Stop();
            Console.WriteLine($"Total Execution Time: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Main thread completed.");
            Console.ReadKey();
        }
    }
}
