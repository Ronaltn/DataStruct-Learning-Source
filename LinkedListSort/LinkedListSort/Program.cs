using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListSort
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListSort lls = new LinkedListSort();
            lls.addNewNode(10);
            lls.addNewNode(7);
            lls.addNewNode(25);
            lls.addNewNode(8);
            lls.addNewNode(12);
            lls.addNewNode(20);
            lls.selectionSort();
            lls.print();
        }
    }
}
