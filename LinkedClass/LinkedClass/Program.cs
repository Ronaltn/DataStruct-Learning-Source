using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedClass
{
    class Program
    {
        static void Main(string[] args)
        {
            UnorderedLinkedListClass list = new UnorderedLinkedListClass();
            list.insertLast(2);
            list.insertLast(1);
            list.insertLast(3);
            list.insertLast(4);
            list.insertLast(5);
            list.sectionSort();
            list.print();
        }
    }
}
