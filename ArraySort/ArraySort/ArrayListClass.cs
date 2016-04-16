using System;
using System.Collections.Generic;
using System.Text;

namespace ArraySort
{
    class ArrayListClass
    {
        public int[] ArrayInteger = new int[] { 16, 30, 24, 7, 25, 62, 45, 5, 65, 50 };

        #region ѡ������

        /// <summary>
        /// ����С�������������֮���ҳ���Сֵ������
        /// </summary>
        /// <param name="first">��С����</param>
        /// <param name="last">�������</param>
        /// <returns>��Сֵ������</returns>
        private int minLocation(int first, int last)
        {
            //������Сֵ�����ı���
            //��ʼ��ֵΪfirst
            int minIndex = first;

            //ѭ������������ָ����Χ��Ԫ��
            //�����ǰ��������ֵС�ڼ�¼����Сֵ������
            //����ǰ��ȡ������ֵ����minIndex
            for (int loc = first + 1; loc <= last; loc++)
            {
                if (ArrayInteger[loc].CompareTo(ArrayInteger[minIndex]) < 0)
                    minIndex = loc;
            }

            return minIndex;

        }//end minLocation

        /// <summary>
        /// ��������ͬ������ֵ����λ�û���
        /// </summary>
        /// <param name="first">��Ҫ����ֵ������</param>
        /// <param name="second">��һ����Ҫ����ֵ������</param>
        private void swap(int first, int second)
        {
            //������ʱ����
            //����ֵ�Ľ���
            int temp;

            //����ֵ�Ľ���
            temp = ArrayInteger[first];
            ArrayInteger[first] = ArrayInteger[second];
            ArrayInteger[second] = temp;

        }//end swap

        /// <summary>
        /// ѡ������
        /// </summary>
        public void sectionSort()
        {
            //������ʱ����
            //���ڴ洢��ǰ������Χ����Сֵ������
            int minIndex;

            //��������
            //�����ҳ���Χ�ڵ���Сֵ������
            //�ٽ��л�λ
            //��ʹ������
            //���ɽ��л�λ
            for (int loc = 0; loc < ArrayInteger.Length; loc++)
            {
                minIndex = minLocation(loc, ArrayInteger.Length - 1);
                swap(loc, minIndex);
            }
        }

        #endregion

        #region ��������

        /// <summary>
        /// ��������
        /// </summary>
        public void insertionSort()
        {
            //�����ݴ���Ҫ�ƶ�������ֵ
            int temp;

            //�����ݴ���Ҫ�ƶ�����������ֵ
            int location;

            //�������������
            //������ֵ�ǰ��δ�����ֵ
            //��������
            for (int unsortedIndex = 1; unsortedIndex < ArrayInteger.Length; unsortedIndex++)
            {
                //�����ǰ������ֵ��ǰһ��������ֵС
                if (ArrayInteger[unsortedIndex].CompareTo(ArrayInteger[unsortedIndex - 1]) < 0)
                {
                    //�������ֵ�����ֵ��Ӧ������
                    temp = ArrayInteger[unsortedIndex];
                    location = unsortedIndex;

                    //��һ�����Ƚ���location������ֵ������location-1������
                    //�ڶ�����location��ȥ1
                    //�����������location��Ȼ����0����(location-1)�ϵ�ֵ�ȼ�¼��ֵ��
                    //��������һ��
                    //��������ѭ�����ڵ�ǰlocation������λ���ϸ�����¼��ֵ
                    do
                    {
                        ArrayInteger[location] = ArrayInteger[location - 1];
                        location--;
                    }
                    while (location > 0 && ArrayInteger[location - 1].CompareTo(temp) > 0);
                    ArrayInteger[location] = temp;
                }
            }
        }//end insertionSort

        #endregion

        #region ��������

