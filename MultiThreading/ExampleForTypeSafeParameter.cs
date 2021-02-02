using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiThreading
{
    public class ExampleForTypeSafeParameter
    {
        private readonly int target;

        public ExampleForTypeSafeParameter(int target)
        {
            this.target = target;
        }

        public void Print()
        {
            for (int i = 1; i <= target; i++)
                Console.WriteLine(i);
        }
    }
}
