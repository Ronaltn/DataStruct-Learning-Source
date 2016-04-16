using System;
using System.Collections.Generic;
using System.Text;

namespace StepMultiply
{
    class Program
    {
        static int fact(int num)
        {
            if (num == 0)
                return 1;
            else
                return num * fact(num - 1);
        }

        static void Main(string[] args)
        {
            Console.Write("Please Input Num : ");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine(fact(i));
        }
    }
}
