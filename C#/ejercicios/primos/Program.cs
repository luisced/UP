namespace Primos
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % i == 0 && i % 1 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}