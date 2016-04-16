using System;
using System.Collections.Generic;
using System.Text;

namespace FibNum
{
    class Program
    {
        static int rFibNum(int a, int b, int n)
        {
            if (n == 1)
                return a;
            else if (n == 2)
                return b;
            else
                return rFibNum(a, b, n - 1) + rFibNum(a, b, n - 2);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first Fibonacci number : ");
            int firstFibNum = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second Fibonacci number : ");
            int secondFibNum = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the position of the desiref Fibonacci number : ");
            int nth = int.Parse(Console.ReadLine());

            Console.WriteLine(
                string.Format("The Fibonacci number at position {0} is : {1}",nth,
                rFibNum(firstFibNum,secondFibNum,nth)
                )
                );
        }
    }
}
