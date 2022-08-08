using System;

namespace Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            float height, width;
            Console.Write("Enter the height of the rectangle: ");
            height = float.Parse(Console.ReadLine());
            Console.Write("Enter the width of the rectangle: ");
            width = float.Parse(Console.ReadLine());
            Console.WriteLine($"The area of the rectangle is {height * width}");
        }
    }
}