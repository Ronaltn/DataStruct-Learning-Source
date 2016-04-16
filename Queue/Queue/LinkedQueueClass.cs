using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    class LinkedQueueClass
    {
        protected class QueueNode
        {
            public string info;
            public QueueNode link;
        }

        private QueueNode queueFront;
        private QueueNode queueRear;

        public void initializeQueue()
        {
            queueFront = null;
            queueRear = null;
        }

        public bool isEmptyQueue()
        {
            return (queueFront == null);
        }

        public bool isFullQueue()
        {
            return false;
        }

        public void addQueue(string newElemet)
        {
            QueueNode newNode;
            newNode = new QueueNode();

            newNode.info = newElemet;
            newNode.link = null;

            if (queueFront == null)
            {
                queueFront = newNode;
                queueRear = newNode;
            }
            else
            {
                queueRear.link = newNode;
                queueRear = queueRear.link;
            }
        }

        public string front()
        {
            if (isEmptyQueue())
                throw new Exception();

            return queueFront.info;
        }

        public string back()
        {
            if (isEmptyQueue())
                throw new Exception();

            return queueRear.info;
        }

        public void deleteQueue()
        {
            if (isEmptyQueue())
            {
                throw new Exception();
            }

            queueFront = queueFront.link;

            if (queueFront == null)
                queueRear = null;
        }
    }
}
