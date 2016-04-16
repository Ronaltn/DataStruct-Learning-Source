using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedClass
{
    class OrderedLinkedListClass : LinkedListClass
    {
        public OrderedLinkedListClass()
        {
            initializeList();
        }

        public OrderedLinkedListClass(OrderedLinkedListClass otherList)
        {
            if (this != otherList)
                copy(otherList);
        }

        public override bool search(int searchItem)
        {
            LinkedListNode current;
            bool found;

            current = first;
            found = false;

            while (current != null && !found)
            {
                if (current.info.CompareTo(searchItem) >= 0)
                    found = true;
                else
                    current = current.link;
            }

            if (found)
                found = current.info.Equals(searchItem);

            return found;
        }//end search

        public void insertNode(int insertItem)
        {
            LinkedListNode current;
            LinkedListNode trailCurrent;
            LinkedListNode newNode;

            bool found;

            newNode = new LinkedListNode();
            newNode.info = insertItem;
            newNode.link = null;

            if (first == null)
            {
                first = newNode;
                count++;
            }
            else
            {
                trailCurrent = first;
                current = first;
                found = false;

                while (current != null && !found)
                {
                    if (current.info.CompareTo(insertItem) > 0)
                        found = true;
                    else if (current.info.CompareTo(insertItem) == 0)
                        throw new Exception("The item to be inserted has already existed in the list");
                    else
                    {
                        trailCurrent = current;
                        current = current.link;
                    }
                }

                if (current == first)
                {
                    newNode.link = first;
                    first = newNode;
                    count++;
                }
                else
                {
                    trailCurrent.link = newNode;
                    newNode.link = current;
                    count++;
                }
            }//end else
        }//end insertNode

        public override void deleteNode(int deleteItem)
        {
            LinkedListNode current;
            LinkedListNode trailCurrent;
            bool found;

            if (first == null)
                throw new Exception("Cannot delete from an empty list");

            current = first;
            if (current.info.Equals(deleteItem))
            {
                first = first.link;
                count--;
            }
            else
            {
                found = false;
                trailCurrent = first;
                current = first.link;

                while (current != null && !found)
                {
                    if (current.info.CompareTo(deleteItem) >= 0)
                        found = true;
                    else
                    {
                        trailCurrent = current;
                        current = current.link;
                    }
                }//end while

                if (current == null)
                    throw new Exception("The item to be deleted is not in the list");
                else
                {
                    if (current.info.Equals(deleteItem))
                    {
                        if (first == current)
                        {
                            first = first.link;
                            count--;
                        }
                        else
                        {
                            trailCurrent.link = current.link;
                            count--;
                        }
                    }
                    else
                        throw new Exception("The item to be deleted is not in the list");
                }
            }//end else
        }//end deleteNode
    }
}
