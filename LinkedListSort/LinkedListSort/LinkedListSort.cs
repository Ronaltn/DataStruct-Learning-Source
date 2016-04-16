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

        #region ѡ������

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

        #region ��������

        public void linkedInsertionSort()
        {
            //ָ����������������һ���ڵ�
            LinkedListNode lastInOrder;

            //ָ��δ��������ĵ�һ���ڵ�
            LinkedListNode firstOutOfOrder;

            //��������ʱָ���lastInOrder��ֵ��Ľڵ�
            LinkedListNode current;

            //current��ǰһ���ڵ�
            LinkedListNode trailCurrent;

            //��lastInOrderָ��first
            lastInOrder = first;

            if (first == null)
                throw new Exception("Cannot sort an empty list");
            else if (first.link == null)
                throw new Exception("The list is of length 1.It is already in order");

            //��ָ����������������һ���ڵ㲻���������һ���ڵ�ʱ
            //ִ��ѭ��
            while (lastInOrder.link != null)
            {
                firstOutOfOrder = lastInOrder.link;

                //���δ�����ͷ�ڵ��ֵ������ͷ�ڵ��ֵС
                //��δ�����ͷ�ڵ�ת��������ĵ�һ��λ��
                if (firstOutOfOrder.info.CompareTo(first.info) < 0)
                {
                    lastInOrder.link = firstOutOfOrder.link;
                    firstOutOfOrder.link = first;
                    first = firstOutOfOrder;
                }
                else
                {
                    //���򣬱�������
                    //�����ǰ�ڵ��ֵС��δ����ͷ�ڵ��ֵ
                    //���ҵ����ʵ�λ��
                    trailCurrent = first;
                    current = first.link;
                    while (current.info.CompareTo(firstOutOfOrder.info) < 0)
                    {
                        trailCurrent = current;
                        current = current.link;
                    }

                    //�����ǰ�����õ��Ľڵ���δ����ͷ�ڵ㲻ͬ
                    if (current != firstOutOfOrder)
                    {
                        //���нڵ㽻��
                        lastInOrder.link = firstOutOfOrder.link;
                        firstOutOfOrder.link = current;
                        trailCurrent.link = firstOutOfOrder;
                    }
                    else
                        //�ڴ˱�ʾδ����ͷ�ڵ���ʵ�Ѿ���������ȷ��λ��
                        //��������
                        //���������ĩ�ڵ�������һ��
                        lastInOrder = lastInOrder.link;
                }
            }//end while
        }//end linkedInsertionSort

        #endregion

        #region �鲢����

        /// <summary>
        /// ��������Ϊ�����ӱ�
        /// </summary>
        /// <param name="head">����</param>
        /// <returns>��ǰ�����ֺ�ĵڶ����ӱ�</returns>
        private LinkedListNode divedeList(LinkedListNode head)
        {
            //����ָ��������λ�þ��еĽڵ�
            LinkedListNode middle;

            //���ڱ�����������ı���
            LinkedListNode current;

            //�����ֺ�ڶ����ӱ��ͷ�ڵ�
            LinkedListNode secondListHead;

            //���ͷ�ڵ���ߵڶ����ڵ�Ϊnull
            //�ڶ��ӱ���Ϊnull
            //����Ϊ��
            //�����������
            //�ҵ�λ�þ��еĽڵ�
            //���Դ˻���Ϊ����������
            if (head == null || head.link == null)
            {
                secondListHead = null;
            }
            else
            {
                middle = head;
                current = head.link;

                //����ڵ��������2
                //current����ǰ�ƽ�һ���ڵ�
                if (current != null)
                    current = current.link;

                //Ϊȡ���м�ڵ�
                //��middle��ǰ�ƽ�һ���ڵ�
                //current��Ҫ��ǰ�ƽ������ڵ�
                //��currentΪ��ʱ
                //middle��ָ��ǰ����λ�þ��еĽڵ�
                while (current != null)
                {
                    middle = middle.link;
                    current = current.link;
                    if (current != null)
                        current = current.link;
                }//end while

                //secondListHeadָ��ڶ��ӱ��ͷ�ڵ�
                //ͷ�ڵ㼴�м�ڵ����һ���ڵ�
                secondListHead = middle.link;

                //�����м�ڵ�Ϊ��һ�ӱ�����һ���ڵ�
                middle.link = null;
            }

            //���صڶ��ӱ�
            return secondListHead;
        }

        private LinkedListNode mergeList(LinkedListNode first1, LinkedListNode first2)
        {
            //����ָ��ϲ�����������һ���ڵ�
            LinkedListNode lastSmall;

            //����ָ��ϲ�������ĵ�һ���ڵ�
            LinkedListNode newHead;

            //���������һ������Ϊnull
            //�򷵻���һ������
            if (first1 == null)
                return first2;
            else if (first2 == null)
                return first1;

            //���first1ͷ�ڵ��ֵ��first2��С
            //�ϲ������ͷ�ڵ�ָ��first1
            //first1��ǰ�ƽ�һ���ڵ�
            //����first2����������
            //���ϲ���������һ���ڵ�ָ��ϲ������ͷ�ڵ�
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

            //��first1��first2����Ϊnullʱ
            //ִ������ѭ����
            while (first1 != null && first2 != null)
            {
                //���first1�Ľڵ�ֵ��first2��С
                //��ϲ����������first1�ڵ㲢��first1��ǰ�ƽ�һ���ڵ�
                //�������first2�ڵ㲢��first2��ǰ�ƽ�һ���ڵ�
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
