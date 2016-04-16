using System;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    class LinkedStackClass
    {
        protected class StackNode
        {
            public string info;
            public StackNode link;
        }

        private StackNode stackTop;

        public LinkedStackClass()
        {
            stackTop = null;
        }

        public void initializeStack()
        {
            stackTop = null;
        }

        public bool isEmptyStack()
        {
            return (stackTop == null);
        }

        public bool isFullStack()
        {
            return false;
        }

        public void push(string newItem)
        {
            StackNode newNode;

            newNode = new StackNode();
            newNode.info = newItem;
            newNode.link = stackTop;
            stackTop = newNode;
        }

        public string top()
        {
            if (stackTop == null)
                throw new StackOverflowException();

            return stackTop.info;
        }

        public void pop()
        {
            if (stackTop == null)
                throw new StackOverflowException();

            stackTop = stackTop.link;
        }
    }
}
