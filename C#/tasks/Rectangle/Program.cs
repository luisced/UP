using System;

namespace Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal height, width;
            Console.Write("Enter the height of the rectangle: ");
            height = decimal.Parse(Console.ReadLine());
            Console.Write("Enter the width of the rectangle: ");
            width = decimal.Parse(Console.ReadLine());
            var area = height * width;
            Console.WriteLine($"The area of the rectangle is {area}");
        }
    }
}