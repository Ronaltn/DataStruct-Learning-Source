using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedClass
{
    /// <summary>
    /// Ñ­»·Á´±í
    /// </summary>
    class CycleLinkedListClass : LinkedListClass
    {
        public CycleLinkedListClass()
        { }

        public CycleLinkedListClass(CycleLinkedListClass otherList)
        { }

        public override void initializeList()
        {
            first = null;
            count = 0;
        }

        public override void print()
        {
            LinkedListNode current;
            current = first;

            int i = 0;
            while (current != null && i < count)
            {
                Console.Write(current.info + ",");
                current = current.link;
                i++;
            }
        }//end print

        public override bool search(int searchItem)
        {
            LinkedListNode current;
            bool found;

            current = first;
            found=false;

            int i = 0;
            while (current != null && !found && i < count)
            {
                if (current.info.Equals(searchItem))
                    found = true;
                else
                {
                    current = current.link;
                    i++;
                }
            }

            return found;
        }

        public void insertNode(int insertItem)
        {
            LinkedListNode newNode;

            newNode = new LinkedListNode();
            newNode.info = insertItem;
            newNode.link = null;

            if (search(insertItem))
                throw new Exception("The item to be inserted has already exists in the list");

            if (first == null)
            {
                first = newNode;
                newNode.link = first;
            }
            else if (first == first.link)
            {
                newNode.link = first;
                first.link = newNode;
            }
            else
            {
                newNode.link = first.link;
                first.link = newNode;
            }

            count++;
        }

        public override void deleteNode(int deleteItem)
        {
            LinkedListNode current;
            LinkedListNode trailCurrent;
            bool found;

            if (first == null)
                throw new Exception("Cannot delete from an empty list");

            if (first.info.Equals(deleteItem) && first == first.link)
            {
                first = null;
                count--;
            }
            else
            {
                found = false;
                trailCurrent = first;
                current = first.link;
                while (current != null && current != first && !found)
                {
                    if (current.info.Equals(deleteItem))
                        found = true;
                    else
                    {
                        trailCurrent = current;
                        current = current.link;
                    }
                }//end while

                if (found)
                {
                    trailCurrent.link = current.link;
                    count--;
                }
                else
                    throw new Exception("Item to be deleted is not in the list");
            }//end else
        }//end deleteNode

        private void copy(CycleLinkedListClass otherList)
        {
            LinkedListNode newNode;
            LinkedListNode current;

            first = null;

            if (otherList.first == null)
            {
                first = null;
                count = 0;
            }
            else
            {
                count = otherList.count;
                current = otherList.first;

                first = new LinkedListNode();
                first.info = current.info;
                first.link = null;

                current = current.link;

                while (current != null && current != first)
                {
                    newNode = new LinkedListNode();
                    newNode.info = current.info;
                    newNode.link = null;

                    newNode.link = first;
                    
                    last = newNode;

                    current = current.link;
                }//end while
            }
        }
    }
}
