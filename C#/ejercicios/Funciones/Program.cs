namespace Funciones
{
    class Program
    {
        static void Main(string[] args)
        {

            // //1.  Triangulo - Angulos
            // double angle1, angle2;
            // Console.WriteLine("Enter the first angle: ");
            // angle1 = double.Parse(Console.ReadLine());
            // Console.WriteLine("Enter the second angle: ");
            // angle2 = double.Parse(Console.ReadLine());
            // Console.Write($"The third angle is:  {TercerAngulo(angle1, angle2)}");

            // // 2. Promedios y suma total
            // double n1, n2, n3, n4;
            // Console.Write("Ingrese el primer numero: ");
            // n1 = double.Parse(Console.ReadLine());
            // Console.Write("Ingrese el segundo numero: ");
            // n2 = double.Parse(Console.ReadLine());
            // Console.Write("Ingrese el tercer numero: ");
            // n3 = double.Parse(Console.ReadLine());
            // Console.Write("Ingrese el cuarto numero: ");
            // n4 = double.Parse(Console.ReadLine());
            // Console.Write($"El promedio es: {Promedio(n1, n2, n3, n4)} y el total es {n1 + n2 + n3 + n4}");

            // // 3. Conversion de longitud
            // double longitudcm;
            // Console.Write("Ingrese la longitud en centimetros: ");
            // longitudcm = double.Parse(Console.ReadLine());
            // Console.WriteLine($"La longitud {longitudcm} en Km es: {Kilometros(longitudcm)}km, en M es: {metros(longitudcm)}m");

            // //4. Conversion de km/h a m/s
            // double kms;
            // Console.Write("Ingrese la velocidad en km/h: ");
            // kms = double.Parse(Console.ReadLine());
            // Console.WriteLine($"La velocidad {kms}km/h en m/s es: {mps(kms)}m/s");

            // 5. Función de un número a Kelvin a Fahrenheit, Kelvin a Celsius , Celsius a Kelvin, Celsius a Fahrenheit, Fahrenheit a Kelvin, Fahrenheit a Celsius
            double numero_grados;
            int opcion;
            Console.Write("Ingrese el numero de grados a convertir: ");
            numero_grados = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la opcion de conversion: ");
            Console.WriteLine("1. Kelvin a Fahrenheit\n2. Kelvin a Celsius\n3. Celsius a Kelvin\n4. Celsius a Fahrenheit\n5. Fahrenheit a Kelvin\n6. Fahrenheit a Celsius\n7. Salir");
            opcion = int.Parse(Console.ReadLine());
            Console.WriteLine($"El resultado es: {Degrees(numero_grados, opcion)}");
        }

        // Funcion para calcular el tercer angulo de un triangulo
        static double TercerAngulo(double a1, double a2)
        {
            return 180 - (a1 + a2);
        }
        // Promedio Funcion
        static double Promedio(double n1, double n2, double n3, double n4)
        {
            double promedio;
            promedio = (n1 + n2 + n3 + n4) / 4;
            return promedio;
        }
        // Funciones de conversion de kilometros y metros
        static double Kilometros(double longitud)
        {
            double kilometros;
            kilometros = longitud / 100000;
            return kilometros;
        }
        static double metros(double longitud)
        {
            double metros;
            metros = longitud / 100;
            return metros;
        }
        static double mps(double kms)
        {
            double mps;
            mps = kms / 1.609;
            return mps;
        }
        static double Degrees(double numero_grados, int opcion)
        {
            double resultado;
            while (true)
            {
                switch (opcion)
                {
                    case 1:
                        resultado = (numero_grados - 273.15) * (9 / 5) + 32;
                        break;
                    case 2:
                        resultado = numero_grados - 273.15;
                        break;
                    case 3:
                        resultado = numero_grados + 273.15;
                        break;
                    case 4:
                        resultado = (numero_grados - 32) * (5 / 9);
                        break;
                    case 5:
                        resultado = (numero_grados - 32) * (5 / 9) + 273.15;
                        break;
                    case 6:
                        resultado = (numero_grados - 32) * (5 / 9);
                        break;
                    case 7:
                        resultado = 0;
                        break;

                    default:
                        resultado = 0;
                        Console.WriteLine("Opcion no valida");
                        break;

                }
                return resultado;
            }

        }

    }
}