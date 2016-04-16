using System;
using System.Collections.Generic;
using System.Text;

namespace OrderedAlgorithm
{
    class ArraySort
    {
        private int[] iArrayInt;

        public ArraySort()
        {
            iArrayInt = new int[] { 3, 1, 2, 4 };
        }

        public ArraySort(int[] otherArray)
        {
            iArrayInt = otherArray;
        }

        #region selectionSort

        private int minLocation(int first, int last)
        {
            int loc, minIndex;
            minIndex = first;

            for (loc = first + 1; loc <= last; loc++)
            {
                if (iArrayInt[loc].CompareTo(iArrayInt[minIndex]) < 0)
                    minIndex = loc;
            }

            return minIndex;
        }//end minLocation

        private void swap(int first, int second)
        {
            int temp;

            temp = iArrayInt[first];
            iArrayInt[first] = iArrayInt[second];
            iArrayInt[second] = temp;
        }//end swap

        public void selectionSort()
        {
            int loc, minIndex;

            for (loc = 0; loc < iArrayInt.Length - 1; loc++)
            {
                minIndex = minLocation(loc, iArrayInt.Length - 1);
                swap(loc, minIndex);
            }
        }//end selectionSort

        #endregion

        #region insertSort

        public void insertionSort()
        {
            int unsortedIndex, location;
            int temp;

            for (unsortedIndex = 1; unsortedIndex < iArrayInt.Length; unsortedIndex++)
            {
                if (iArrayInt[unsortedIndex].CompareTo(iArrayInt[unsortedIndex - 1]) < 0)
                {
                    temp = iArrayInt[unsortedIndex];
                    location = unsortedIndex;

                    do
                    {
                        iArrayInt[location] = iArrayInt[location - 1];
                        location--;
                    }
                    while (location > 0 && iArrayInt[location - 1].CompareTo(temp) > 0);

                    iArrayInt[location] = temp;
                }//end if
            }//end for
        }//end insertionSort

        #endregion insertionSort

        #region quickSort

        private int partition(int first, int last)
        {
            int pivot;

            int index, smallindex;

            swap(first, (first + last) / 2);

            pivot = iArrayInt[first];
            smallindex = first;

            for (index = first + 1; index <= last; index++)
            {
                if (iArrayInt[index].CompareTo(pivot) < 0)
                {
                    smallindex++;
                    swap(smallindex, index);
                }//end if
            }//end for
            swap(first, smallindex);

            return smallindex;
        }//end partition

        private void recQuickSort(int first, int last)
        {
            int pivotLocation;

            if (first < last)
            {
                pivotLocation = partition(first, last);
                recQuickSort(first, pivotLocation - 1);
                recQuickSort(pivotLocation + 1, last);
            }//end if
        }//end recQuickSort

        public void quickSort()
        {
            recQuickSort(0, iArrayInt.Length - 1);
        }//end quickSort

        #endregion

        public void Print()
        {
            foreach (int i in iArrayInt)
            {
                Console.Write(i.ToString() + ",");
            }

            Console.WriteLine("");
        }
    }
}
