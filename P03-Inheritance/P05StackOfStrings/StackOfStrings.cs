using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        Stack<string> stack = new Stack<string>();
        public bool IsEmpty()
        {
            return this.Count == 0;
        }
        public Stack<string> AddRange(IEnumerable<string> elemennts)
        {
            foreach (var item in elemennts)
            {
                this.Push(item);
            }
            return this;
        }
    }
}
