using System;
using System.Collections.Generic;
using System.Text;

namespace Maximum
{
    class Program
    {
        static int largest(int[] list, int lowerIndex, int upperIndex)
        {
            int max;

            if (lowerIndex == upperIndex)
            {
                return list[lowerIndex];
            }
            else
            {
                max = largest(list, lowerIndex + 1, upperIndex);

                if (list[lowerIndex] >= max)
                    return list[lowerIndex];
                else
                    return max;
            }
        }

        static void Main(string[] args)
        {
            int[] list ={ 1, 3, 5, 4, 2 };
            Console.WriteLine(largest(list, 0, list.Length - 1));
        }
    }
}
