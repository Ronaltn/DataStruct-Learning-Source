using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedClass
{
    /// <summary>
    /// ˫������
    /// </summary>
    class DoublyLinkedListClass
    {
        /// <summary>
        /// ˫������ڵ�
        /// </summary>
        protected class DoublyLinkedNode
        {
            public int info;
            public DoublyLinkedNode next;
            public DoublyLinkedNode back;
        }

        protected int count;
        protected DoublyLinkedNode first;
        protected DoublyLinkedNode last;

        public DoublyLinkedListClass()
        {
            initializeList();
        }

        public DoublyLinkedListClass(DoublyLinkedListClass otherList)
        {
            if (this != otherList)
                copy(otherList);
        }

        public bool isEmptyList()
        {
            return (first == null);
        }

        public void initializeList()
        {
            first = null;
            last = null;
            count = 0;
        }

        public int length()
        {
            return count;
        }

        /// <summary>
        /// next�����������
        /// </summary>
        public void print()
        {
            DoublyLinkedNode current;
            current = first;

            while (current != null)
            {
                Console.Write(current.info + ",");
                current = current.next;
            }//end while
        }

        /// <summary>
        /// back�����������
        /// </summary>
        public void reversePrint()
        {
            DoublyLinkedNode current;
            current = first;

            while (current != null)
            {
                Console.Write(current.info + ",");
                current = current.back;
            }
        }

        public bool search(int searchItem)
        {
            DoublyLinkedNode current;
            bool found;

            current = first;
            found = false;

            while (current != null && !found)
            {
                if (current.info.CompareTo(searchItem) >= 0)
                    found = true;
                else
                    current = current.next;
            }//end while

            if (found)
                found = current.info.Equals(searchItem);

            return found;
        }

        public int front()
        {
            return first.info;
        }

        public int back()
        {
            return last.info;
        }

        public void insertNode(int insertItem)
        {
            DoublyLinkedNode current;           //��ǰ��ȡ�ڵ�ı���
            DoublyLinkedNode trailCurrent;    //��ǰ��ȡ�ڵ�back�ı���
            DoublyLinkedNode newNode;       //�½��Ľڵ�
            bool found;

            #region ����һ���½ڵ�

            newNode = new DoublyLinkedNode();
            newNode.info = insertItem;
            newNode.back = null;
            newNode.next = null;

            #endregion


            if (first == null)
                //�������Ϊ�գ��½ڵ�������Ψһ�Ľڵ�
            {
                first = newNode;
                last = newNode;
                count++;
            }
            else
                //�������Ϊ��
            {
                found = false;
                current = first;//��current���ñ���ָ�������ͷ�ڵ�first
                trailCurrent = first.back;

                //��������
                while (current != null && !found)
                {
                    if (current.info.CompareTo(insertItem) >= 0)
                        found = true;
                    else
                    {
                        trailCurrent = current;
                        current = current.next;
                    }
                }//end while

                if (current == first)
                    //�����ǰ�ڵ�Ϊͷ�ڵ�
                {
                    //��first֮ǰ��λ�ò����½ڵ�
                    first.back = newNode;
                    newNode.next = first;
                    first = newNode;
                    count++;
                }
                else if (current != null)
                {
                    //�ڷ�ͷ��β��λ�ò����½ڵ�
                    trailCurrent.next = newNode;
                    newNode.back = trailCurrent;
                    newNode.next = current;
                    current.back = newNode;
                    count++;
                }
                else
                {
                    //�������β��֮������½ڵ�
                    trailCurrent.next = newNode;
                    newNode.back = trailCurrent;
                    last = newNode;
                    count++;
                }

            }//end else
        }//end insertItem

        public void deleteNode(int deleteNode)
        {
            DoublyLinkedNode current;
            DoublyLinkedNode trailCurrent;
            bool found;

            if (first == null)
                throw new Exception("Cannot delete from an empty list");

            if (first.info.Equals(deleteNode))
            {
                current = first;
                first = first.next;

                if (first != null)
                    first.back = null;
                else
                    last = null;

                count--;
            }
            else
            {
                found = false;
                current = first;

                while (current != null && !found)
                {
                    if (current.info.CompareTo(deleteNode) >= 0)
                        found = true;
                    else
                    {
                        current = current.next;
                    }
                }

                if (current != null)
                    throw new Exception("The item to be deleted is not in the list");
                else if (current.info.Equals(deleteNode))
                {
                    trailCurrent = current.back;
                    trailCurrent.next = current.next;

                    if (current.next != null)
                        current.next.back = trailCurrent;

                    if (current == last)
                        last = trailCurrent;

                    count--;
                }
                else
                    throw new Exception("The item to be deleted is not in the list");
            }//end else
        }//end deleteNode

        protected void copy(DoublyLinkedListClass otherList)
        { }

        public void copyList(DoublyLinkedListClass otherList)
        { }
    }
}
