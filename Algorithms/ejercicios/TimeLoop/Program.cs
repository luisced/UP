using System;
namespace TimeLoop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            while (counter < n)
            {
                counter++;
                Console.WriteLine($"{counter} Abracadabra");
            }
        }
    }
}