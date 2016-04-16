using System;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            StackClass intStack = new StackClass(50);
            StackClass tempStack = new StackClass();

            try
            {
                intStack.push("23");
                intStack.push("45");
                intStack.push("38");
            }
            catch (StackOverflowException sofe)
            {
                Console.WriteLine(sofe.Message);
                return;
            }

            tempStack.copyStack(intStack);
            while (!tempStack.isEmptyStack())
            {
                Console.Write(tempStack.top() + "  ");
                tempStack.pop();
            }
            Console.WriteLine("");

            Console.WriteLine("The top string of intStack:" + intStack.top());
        }
    }
}
