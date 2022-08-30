namespace Filas
{
    class Program
    {
        static void Main(string[] args)
        {
            char fila = '*';
            int n;
            char option;
            // change de color of the console to blue
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Ingrese una opción:\n1. Número de filas\n2. Pirámide \n3. Rombo\n4.Salir del programa\n");
            option = Convert.ToChar(Console.ReadLine());


            while (true || n > 0)
            {
                switch (option)
                {
                    case '1':
                        Console.WriteLine("Ingrese un número de filas: ");
                        n = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < i + 1; j++)
                            {
                                Console.Write(fila + " ");
                            }
                            Console.WriteLine();

                        }
                        break;
                    case '2':
                        Console.WriteLine("Ingrese un número inpar de filas: ");
                        n = Convert.ToInt32(Console.ReadLine());
                        if (n % 2 != 0)
                        { //altura
                            for (int i = 0; i <= n; i++)
                            /*
                            1. Empezar desde i = 0 hasta n (número de filas) para imprimir la primer fila
                            2. Se itera hasta n y se incrementa i en 1 para imprimir la linea siguiente
                            */
                            {
                                //forma de piramide
                                for (int x = n; x > i; x--)
                                /*
                                3. Se itera desde n hasta i y se decrementa x en 1 para dar un espaciado
                                4. Se imprime un espacio antes de cada asterisco, conforme se decrementa x en 1
                                */
                                {
                                    Console.Write(" ");
                                }
                                //ancho
                                for (int j = 1; j <= i; j++)
                                /*
                                5. Se itera desde 1 hasta i y se incrementa j en 1 para imprimir la fila
                                6. Se imprime un asterisco, conforme se incrementa j en 1 y se concatena con el espacio
                                */
                                {
                                    Console.Write(" " + "*");

                                }
                                // 7. Por cada iteracion se imprime un salto de linea
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ingrese un número inpar");
                        }
                        break;
                    case '3':
                        Console.WriteLine("Ingrese un número par de filas: ");
                        n = Convert.ToInt32(Console.ReadLine());
                        if (n % 2 == 0)
                        {
                            for (int i = 0; i < (n / 2); i++)
                            {
                                for (int j = 0; j < n - i; j++)
                                {
                                    Console.Write(" ");
                                }
                                for (int j = 0; j < 2 * i + 1; j++)
                                {
                                    Console.Write("*");
                                }
                                Console.WriteLine();
                            }
                            for (int i = (n / 2) - 1; i >= 0; i--)
                            {
                                for (int j = 0; j < n - i; j++)
                                {
                                    Console.Write(" ");
                                }
                                for (int j = 0; j < 2 * i + 1; j++)
                                {
                                    Console.Write("*");
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ingrese un número par");
                        }
                        break;
                    case '4':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;


                }
                Console.WriteLine("\nIngrese una opción:\n1. Número de filas\n2. Pirámide \n3. Rombo\n4.Salir del programa\n");
                option = Convert.ToChar(Console.ReadLine());
            }

        }
    }
}