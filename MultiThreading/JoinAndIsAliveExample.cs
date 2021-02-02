using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    class JoinAndIsAliveExample
    {
        public static void Thread1Function()
        {
            Console.WriteLine("Thread1 function started.");
            Console.WriteLine("Thread1 function executing...");
            Thread.Sleep(5000);
            Console.WriteLine("Thread1 function ended.");
        }

        public static void Thread2Function()
        {
            Console.WriteLine("Thread2 function started.");
            Console.WriteLine("Thread2 function executing...");
            Thread.Sleep(2000);
            Console.WriteLine("Thread2 function ended.");
        }
    }
}
