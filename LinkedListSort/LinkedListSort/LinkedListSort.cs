using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListSort
{
    class LinkedListSort
    {
        class LinkedListNode
        {
            public int info;
            public LinkedListNode link;
        }

        LinkedListNode first;
        LinkedListNode last;
        int count;

        public LinkedListSort()
        {
            first = null;
            last = null;
            count = 0;
        }

        public void addNewNode(int Node)
        {
            LinkedListNode newNode = new LinkedListNode();
            newNode.info = Node;
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

            count++;
        }

        #region 选择排序

        public void selectionSort()
        {
            LinkedListNode canCurrent;
            LinkedListNode current;
            LinkedListNode tempCurrent = null;

            canCurrent = first;

            int minInfo;
            while (canCurrent != null)
            {
                minInfo = canCurrent.info;
                current = canCurrent.link;

                while (current != null)
                {
                    if (current.info < minInfo)
                    {
                        minInfo = current.info;
                        tempCurrent = current;
                    }

                    current = current.link;
                }
                
                tempCurrent.info = canCurrent.info;
                canCurrent.info = minInfo;

                canCurrent = canCurrent.link;
            }
        }

        #endregion

        #region 插入排序

        public void linkedInsertionSort()
        {
            //指向已排序链表的最后一个节点
            LinkedListNode lastInOrder;

            //指向未排序链表的第一个节点
            LinkedListNode firstOutOfOrder;

            //遍历链表时指向比lastInOrder的值大的节点
            LinkedListNode current;

            //current的前一个节点
            LinkedListNode trailCurrent;

            //将lastInOrder指向first
            lastInOrder = first;

            if (first == null)
                throw new Exception("Cannot sort an empty list");
            else if (first.link == null)
                throw new Exception("The list is of length 1.It is already in order");

            //当指向已排序链表的最后一个节点不是链表最后一个节点时
            //执行循环
            while (lastInOrder.link != null)
            {
                firstOutOfOrder = lastInOrder.link;

                //如果未排序的头节点的值比链表头节点的值小
                //将未排序的头节点转移至链表的第一个位置
                if (firstOutOfOrder.info.CompareTo(first.info) < 0)
                {
                    lastInOrder.link = firstOutOfOrder.link;
                    firstOutOfOrder.link = first;
                    first = firstOutOfOrder;
                }
                else
                {
                    //否则，遍历链表
                    //如果当前节点的值小于未排序头节点的值
                    //即找到合适的位置
                    trailCurrent = first;
                    current = first.link;
                    while (current.info.CompareTo(firstOutOfOrder.info) < 0)
                    {
                        trailCurrent = current;
                        current = current.link;
                    }

                    //如果当前遍历得到的节点与未排序头节点不同
                    if (current != firstOutOfOrder)
                    {
                        //进行节点交换
                        lastInOrder.link = firstOutOfOrder.link;
                        firstOutOfOrder.link = current;
                        trailCurrent.link = firstOutOfOrder;
                    }
                    else
                        //在此表示未排序头节点其实已经放置在正确的位置
                        //无需排序
                        //将已排序的末节点链至下一个
                        lastInOrder = lastInOrder.link;
                }
            }//end while
        }//end linkedInsertionSort

        #endregion

        #region 归并排序

        /// <summary>
        /// 将链表划分为两个子表
        /// </summary>
        /// <param name="head">链表</param>
        /// <returns>当前链表划分后的第二个子表</returns>
        private LinkedListNode divedeList(LinkedListNode head)
        {
            //用于指向当期链表位置居中的节点
            LinkedListNode middle;

            //用于遍历整个链表的变量
            LinkedListNode current;

            //链表划分后第二个子表的头节点
            LinkedListNode secondListHead;

            //如果头节点或者第二个节点为null
            //第二子表设为null
            //返回为空
            //否则遍历链表
            //找到位置居中的节点
            //并以此划分为两个子链表
            if (head == null || head.link == null)
            {
                secondListHead = null;
            }
            else
            {
                middle = head;
                current = head.link;

                //链表节点个数超过2
                //current再向前推进一个节点
                if (current != null)
                    current = current.link;

                //为取到中间节点
                //当middle向前推进一个节点
                //current就要向前推进两个节点
                //当current为空时
                //middle即指向当前链表位置居中的节点
                while (current != null)
                {
                    middle = middle.link;
                    current = current.link;
                    if (current != null)
                        current = current.link;
                }//end while

                //secondListHead指向第二子表的头节点
                //头节点即中间节点的下一个节点
                secondListHead = middle.link;

                //设置中间节点为第一子表的最后一个节点
                middle.link = null;
            }

            //返回第二子表
            return secondListHead;
        }

        private LinkedListNode mergeList(LinkedListNode first1, LinkedListNode first2)
        {
            //引用指向合并后链表的最后一个节点
            LinkedListNode lastSmall;

            //引用指向合并后链表的第一个节点
            LinkedListNode newHead;

            //如果其中有一个链表为null
            //则返回另一个链表
            if (first1 == null)
                return first2;
            else if (first2 == null)
                return first1;

            //如果first1头节点的值比first2的小
            //合并链表的头节点指向first1
            //first1向前推进一个节点
            //否则first2做上述操作
            //最后合并链表的最后一个节点指向合并链表的头节点
            if (first1.info.CompareTo(first2.info) < 0)
            {
                newHead = first1;
                first1 = first1.link;
            }
            else
            {
                newHead = first2;
                first2 = first2.link;
            }
            lastSmall = newHead;

            //当first1和first2都不为null时
            //执行以下循环体
            while (first1 != null && first2 != null)
            {
                //如果first1的节点值比first2的小
                //向合并链表中添加first1节点并且first1向前推进一个节点
                //否则添加first2节点并且first2向前推进一个节点
                if (first1.info.CompareTo(first2.info) < 0)
                {
                    lastSmall.link = first1;
                    lastSmall = lastSmall.link;
                    first1 = first1.link;
                }
                else
                {
                    lastSmall.link = first2;
                    lastSmall = lastSmall.link;
                    first2 = first2.link;
                }
            }//end while

            if (first1 == null)
                lastSmall.link = first2;
            else
                lastSmall.link = first1;

            return newHead;
        }

        private LinkedListNode recMergeSort(LinkedListNode head)
        {
            LinkedListNode otherHead;

            if (head != null)
            {
                if (head.link != null)
                {
                    otherHead = divedeList(head);
                    head = recMergeSort(head);
                    otherHead = recMergeSort(otherHead);
                    head = mergeList(head, otherHead);
                }
            }

            return head;
        }

        public void mergeSort()
        {
            first = recMergeSort(first);
        }//end mergeSort

        #endregion

        public void print()
        {
            LinkedListNode current;
            current = first;
            while (current != null)
            {
                Console.Write(current.info + ",");
                current = current.link;
            }
        }
    }
}
