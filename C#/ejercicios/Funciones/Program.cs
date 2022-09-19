namespace Funciones
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("\n\nEliga una opción:\n1. Sacar el tercer ángulo de un triángulo.\n2. Sacar el promedio y total de 4 números\n3.Convertir de cm a km y m\n4. Convertir de km/h a mph\n5. Convertir a distintias unidades de temperatura\n6. Tablas de multiplicar de un número\n7. P, T, R\n8. Salir\nOpcion: ");
            int opcion = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                switch (opcion)
                {
                    case 1:
                        //1.  Triangulo - Angulos
                        Console.WriteLine("Ingrese el primer ángulo: ");
                        double angle1 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo ángulo: ");
                        double angle2 = Convert.ToDouble(Console.ReadLine());
                        Console.Write($"El tercer ángulo del triángulo es:  {TercerAngulo(angle1, angle2)}");
                        break;
                    // 2. Promedio y total de 4 números
                    case 2:
                        Console.WriteLine("Ingrese 4 números separados por un espacio: ");
                        double[] numeros = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
                        Console.WriteLine($"El promedio es: {Promedio(numeros[0], numeros[1], numeros[2], numeros[3])}, y el total es: {Total(numeros[0], numeros[1], numeros[2], numeros[3])}");
                        break;
                    case 3:
                        // 3. Convertir de cm a km y m
                        Console.WriteLine("Ingrese la cantidad de centimetros: ");
                        double cm = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"La longitud {cm} en Km es: {Kilometros(cm)}km, en M es: {metros(cm)}m");
                        break;
                    case 4:
                        // 4. Convertir de km/h a mph
                        Console.WriteLine("Ingrese la velocidad en km/h: ");
                        double kms = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"La velocidad {kms}km/h en mp/h es: {mps(kms)}mp/h");
                        break;
                    case 5:
                        // 5. Convertir a distintias unidades de temperatura
                        Console.WriteLine("\nIngrese la opcion de conversion\n1. Kelvin a Fahrenheit\n2. Kelvin a Celsius\n3. Celsius a Kelvin\n4. Celsius a Fahrenheit\n5. Fahrenheit a Kelvin\n6. Fahrenheit a Celsius\n7. Salir");
                        int opcion2 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Ingrese el numero de grados a convertir: ");
                        double numero_grados = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"El resultado es: {Degrees(numero_grados, opcion2)}");
                        break;
                    case 6:
                        // 6. Sacar tabla de multiplicar hasta el 10 de un número
                        Console.Write("\nIngrese el número entero a multiplicar: ");
                        int numero = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Las tabla de multiplicar del {numero} son: {TablaNumero(numero)}");
                        break;
                    case 8:
                        // 8. Salir
                        Console.WriteLine("Gracias por usar el programa");
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
                if (opcion == 8)
                {
                    break;
                }
                Console.Write("\n\nEliga una opción:\n1. Sacar el tercer ángulo de un triángulo.\n2. Sacar el promedio y total de 4 números\n3.Convertir de cm a km y m\n4. Convertir de km/h a mph\n5. Convertir a distintias unidades de temperatura\n6. Tablas de multiplicar de un número\n7. P, T, R\n8. Salir\nOpcion: ");
                opcion = Convert.ToInt32(Console.ReadLine());
            }




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
        // Total Funcion
        static double Total(double n1, double n2, double n3, double n4)
        {
            double total = n1 + n2 + n3 + n4;
            return total;
        }


        // Funciones de conversion de kilometros y metros
        static double Kilometros(double longitud)
        {
            double kilometros = longitud / 100000;
            return kilometros;
        }
        static double metros(double longitud)
        {
            double metros = longitud / 100;
            return metros;
        }
        static double mps(double kms)
        {
            double mps = kms / 1.609;
            return mps;
        }
        //  Funcion de conversion de grados a distintas unidades
        static double Degrees(double numero_grados, int opcion)
        {
            double resultado;
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
        // Funcion de tabla de multiplicar
        static int TablaNumero(int numero)
        {
            int resultado = 0;
            for (int i = 1; i <= 10; resultado = numero * i++, Console.WriteLine($"\n{numero} x {i - 1} = {resultado}")) ;
            return resultado;

        }

    }
}