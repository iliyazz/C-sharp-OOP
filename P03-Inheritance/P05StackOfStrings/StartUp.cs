using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>() { "word1", "word2", "word3"};
            StackOfStrings stackOfStrings = new StackOfStrings();
            Console.WriteLine(stackOfStrings.IsEmpty() );
            stackOfStrings.AddRange(list);
            Console.WriteLine(stackOfStrings.IsEmpty());
        }
    }
}
