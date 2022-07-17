namespace P05PlayCatch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static int countInvalidCommands = 0;
        static void Main(string[] args)
        {
            
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            int counOfInput = input.Count;
            //int countInvalidCommands = 0;
            while (countInvalidCommands < 3)
            {
                string[] commandArgs = Console.ReadLine().Split();
                string command = commandArgs[0];
                int number;
                try
                {
                    if (command == "Replace")
                    {
                        IsValidInteger(commandArgs[1]);
                        IsValidInteger(commandArgs[2]);
                        int index = int.Parse(commandArgs[1]);
                        IsValidIndex(counOfInput, index);
                        input[index] = int.Parse(commandArgs[2]);
                    }
                    else if (command == "Show")
                    {
                        IsValidInteger(commandArgs[1]);
                        int index = int.Parse(commandArgs[1]);
                        IsValidIndex(counOfInput, index);
                        Console.WriteLine(input[index]);
                    }
                    else if(command == "Print")
                    {
                        IsValidInteger(commandArgs[1]);
                        IsValidInteger(commandArgs[2]);
                        int startIndex = int.Parse(commandArgs[1]);
                        int endIndex = int.Parse(commandArgs[2]);
                        IsValidIndex(counOfInput, startIndex);
                        IsValidIndex(counOfInput, endIndex);
                        Console.WriteLine(string.Join(", ", input.Skip(startIndex).SkipLast(counOfInput - endIndex - 1)));
                    }
                    else
                    {
                        countInvalidCommands++;
                        throw new ArgumentException("Invalid command!");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(string.Join(", ", input));
        }

        public static void IsValidInteger(string number)
        {
            if (!int.TryParse(number, out _))
            {
                countInvalidCommands++;
                throw new ArgumentException("The variable is not in the correct format!");
            }
        }

        public static void IsValidIndex(int countOfInput, int index)
        {
            if (index < 0 || index >= countOfInput)
            {
                countInvalidCommands++;
                throw new ArgumentException("The index does not exist!");
            }
        }
    }
}
