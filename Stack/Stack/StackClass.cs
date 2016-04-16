using System;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    class StackClass
    {
        private int maxStackSize;
        private int stackTop;
        private string[] list;

        public StackClass()
        {
            maxStackSize = 100;
            stackTop = 0;
            list = new string[maxStackSize];
        }

        public StackClass(int stackSize)
        {
            if (stackSize <= 0)
            {
                Console.WriteLine("The size of the array to implement the stack must be positive.");
                Console.WriteLine("Creating an array of size 100.");

                maxStackSize = 100;
            }
            else
                maxStackSize = stackSize;

            stackTop = 0;
            list = new string[maxStackSize];
        }

        public StackClass(StackClass otherStack)
        {
            copy(otherStack);
        }

        public void initializeStack()
        {
            for (int i = 0; i < stackTop; i++)
                list[i] = null;

            stackTop = 0;
        }

        public bool isEmptyStack()
        {
            return (stackTop == 0);
        }

        public bool isFullStack()
        {
            return (stackTop == maxStackSize);
        }

        public void push(string newItem)
        {
            if (isFullStack())
                throw new StackOverflowException();

            list[stackTop] = newItem;
            stackTop++;
        }

        public string top()
        {
            if (isEmptyStack())
                throw new StackOverflowException();

            return list[stackTop - 1];
        }

        public void pop()
        {
            if (isEmptyStack())
                throw new StackOverflowException();

            stackTop--;
            list[stackTop] = null;
        }

        private void copy(StackClass otherStack)
        {
            list = null;

            maxStackSize = otherStack.maxStackSize;
            stackTop = otherStack.stackTop;

            list = new string[maxStackSize];

            for (int i = 0; i < stackTop; i++)
                list[i] = otherStack.list[i];
        }

        public void copyStack(StackClass otherStack)
        {
            if (this != otherStack)
                copy(otherStack);
        }
    }
}
