namespace Reciproco
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1;
            double resultado = 0;
            while (resultado <= 2)
            {
                n++;
                if (n % 2 == 0)
                {
                    resultado += 1.0 / n;
                    Console.Write($"+ 1/{n} ");
                }

            }
            Console.WriteLine($" = {(int)resultado}");
        }
    }
}