using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertToBinary
{
    class Program
    {
        static void IntToBin(int num)
        {
            if (num > 0)
            {
                IntToBin(num / 2);
                Console.Write(num % 2);
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter the num in Int : ");
            int i = int.Parse(Console.ReadLine());
            Console.Write(string.Format("Int {0} = ", i));
            IntToBin(i);
            Console.Write(" Binary");
        }
    }
}
