using System;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = 0;

            while (number <= 5)
            {
                number++;
                if (number % 2 == 0)
                {
                    Console.WriteLine($"{number} is even.");
                }
                else
                {
                    Console.WriteLine($"{number} is odd.");
                }
            }
        }
    }
}