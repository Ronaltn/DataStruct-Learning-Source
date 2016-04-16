using System;
using System.Collections.Generic;
using System.Text;

namespace binarySearch
{
    class binarySearch
    {
        private int[] items;

        public binarySearch()
        {
            items = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        }

        public binarySearch(int[] otherItems)
        {
            items = otherItems;
        }

        /// <summary>
        /// ��whileѭ��ʵ�ֶ���������
        /// </summary>
        /// <param name="seItem"></param>
        /// <returns></returns>
        public bool whileSearch(int seItem)
        {
            //��������ĵ�һ��Ԫ�ص�λ�ã���ʼλ�þ�Ϊ0
            int first = 0;

            //������������һ��Ԫ�ص�λ�ã���ʼֵ��Ϊ����洢Ԫ���������1
            int last = items.Length - 1;

            //�������ڸ������м�λ��
            int mid = -1;

            bool found = false;

            while (first <= last && !found)
            {
                mid = (first + last) / 2;

                //�����ǰ��ȡ��Ԫ��ֵ������Ҫ��ѯ��ֵ
                //�趨����ֵΪtrue
                if (items[mid].Equals(seItem))
                    found = true;
                else
                    //����
                    //�Ƚϵ�ǰֵ����Ҫ��ѯ��ֵ
                    //�����ǰֵ������Ҫ��ѯ��ֵ��ĩλ��ֵ=��ǰ�м�ֵλ��ֵ��1
                    //�����ǰֵС����Ҫ��ѯ��ֵ��ĩλ��ֵ=��ǰ�м�ֵλ��ֵ��1
                {
                    if (items[mid].CompareTo(seItem) > 0)
                        last = mid - 1;
                    else
                        first = mid + 1;
                }
            }

            return found;
        }//end whileSearch

        /// <summary>
        /// �õݹ�ʵ�ֶ���������
        /// </summary>
        /// <param name="seItem"></param>
        /// <returns></returns>
        public bool StackSearch(int seItem)
        {
            return StackProcess(0, items.Length - 1, (items.Length - 1) / 2, seItem);
        }

        private bool StackProcess(int first, int last, int mid, int seItem)
        {
            if (first <= last)
            {
                if (items[mid].Equals(seItem))
                    return true;
                else
                {
                    if (items[mid].CompareTo(seItem) > 0)
                        last = mid - 1;
                    else
                        first = mid + 1;

                    return StackProcess(first, last, (first + last) / 2, seItem);
                }
            }
            else
                return false;
        }
    }
}
