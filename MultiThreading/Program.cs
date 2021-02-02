using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine($"Main thread started.");
            Program program = new Program();
            //without threading
            //program.PrintName();
            //program.PrintNumber();

            /*
            //with threading
            Thread workerPrintNameThread = new Thread(program.PrintName);
            //Thread workerPrintNameThread1 = new Thread(new ThreadStart(program.PrintName));
            //Thread workerPrintNameThread2 = new Thread(delegate () { program.PrintName(); });
            //Thread workerPrintNameThread3 = new Thread(() => program.PrintName());
            workerPrintNameThread.Start();
            program.PrintNumber();
            */

            /*
            //passing object as parameter not type safe            
            Thread workerPrintFromNumberThread = new Thread(new ParameterizedThreadStart(program.PrintFromNumber)); // new Thread(program.PrintFromNumber);
            Console.WriteLine("Enter number....");            
            object num = Console.ReadLine(); // int num = Convert.ToInt32(Console.ReadLine());
            workerPrintFromNumberThread.Start(num);
            */

            /*
            //passing type safe parameter
            ExampleForTypeSafeParameter exampleForTypeSafeParameter = new ExampleForTypeSafeParameter(8);
            Thread typeSafeExampeThread = new Thread(exampleForTypeSafeParameter.Print);
            typeSafeExampeThread.Start();
            */

            /*
            //Retrieving data from Thread function using callback method
            RetrievingDataUsingCallback usingCalllback = new RetrievingDataUsingCallback(5, CallbackPrintSum);
            Thread threadUsingCallback = new Thread(usingCalllback.PrintNumbers);
            threadUsingCallback.Start();
            */

            //Significance of Thread Join and Thread IsAlive functions
            JoinAndIsAliveExample joinAndIsAliveExample = new JoinAndIsAliveExample();
            Thread thread1 = new Thread(JoinAndIsAliveExample.Thread1Function);
            thread1.Start();
            Thread thread2 = new Thread(JoinAndIsAliveExample.Thread2Function);
            thread2.Start();

            //thread1.Join();
            //Console.WriteLine("Thread1 function completed.");

            if (thread1.Join(1000))
            {
                Console.WriteLine("Thread1 completed.");
            }
            else
            {
                Console.WriteLine("Thread1 has not completed in 1 sec. Thread1 is still running...");
            }

            thread2.Join();
            Console.WriteLine("Thread2 completed.");

            while (thread1.IsAlive)
            {
                Console.WriteLine($"Thread1 is still running...");
                Thread.Sleep(500);
            }
            Console.WriteLine("Thread1 completed.");

            stopwatch.Stop();
            Console.WriteLine($"Total Execution Time: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Main thread completed.");
            Console.ReadKey();
        }

        public void PrintName()
        {
            List<string> list = new List<string> {"John", "David"
            , "Jay", "Ragav", "Dora"};
            foreach (string name in list)
            {
                Thread.Sleep(1000);
                Console.WriteLine(name);
            }
        }
        public void PrintNumber()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            foreach (int number in numbers)
            {
                Thread.Sleep(500);
                Console.WriteLine(number);
            }
        }

        public void PrintFromNumber(object value)
        {
            if (int.TryParse(value.ToString(), out int num))
            {
                List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
                foreach (int number in numbers)
                {
                    Thread.Sleep(500);
                    Console.WriteLine(number + num);
                }
            }
        }

        public static void CallbackPrintSum(int sum)
        {
            Console.WriteLine($"From main thread. Sum is {sum}");
        }
    }
}
