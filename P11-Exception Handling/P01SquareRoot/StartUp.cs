namespace P01SquareRoot
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                
                Console.WriteLine(Sqrt((double)number));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }

        public static double Sqrt(double number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Invalid number.");
            }
            return Math.Sqrt(number);
        }
    }
}
