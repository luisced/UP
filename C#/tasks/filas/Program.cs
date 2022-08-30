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
                        Console.Write(fila + " ");
                    }
                    Console.WriteLine();

                }
                if (n % 2 != 0)
                {
                    for (int i = 0; i <= n; i++)
                    /*
                    1. Empezar desde i = 0 hasta n (número de filas) para imprimir la primer fila
                    2. Se itera hasta n y se incrementa i en 1 para imprimir la linea siguiente
                    */
                    {
                        for (int x = n; x > i; x--)
                        /*
                        3. Se itera desde n hasta i y se decrementa x en 1 para dar un espaciado
                        4. Se imprime un espacio, conforme se decrementa x en 1
                        */
                        {
                            Console.Write(" ");
                        }
                        for (int j = 1; j <= i; j++)
                        /*
                        5. Se itera desde 1 hasta i y se incrementa j en 1 para imprimir la fila
                        6. Se imprime un asterisco, conforme se incrementa j en 1 y se concatena con el espacio
                        */
                        {
                            Console.Write(" " + "*");

                        }
                        // 7. Por cada iteracion se imprime una linea
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("El número de filas debe ser inpar");
                }

            }
        }
    }
}