using System;
namespace Chocolate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int rows = int.Parse(input[0]);
            int squares = int.Parse(input[1]);
            if (rows * squares % 2 == 0)
        {
            Console.WriteLine("Alf");
        }
        else
        {
            Console.WriteLine("Beata");
        }
            
        }
    }
}
