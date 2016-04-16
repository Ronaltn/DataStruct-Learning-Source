using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedQueueClass intQueue = new LinkedQueueClass();

            intQueue.addQueue("23");
            intQueue.addQueue("45");
            intQueue.addQueue("38");

            Console.WriteLine("intQueue elements:");

            while (!intQueue.isEmptyQueue())
            {
                Console.WriteLine(intQueue.front() + "  ");
                intQueue.deleteQueue();
            }
        }
    }
}
