using System;
namespace TwoStones
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numero_piedras = int.Parse(Console.ReadLine());
            if (numero_piedras % 2 == 0)
            {
                Console.WriteLine("Bob");
            }
            else
            {
                Console.WriteLine("Alice");
            }
        }
    }
}