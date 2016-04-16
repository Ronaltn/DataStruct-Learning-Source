using System;
using System.Collections.Generic;
using System.Text;

namespace OrderedAlgorithm
{
    public class LinkedSort
    {
        protected class LinkedListNode
        {
            public int info;
            public LinkedListNode link;
        }

        LinkedListNode first;
        LinkedListNode last;

        public LinkedSort()
        {
            int[] IntArray = new int[] { 9, 0, 7, 5, 6, 2, 1, 4, 3, 8 };

            LinkedListNode newNode;
            foreach (int i in IntArray)
            {
                newNode = new LinkedListNode();
                newNode.info = i;
                newNode.link = null;

                if (first == null)
                {
                    first = newNode;
                    last = newNode;
                }
                else
                {
                    last.link = newNode;
                    last = newNode;
                }

                newNode = null;
            }
        }

        public void Print()
        {
            LinkedListNode current;
            current = first;
            while (current != null)
            {
                Console.Write(current.info+",");
                current = current.link;
            }
        }

        public void linkedInsertionSort()
        {
            LinkedListNode lastInOrder;
            LinkedListNode firstOutOfOrder;
            LinkedListNode current;
            LinkedListNode trailCurrent;

            lastInOrder = first;

            if (first == null)
            {
                Console.WriteLine("Cannot sort an empty list.");
                return;
            }
            else if (first.link == null)
            {
                Console.WriteLine("The list is of length 1.");
                return;
            }

            while (lastInOrder.link != null)
            {
                firstOutOfOrder = lastInOrder.link;

                if (firstOutOfOrder.info.CompareTo(first.info) < 0)
                {
                    lastInOrder.link = firstOutOfOrder.link;
                    firstOutOfOrder.link = first;
                    first = firstOutOfOrder;
                }
                else
                {
                    trailCurrent = first;
                    current = first.link;
                    while (current.info.CompareTo(firstOutOfOrder.info) < 0)
                    {
                        trailCurrent = current;
                        current = current.link;
                    }
                    if (current != firstOutOfOrder)
                    {
                        lastInOrder.link = firstOutOfOrder.link;
                        firstOutOfOrder.link = current;
                        trailCurrent.link = firstOutOfOrder;
                    }
                    else
                    {
                        lastInOrder = lastInOrder.link;
                    }
                }//end if
            }//end while
        }//end linkedInsertionSort
    }
}
