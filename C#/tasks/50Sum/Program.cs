namespace FiftySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            foreach (int number in Enumerable.Range(1, 50))
            {
                sum += number;
            }
            Console.WriteLine($"La suma de los primeros 50 números es {sum} y su promedio es: {n / 50}");
        }
    }
}

