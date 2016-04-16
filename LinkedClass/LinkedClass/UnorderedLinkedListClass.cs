using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedClass
{
    class UnorderedLinkedListClass : LinkedListClass
    {
        public UnorderedLinkedListClass()
        {
            initializeList();
        }

        public UnorderedLinkedListClass(UnorderedLinkedListClass otherList)
        {
            if (this != otherList)
            {
                copy(otherList);
            }
        }
   
        public override bool search(int searchItem)
        {
            LinkedListNode current;    //遍历链表的动态变量
            bool found;    //定义布尔变量，表示在遍历过程中是否找到指定项

            current = first;    //将变量指向链表中的头节点
            found = false;     //初始Bool变量值为false

            while (current != null && !found)
                //搜索链表
            {
                if (current.info.Equals(searchItem))
                    found = true;
                else
                    current = current.link;
            }

            return found;
        }

        public override void deleteNode(int deleteItem)
        {
            LinkedListNode current;           //将变量指向链表中的头节点
            LinkedListNode trailCurrent;    //位置位于current之前的变量
            bool found;                                  //定义布尔变量，表示在遍历过程中是否找到指定项

            if (first == null)
                //第一种情况，链表为空
                throw new Exception("cannot delete from an empty list");

            if (first.info.Equals(deleteItem))
                //第二种情况，链表为非空，且要删除的节点是第一个节点
            {
                first = first.link;

                if (first == null)
                    //删除后头节点为空
                    last = null;

                count--;
            }
            else
                //搜索链表，条件是给定的值
            {
                found = false;
                trailCurrent = first;    //将变量trailCurrent指向到first
                current = first.link;    //将变量Current指向链表第二个节点

                while (current != null && !found)
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
                //如果找到，删除该节点
                {
                    count--;
                    trailCurrent.link = current.link;

                    if (last == current)
                        //如果要删除的节点是尾节点，更新last的值
                        last = trailCurrent;
                }
                else
                    throw new Exception("Item to be deleted is not in the list");
            }
        }

        private int GetminItem(LinkedListNode LinkedList)
        {
            LinkedListNode minNode = LinkedList;
            LinkedListNode current = LinkedList.link;

            while (current != null)
            {
                if (current.info.CompareTo(minNode.info) < 0)
                    minNode = current;

                current = current.link;
            }
            return minNode.info;
        }

        private void swap(int firstInt, int secondInt)
        {
            LinkedListNode firstNode;
            LinkedListNode trailFirstNode;

            LinkedListNode secondNode;
            LinkedListNode trailSecondNode;

            trailFirstNode = first;
            firstNode = first.link;
            while (firstNode != null)
            {
                if (trailFirstNode.info.Equals(firstInt))
                    break;
                else
                {
                    trailFirstNode = firstNode;
                    firstNode = firstNode.link;
                }
            }

            trailSecondNode = first;
            secondNode = first.link;
            while (secondNode != null)
            {
                if (trailSecondNode.info.Equals(secondInt))
                    break;
                else
                {
                    trailSecondNode = secondNode;
                    secondNode = secondNode.link;
                }
            }

            if (trailFirstNode == null && secondNode.link == null)
            {

            }
            else if (trailFirstNode == null && secondNode.link != null) 
            {

            }
            else if (trailFirstNode != null && secondNode.link == null)
            {

            }
            else
            {

            }
        }

        public void sectionSort()
        {
            int minItem;
            LinkedListNode current = first;

            while (current != null)
            {
                minItem = GetminItem(current);
                swap(current.info, minItem);

                current = current.link;
            }
        }
    }
}
