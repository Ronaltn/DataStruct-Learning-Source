using System;
using System.Collections.Generic;
using System.Text;

namespace ArraySort
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayListClass alc = new ArrayListClass();
            alc.heapSort();
            alc.print();
        }
    }
}
