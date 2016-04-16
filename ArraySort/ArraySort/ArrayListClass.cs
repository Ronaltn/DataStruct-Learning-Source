using System;
using System.Collections.Generic;
using System.Text;

namespace ArraySort
{
    class ArrayListClass
    {
        public int[] ArrayInteger = new int[] { 16, 30, 24, 7, 25, 62, 45, 5, 65, 50 };

        #region 选择排序

        /// <summary>
        /// 在最小索引和最大索引之间找出最小值的索引
        /// </summary>
        /// <param name="first">最小索引</param>
        /// <param name="last">最大索引</param>
        /// <returns>最小值的索引</returns>
        private int minLocation(int first, int last)
        {
            //定义最小值索引的变量
            //初始其值为first
            int minIndex = first;

            //循环遍历数组中指定范围的元素
            //如果当前索引的数值小于记录的最小值的索引
            //将当前读取的索引值赋给minIndex
            for (int loc = first + 1; loc <= last; loc++)
            {
                if (ArrayInteger[loc].CompareTo(ArrayInteger[minIndex]) < 0)
                    minIndex = loc;
            }

            return minIndex;

        }//end minLocation

        /// <summary>
        /// 将两个不同索引的值进行位置互换
        /// </summary>
        /// <param name="first">需要交换值的索引</param>
        /// <param name="second">另一个需要交换值的索引</param>
        private void swap(int first, int second)
        {
            //定义临时变量
            //用于值的交换
            int temp;

            //进行值的交换
            temp = ArrayInteger[first];
            ArrayInteger[first] = ArrayInteger[second];
            ArrayInteger[second] = temp;

        }//end swap

        /// <summary>
        /// 选择排序
        /// </summary>
        public void sectionSort()
        {
            //定义临时变量
            //用于存储当前索引范围内最小值的索引
            int minIndex;

            //遍历数组
            //依次找出范围内的最小值的索引
            //再进行换位
            //即使已排序
            //依旧进行换位
            for (int loc = 0; loc < ArrayInteger.Length; loc++)
            {
                minIndex = minLocation(loc, ArrayInteger.Length - 1);
                swap(loc, minIndex);
            }
        }

        #endregion

        #region 插入排序

        /// <summary>
        /// 插入排序
        /// </summary>
        public void insertionSort()
        {
            //用于暂存需要移动变量的值
            int temp;

            //用于暂存需要移动变量的索引值
            int location;

            //遍历整个数组表
            //如果发现当前有未排序的值
            //进行排序
            for (int unsortedIndex = 1; unsortedIndex < ArrayInteger.Length; unsortedIndex++)
            {
                //如果当前的索引值比前一个索引的值小
                if (ArrayInteger[unsortedIndex].CompareTo(ArrayInteger[unsortedIndex - 1]) < 0)
                {
                    //记下这个值和这个值对应的索引
                    temp = ArrayInteger[unsortedIndex];
                    location = unsortedIndex;

                    //第一步：先将在location索引的值赋给比location-1索引上
                    //第二步：location减去1
                    //第三部：如果location仍然大于0并且(location-1)上的值比记录的值大
                    //返回至第一步
                    //否则跳出循环，在当前location索引的位置上赋给记录的值
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

        #region 快速排序

        /// <summary>
        /// 提取数组表中的中间位置的值并与表的第一个值交换位置
        /// 将表划分为下层子表和上层子表
        /// 下层子表用于存储小于中间位置值的数据
        /// 上层子表用于存储大于中间位置值的数据
        /// 返回中间值的索引
        /// </summary>
        /// <param name="first">数组开始索引</param>
        /// <param name="last">数组结束索引</param>
        /// <returns>中间位置索引</returns>
        private int partiton(int first, int last)
        {
            //下层子表中最后一个元素位置的索引
            int smallIndex;

            //算得first和last中间索引
            //并将中间位置的值与第一位置的值调换
            swap(first, (first + last) / 2);

            //初始化值为一开始的位置
            smallIndex = first;

            //遍历first和last之间的数组元素
            //如果当前的元素小于第一个元素（即中间位置的值）
            //下层子表中最后一个元素位置的索引+1
            //交换smallIndex与index位置的值
            for (int index = first + 1; index <= last; index++)
            {
                if (ArrayInteger[index].CompareTo(ArrayInteger[first]) < 0)
                {
                    smallIndex++;
                    swap(smallIndex, index);
                }
            }

            //遍历完毕
            //将中间值恢复原位
            swap(first, smallIndex);

            //返回下层子表中最后一个元素位置的索引
            //即中间位置索引
            return smallIndex;
        }

        /// <summary>
        /// 采用递归的方法进行排序
        /// </summary>
        /// <param name="first">数组开始索引</param>
        /// <param name="last">数组结束索引</param>
        private void recQuickSort(int first, int last)
        {
            //中间值索引
            int pivotLocation;

            //如果开始索引小于结束索引
            //进行划分排序
            //直至first=last
            if (first < last)
            {
                pivotLocation = partiton(first, last);
                recQuickSort(first, pivotLocation - 1);
                recQuickSort(pivotLocation + 1, last);
            }
        }

        /// <summary>
        /// 快速排序    
        /// </summary>
        public void quickSort()
        {
            recQuickSort(0, ArrayInteger.Length - 1);
        }

        #endregion

        #region 堆 排 序

        /// <summary>
        /// 在每次遍历循环时为一个数据项赋值
        /// 从而在子树中恢复堆
        /// 表的根节点索引以及表中最后一个元素的索引
        /// 作为参数传递给该方法
        /// </summary>
        /// <param name="low">根节点索引</param>
        /// <param name="high">最后一个元素的索引</param>
        private void heapify(int low, int high)
        {
            //拷贝根节点的值至temp
            int temp = ArrayInteger[low];

            //索引至左边的树子节点
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
        /// 堆排序
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
        /// 输出数组中的值
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