        /// <summary>
        /// ��ȡ������е��м�λ�õ�ֵ�����ĵ�һ��ֵ����λ��
        /// ������Ϊ�²��ӱ���ϲ��ӱ�
        /// �²��ӱ����ڴ洢С���м�λ��ֵ������
        /// �ϲ��ӱ����ڴ洢�����м�λ��ֵ������
        /// �����м�ֵ������
        /// </summary>
        /// <param name="first">���鿪ʼ����</param>
        /// <param name="last">�����������</param>
        /// <returns>�м�λ������</returns>
        private int partiton(int first, int last)
        {
            //�²��ӱ������һ��Ԫ��λ�õ�����
            int smallIndex;

            //���first��last�м�����
            //�����м�λ�õ�ֵ���һλ�õ�ֵ����
            swap(first, (first + last) / 2);

            //��ʼ��ֵΪһ��ʼ��λ��
            smallIndex = first;

            //����first��last֮�������Ԫ��
            //�����ǰ��Ԫ��С�ڵ�һ��Ԫ�أ����м�λ�õ�ֵ��
            //�²��ӱ������һ��Ԫ��λ�õ�����+1
            //����smallIndex��indexλ�õ�ֵ
            for (int index = first + 1; index <= last; index++)
            {
                if (ArrayInteger[index].CompareTo(ArrayInteger[first]) < 0)
                {
                    smallIndex++;
                    swap(smallIndex, index);
                }
            }

            //�������
            //���м�ֵ�ָ�ԭλ
            swap(first, smallIndex);

            //�����²��ӱ������һ��Ԫ��λ�õ�����
            //���м�λ������
            return smallIndex;
        }

        /// <summary>
        /// ���õݹ�ķ�����������
        /// </summary>
        /// <param name="first">���鿪ʼ����</param>
        /// <param name="last">�����������</param>
        private void recQuickSort(int first, int last)
        {
            //�м�ֵ����
            int pivotLocation;

            //�����ʼ����С�ڽ�������
            //���л�������
            //ֱ��first=last
            if (first < last)
            {
                pivotLocation = partiton(first, last);
                recQuickSort(first, pivotLocation - 1);
                recQuickSort(pivotLocation + 1, last);
            }
        }

        /// <summary>
        /// ��������    
        /// </summary>
        public void quickSort()
        {
            recQuickSort(0, ArrayInteger.Length - 1);
        }

        #endregion

        #region �� �� ��

        /// <summary>
        /// ��ÿ�α���ѭ��ʱΪһ�������ֵ
        /// �Ӷ��������лָ���
        /// ��ĸ��ڵ������Լ��������һ��Ԫ�ص�����
        /// ��Ϊ�������ݸ��÷���
        /// </summary>
        /// <param name="low">���ڵ�����</param>
        /// <param name="high">���һ��Ԫ�ص�����</param>
        private void heapify(int low, int high)
        {
            //�������ڵ��ֵ��temp
            int temp = ArrayInteger[low];

            //��������ߵ����ӽڵ�
            int largeIndex = 2 * low + 1;

            while (largeIndex <= high)
            {
                if (largeIndex < high)
                {
                    if (ArrayInteger[largeIndex].CompareTo(ArrayInteger[largeIndex + 1]) < 0)
                        largeIndex++;
                }

                if (temp.CompareTo(ArrayInteger[largeIndex]) > 0)
                    break;
                else
                {
                    ArrayInteger[low] = ArrayInteger[largeIndex];

                    low = largeIndex;

                    largeIndex = 2 * low + 1;
                }
            }//end while

            ArrayInteger[low] = temp;
        }//end heapify

        private void bulidHeap()
        {
            for (int index = ArrayInteger.Length / 2 - 1; index >= 0; index--)
                heapify(index, ArrayInteger.Length - 1);
        }

        /// <summary>
        /// ������
        /// </summary>
        public void heapSort()
        {
            int temp;
            bulidHeap();

            for (int lastOutOfOrder = ArrayInteger.Length - 1; lastOutOfOrder >= 0; lastOutOfOrder--)
            {
                temp = ArrayInteger[lastOutOfOrder];
                ArrayInteger[lastOutOfOrder] = ArrayInteger[0];
                ArrayInteger[0] = temp;
                heapify(0, lastOutOfOrder - 1);
            }//end for
        }//end heapSort

        #endregion

        /// <summary>
        /// ��������е�ֵ
        /// </summary>
        public void print()
        {
            foreach (int i in ArrayInteger)
            {
                Console.Write(i + ",");
            }
        }
    }
}
