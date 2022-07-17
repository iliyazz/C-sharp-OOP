namespace P02EnterNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            const int LoopNumber = 10;
            const  int EndOfRange = 100;
            int start = 1;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < LoopNumber; i++)
            {
                try
                {
                    ReadNumber(start, EndOfRange, stack);
                    start = stack.Peek();
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }

            Console.WriteLine(string.Join(", ", stack.Reverse()));
        }

        static void ReadNumber(int start, int EndOfRange, Stack<int> stack)
        {
            string inputStr = Console.ReadLine();
            int inputInt;
            bool isNumber = int.TryParse(inputStr, out inputInt);
            if (!isNumber)
            {
                throw new ArgumentException("Invalid Number!");
            }
            else if (inputInt <= start || inputInt > EndOfRange)
            {
                 throw new ArgumentException($"Your number is not in range {start} - 100!");
            }
            stack.Push(inputInt);
        }
    }
}
