using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiThreading
{
    public delegate void CallBackDelegate(int num);
    class RetrievingDataUsingCallback
    {
        private readonly int _num;
        private readonly CallBackDelegate _callBackDelegate;
        public RetrievingDataUsingCallback(int num, CallBackDelegate callBackDelegate)
        {
            _num = num;
            _callBackDelegate = callBackDelegate;
        }

        public void PrintNumbers()
        {
            int _sum = 0;
            for (int i = 1; i <= _num; i++)
            {
                _sum += i;
                Console.WriteLine($"From child thread. Print : {i}");
            }
            Callback(_sum);
        }

        public void Callback(int sum)
        {
            if (_callBackDelegate != null)
                _callBackDelegate(sum);
        }
    }
}
