namespace Reciproco
{
    class Program
    {
        static void Main(string[] args)
        {
            // int n = 1;
            // double resultado = 0;
            // while (resultado <= 2)
            // {
            //     n++;
            //     if (n % 2 == 0)
            //     {
            //         resultado += 1.0 / n;
            //         Console.Write($"+ 1/{n} ");
            //     }

            // }
            // Console.WriteLine($" = {(int)resultado}");
            Reciproco2();
        }

        static void Reciproco2()
        {
            // print - + sign
            for (int i = 1; i <= 32; i *= 2)
            {
                Console.Write($"1/{i}");
            }
            Console.WriteLine();
            // alternate + - sign
            for (int i = 1; i <= 32; i *= 2)
            {
                Console.Write($"1/{i}");
                if (i < 32)
                {
                    Console.Write(" - ");
                    Console.Write("+");
                }
            }
            Console.WriteLine();


        }
    }
}