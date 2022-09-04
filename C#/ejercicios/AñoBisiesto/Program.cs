namespace Años
{
    class AñoBisiesto
    {
        public static void Main(string[] args)
        {
            int año;
            char option;
            Console.WriteLine("Ingrese una opción:\n1. Verificar si es bisiesto\n2. Años bisiestos de 1800 al año actual \n3. Salir del programa\n");
            option = char.Parse(Console.ReadLine());
            while (true)
            {
                switch (option)
                {
                    case '1':
                        Console.WriteLine("Ingrese un año: ");
                        año = int.Parse(Console.ReadLine());
                        if (año % 4 == 0 && año % 100 != 0 || año % 400 == 0)
                        {
                            Console.WriteLine("El año es bisiesto");
                        }
                        else
                        {
                            Console.WriteLine("El año no es bisiesto");
                        }
                        break;
                    case '2':
                        for (int i = 1800; i <= DateTime.Now.Year; i++)
                        {
                            if (i % 4 == 0 && i % 100 != 0 || i % 400 == 0)
                            {
                                Console.WriteLine($"{i} es bisiesto");
                            }
                        }
                        break;
                    case '3':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
                Console.WriteLine("\nIngrese una opción:\n1. Verificar si es bisiesto\n2. Años bisiestos de 1800 al año actual \n3. Salir del programa\n");
                option = char.Parse(Console.ReadLine());
            }
        }
    }
}