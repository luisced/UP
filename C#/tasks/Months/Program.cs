using System;

namespace Months
{
    class Program
    {
        static void Main(string[] args)
        {
            var months = new Dictionary<int, string>()
            {
                {1, "January"},
                {2, "February"},
                {3, "March"},
                {4, "April"},
                {5, "May"},
                {6, "June"},
                {7, "July"},
                {8, "August"},
                {9, "September"},
                {10, "October"},
                {11, "November"},
                {12, "December"}
            };
            Console.WriteLine("Enter a number between 1 and 12: ");
            var number = int.Parse(Console.ReadLine());
            Console.WriteLine($"{number} is {months[number]}.");

        }
    }
}