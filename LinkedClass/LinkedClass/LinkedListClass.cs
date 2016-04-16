using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedClass
{
    class LinkedListClass
    {
        protected class LinkedListNode
        {
            public int info;
            public LinkedListNode link;
        }

        protected LinkedListNode first;
        protected LinkedListNode last;
        protected int count;

        public LinkedListClass()
        {
            initializeList();
        }

        public LinkedListClass(LinkedListClass otherList)
        {
            if (this != otherList)
                copy(otherList);
        }

        //���������Ƿ�Ϊ��
        public bool isEmptyList()
        {
            return (first == null);
        }

        //��ʼ������
        public virtual void initializeList()
        {
            first = null;
            last = null;
            count = 0;
        }

        //������������е�����
        public virtual void print()
        {
            LinkedListNode current;

            current = first;
            while (current != null)
            {
                Console.Write(current.info + ",");
                current = current.link;
            }
        }//end print

        //�������ĳ���
        public int length()
        {
            return count;
        }

        //��������еĵ�һ���ڵ�
        public int front()
        {
            return first.info;
        }

        //��������е����һ���ڵ�
        public int back()
        {
            return last.info;
        }

        public void insertFirst(int newItem)
        {
            LinkedListNode newNode;

            newNode = new LinkedListNode();
            newNode.info = newItem;

            newNode.link = first;
            first = newNode;

            if (last == null)
                last = newNode;

            count++;
        }//end insertFirst

        public void insertLast(int newItem)
        {
            LinkedListNode newNode;

            newNode = new LinkedListNode();
            newNode.info = newItem;

            //newNode = null;
            //last = new LinkedListNode();

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

            count++;
        }//end insertLast

        protected void copy(LinkedListClass otherList)
        {
            LinkedListNode newNode;
            LinkedListNode current;

            first = null;

            if (otherList.first == null)
            {
                first = null;
                last = null;
                count = 0;
            }
            else
            {
                count = otherList.count;
                current = otherList.first;

                first = new LinkedListNode();
                first.info = current.info;
                first.link = null;

                last = first;

                current = current.link;

                while (current != null)
                {
                    newNode = new LinkedListNode();
                    newNode.info = current.info;
                    newNode.link = null;

                    last.link = newNode;
                    last = newNode;

                    current = current.link;
                }//end while
            }//end else
        }//end copy

        //�����ؼ����Ƿ������������
        public virtual bool search(int searchItem)
        {
            LinkedListNode current;
            bool found;

            current = first;

            found = false;

            while (current != null && !found)
            {
                if (current.info.Equals(searchItem))
                    found = true;
                else
                    current = current.link;
            }

            return found;
        }//end search

        public virtual void deleteNode(int deleteItem)
        {
            LinkedListNode current;
            LinkedListNode trailCurrent;
            bool found;

            if (first == null)
            {
                throw new Exception("Cannot delete from an empty list.");
            }
            else
            {
                if (first.info.Equals(deleteItem))
                {
                    first = first.link;

                    if (first == null)
                        last = null;

                    count--;
                }
                else
                {
                    found = false;
                    trailCurrent = first;
                    current = first.link;

                    while (current != null && !found)
                    {
                        if (current.info.Equals(deleteItem))
                        {
                            found = true;
                        }
                        else
                        {
                            trailCurrent = current;
                            current = current.link;
                        }
                    }//end while

                    if (found)
                    {
                        count--;
                        trailCurrent.link = current.link;

                        if (last == current)
                            last = trailCurrent;
                    }
                    else
                    {
                        throw new Exception("Item to be deleted is not in the list");
                    }//end else
                }//end else
            }//end deleteNode
        }
    }
}
