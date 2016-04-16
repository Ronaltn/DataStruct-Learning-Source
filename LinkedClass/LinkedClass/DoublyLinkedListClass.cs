using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedClass
{
    /// <summary>
    /// 双向链表
    /// </summary>
    class DoublyLinkedListClass
    {
        /// <summary>
        /// 双向链表节点
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
        /// next方向输出链表
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
        /// back方向输出链表
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
            DoublyLinkedNode current;           //当前读取节点的变量
            DoublyLinkedNode trailCurrent;    //当前读取节点back的变量
            DoublyLinkedNode newNode;       //新建的节点
            bool found;

            #region 创建一个新节点

            newNode = new DoublyLinkedNode();
            newNode.info = insertItem;
            newNode.back = null;
            newNode.next = null;

            #endregion


            if (first == null)
                //如果链表为空，新节点是链表唯一的节点
            {
                first = newNode;
                last = newNode;
                count++;
            }
            else
                //如果链表不为空
            {
                found = false;
                current = first;//将current引用变量指向链表的头节点first
                trailCurrent = first.back;

                //搜索链表
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
                    //如果当前节点为头节点
                {
                    //在first之前的位置插入新节点
                    first.back = newNode;
                    newNode.next = first;
                    first = newNode;
                    count++;
                }
                else if (current != null)
                {
                    //在非头非尾的位置插入新节点
                    trailCurrent.next = newNode;
                    newNode.back = trailCurrent;
                    newNode.next = current;
                    current.back = newNode;
                    count++;
                }
                else
                {
                    //在链表的尾部之后插入新节点
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
