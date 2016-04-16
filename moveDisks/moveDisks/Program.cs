using System;
using System.Collections.Generic;
using System.Text;

namespace moveDisks
{
    class Program
    {
        static void move(int count, int needle1, int needle3, int needle2)
        {
            if (count > 0)
            {
                move(count - 1, needle1, needle2, needle3);
                Console.WriteLine(string.Format("Move disk {0} from {1} to {2}.", 
                    count, needle1, needle3));
                move(count - 1, needle2, needle3, needle1);
            }
        }

        static void Main(string[] args)
        {
            move(3, 10, 0, 0);
        }
    }
}
