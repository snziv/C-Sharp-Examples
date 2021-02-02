using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    public class DeadlockExample
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread has started.Example : Deadlock condition.");
            Console.WriteLine($"No. of processor : {Environment.ProcessorCount}.");
            Stopwatch stopwatch = Stopwatch.StartNew();

            Account accountA = new Account(101, 17000);
            Account accountB = new Account(102, 5000);

            AccountManager accountManagerA = new AccountManager(accountA, accountB, 1000);
            Thread threadA = new Thread(accountManagerA.Transfer);
            threadA.Name = "Thread A";

            AccountManager accountManagerB = new AccountManager(accountB, accountA, 3000);
            Thread threadB = new Thread(accountManagerB.Transfer);
            threadB.Name = "Thread B";

            threadA.Start();
            threadB.Start();

            threadA.Join();
            threadB.Join();

            stopwatch.Stop();
            Console.WriteLine($"Total Execution Time: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Main thread completed.");
            Console.ReadKey();
        }

        public class Account
        {
            public int Id { get; }
            public double Balance { get; set; }

            public Account(int id, long balance)
            {
                Id = id;
                Balance = balance;
            }

            public void Withdraw(double amount) => Balance -= amount;
            public void Deposite(double amount) => Balance += amount;
        }

        public class AccountManager
        {
            public Account From { get; set; }
            public Account To { get; set; }
            public double AmountToTransfer { get; set; }

            public AccountManager(Account from, Account to, double amount)
            {
                From = from;
                To = to;
                AmountToTransfer = amount;
            }

            public void Transfer()
            {
                //Console.WriteLine($"{Thread.CurrentThread.Name} is trying to acquire lock on {From.Id}.");
                //lock (From)
                //{
                //    Console.WriteLine($"{Thread.CurrentThread.Name} has acquired lock on {From.Id}.");
                //    Console.WriteLine($"{Thread.CurrentThread.Name} suspended for 1 sec.");

                //    Thread.Sleep(1000);

                //    Console.WriteLine($"{Thread.CurrentThread.Name} is back in action and trying to acquire lock on {To.Id}.");

                //    lock (To)
                //    {
                //        // this will not be printed due to dealock
                //        Console.WriteLine($"{Thread.CurrentThread.Name} has acquired lock on {To.Id}.");

                //        From.Withdraw(AmountToTransfer);
                //        To.Deposite(AmountToTransfer);
                //    }
                //}

                //how to solve deadlock
                //by allowing lock on objects in specific order we can avoid deadlock cases
                object _lock1, _lock2;
                if (From.Id < To.Id)
                {
                    _lock1 = From;_lock2 = To;
                }
                else
                {
                    _lock1 = To; _lock2 = From;
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{Thread.CurrentThread.Name} is trying to acquire lock on {((Account)_lock1).Id}.");

                lock (_lock1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Thread.CurrentThread.Name} has acquired lock on {((Account)_lock1).Id}.");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{Thread.CurrentThread.Name} suspended for 1 sec.");
                    Thread.Sleep(1000);

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"{Thread.CurrentThread.Name} is trying to acquire lock on {((Account)_lock2).Id}.");
                    lock (_lock2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{Thread.CurrentThread.Name} has acquired lock on {((Account)_lock2).Id}.");

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        From.Withdraw(AmountToTransfer);
                        To.Deposite(AmountToTransfer);
                        
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{Thread.CurrentThread.Name} transfered amount {AmountToTransfer} from " +
                            $"{From.Id} to {To.Id}.");
                        Console.ResetColor();
                    }
                }
            }
        }
    }
}
