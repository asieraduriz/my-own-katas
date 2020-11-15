using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace InitialProject
{
    public class MyStack
    {
        private LinkedList<object> stack;

        public MyStack()
        {
            this.stack = new LinkedList<object>();
        }

        public object Pop()
        {
            if (stack.Count == 0) throw new EmptyStackException();
            
            object lastObject = stack.Last.Value;
            stack.RemoveLast();
            return lastObject;
        }

        public void Push(object objectContent)
        {
            stack.AddLast(objectContent);
        }
    }
}