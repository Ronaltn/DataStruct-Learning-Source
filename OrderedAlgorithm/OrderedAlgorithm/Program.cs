using System;
using System.Collections.Generic;
using System.Text;

namespace OrderedAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            ArraySort AS = new ArraySort();
            AS.quickSort();
            AS.Print();
        }
    }
}
