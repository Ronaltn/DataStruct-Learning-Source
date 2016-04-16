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
            LinkedListNode current;    //��������Ķ�̬����
            bool found;    //���岼����������ʾ�ڱ����������Ƿ��ҵ�ָ����

            current = first;    //������ָ�������е�ͷ�ڵ�
            found = false;     //��ʼBool����ֵΪfalse

            while (current != null && !found)
                //��������
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
            LinkedListNode current;           //������ָ�������е�ͷ�ڵ�
            LinkedListNode trailCurrent;    //λ��λ��current֮ǰ�ı���
            bool found;                                  //���岼����������ʾ�ڱ����������Ƿ��ҵ�ָ����

            if (first == null)
                //��һ�����������Ϊ��
                throw new Exception("cannot delete from an empty list");

            if (first.info.Equals(deleteItem))
                //�ڶ������������Ϊ�ǿգ���Ҫɾ���Ľڵ��ǵ�һ���ڵ�
            {
                first = first.link;

                if (first == null)
                    //ɾ����ͷ�ڵ�Ϊ��
                    last = null;

                count--;
            }
            else
                //�������������Ǹ�����ֵ
            {
                found = false;
                trailCurrent = first;    //������trailCurrentָ��first
                current = first.link;    //������Currentָ������ڶ����ڵ�

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
                //����ҵ���ɾ���ýڵ�
                {
                    count--;
                    trailCurrent.link = current.link;

                    if (last == current)
                        //���Ҫɾ���Ľڵ���β�ڵ㣬����last��ֵ
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
