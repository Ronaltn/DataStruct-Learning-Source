using System;
using System.Collections.Generic;
using System.Text;

namespace IsBackWord
{
    class Program
    {
        static void Judege(string inword,string backword, int index)
        {
            if (inword.Length == backword.Length)
            {
                if (inword == backword)
                    Console.WriteLine("Yes,it is backword.");
                else
                    Console.WriteLine("No,it's not backword");

                return;
            }

            backword += inword[index];
            Judege(inword, backword, index - 1);
        }

        static void Main(string[] args)
        {
            Console.Write("Please input one word by keyboard : ");
            string word = Console.ReadLine();
            Judege(word, "", word.Length - 1);
        }
    }
}
