namespace Filas
{
    class Program
    {
        static void Main(string[] args)
        {
            char fila = '*';
            Console.WriteLine("Introduzca el número de filas que quiera imprimir: ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < i + 1; j++)
                    {
                        Console.Write(fila);
                        // write the biggest number of n in the center of the screen
                    }
                    Console.WriteLine();

                }
                if (n % 2 != 0)
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 1; j <= n - i; j++)
                            Console.Write(" ");
                        for (int j = 1; j <= 2 * i - 1; j++)
                            Console.Write("*");
                        Console.Write("\n");
                    }
                }
                else
                {
                    Console.WriteLine("El número de filas debe ser mayor que 0");
                }

            }
        }
    }
}