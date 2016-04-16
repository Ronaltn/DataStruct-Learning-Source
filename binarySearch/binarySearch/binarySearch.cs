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
        /// 用while循环实现二叉树搜索
        /// </summary>
        /// <param name="seItem"></param>
        /// <returns></returns>
        public bool whileSearch(int seItem)
        {
            //定义数组的第一个元素的位置，初始位置均为0
            int first = 0;

            //定义数组的最后一个元素的位置，初始值均为数组存储元素最大量减1
            int last = items.Length - 1;

            //定义用于更迭的中间位置
            int mid = -1;

            bool found = false;

            while (first <= last && !found)
            {
                mid = (first + last) / 2;

                //如果当前获取的元素值等于所要查询的值
                //设定返回值为true
                if (items[mid].Equals(seItem))
                    found = true;
                else
                    //否则
                    //比较当前值与所要查询的值
                    //如果当前值大于所要查询的值，末位置值=当前中间值位置值减1
                    //如果当前值小于所要查询的值，末位置值=当前中间值位置值加1
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
        /// 用递归实现二叉树搜索
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
