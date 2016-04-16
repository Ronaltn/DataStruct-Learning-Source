using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    class QueueClass
    {
        private int maxQueueSize;
        private int count;
        private int queueFront;
        private int queueRear;
        private string[] list;

        public QueueClass()
        {
            maxQueueSize = 100;

            queueFront = 0;
            queueRear = maxQueueSize - 1;
            count = 0;
            list = new string[maxQueueSize];
        }

        public QueueClass(int queueSize)
        {
            if (queueSize <= 0)
            {
                Console.WriteLine("The size of the array to hold the queue must be positive.");
                Console.WriteLine("Creating an array of size 100;");

                maxQueueSize = 100;
            }
            else
                maxQueueSize = queueSize;

            queueFront = 0;
            queueRear = maxQueueSize - 1;
            count = 0;
            list = new string[maxQueueSize];
        }

        public void initializeQueue()
        {
            for (int i = queueFront; i < queueRear; i = (i + 1) % maxQueueSize)
                list[i] = null;

            queueFront = 0;
            queueRear = maxQueueSize - 1;
            count = 0;
        }

        public bool isEmptyQueue()
        {
            return (count == 0);
        }

        public bool isFullQueue()
        {
            return (count == maxQueueSize);
        }

        public string front()
        {
            if (isEmptyQueue())
                throw new Exception();

            return list[queueFront];
        }

        public string back()
        {
            if (isEmptyQueue())
                throw new Exception();

            return list[queueRear];
        }

        public void addQueue(string newElement)
        {
            if (isFullQueue())
                throw new Exception();

            queueRear = (queueRear + 1) % maxQueueSize;

            count++;
            list[queueRear] = newElement;
        }

        public void deleteQueue()
        {
            if (isEmptyQueue())
                throw new Exception();

            count--;
            list[queueFront] = null;
            queueFront = (queueFront + 1) % maxQueueSize;
        }
    }
}
