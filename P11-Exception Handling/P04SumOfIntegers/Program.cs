namespace P04SumOfIntegers
{
    using System;
    using System.Text.RegularExpressions;

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputData = Console.ReadLine().Split();
            long sum = 0;
            foreach (var input in inputData)
            {
                try
                {
                    sum += SumIntegers(input, sum);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine($"Element '{input}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }

        private static int SumIntegers(string input, long sum)
        {
            if (!Regex.IsMatch(input, @"^[-]?[0-9]+$"))
            {
                throw new ArgumentException($"The element '{input}' is in wrong format!");
            }

            int inputInt;
            bool isInteger = int.TryParse(input, out inputInt);
            if (!isInteger)
            {
                throw new ArgumentException($"The element '{input}' is out of range!");
            }

            return inputInt;
            
        }
    }
}
