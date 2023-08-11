namespace Primos
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % i == 0 && i % 1 == 0 && i % 2 != 0 && i % 3 != 0 && i % 5 != 0 && i % 7 != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}