namespace Examen4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] compras;
            double[] usuarios;
            int puntos = 0;
            Console.WriteLine("Ingrese el numero de compras");
            int n = Convert.ToInt32(Console.ReadLine());

            compras = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Ingrese el valor de la compra: " + (i + 1));
                compras[i] = Convert.ToInt32(Console.ReadLine());
                if (compras[i] >= 100)
                {
                    puntos = puntos + 10;
                }
            }
            Console.WriteLine("El numero de puntos es: " + puntos);

            // 2.
            Console.WriteLine("Ingrese su edad");
            int edad = Convert.ToInt32(Console.ReadLine());
            seguroMedico(edad);

            // 3.
            Console.WriteLine("Ingrese el numero de usuarios");
            int numero_usuarios = Convert.ToInt32(Console.ReadLine());
            usuarios = new double[numero_usuarios];

            // calificaciones por usuario
            for (int i = 0; i < numero_usuarios; i++)
            {
                Console.WriteLine("Ingrese el numero de calificaciones del usuario: " + (i + 1));
                int numero_calificaciones = Convert.ToInt32(Console.ReadLine());
                int[] calificaciones = new int[numero_calificaciones];
                for (int j = 0; j < numero_calificaciones; j++)
                {
                    Console.WriteLine("Ingrese la calificacion: " + (j + 1));
                    calificaciones[j] = Convert.ToInt32(Console.ReadLine());
                }
                usuarios[i] = promedio(calificaciones);
                Console.WriteLine("El promedio del usuario " + (i + 1) + " es: " + usuarios[i]);
            }




        }

        static void seguroMedico(int edad)
        {
            int precio_seguro = 0;
            if (edad <= 50)
            {
                precio_seguro = 10000;
            }
            else if (edad > 50)
            {
                precio_seguro = 20000;
            }
            Console.WriteLine("Con" + edad + "años el precio del seguro es: " + precio_seguro);
        }

        static double promedio(int[] calificaciones)
        {
            double promedio = 0;
            for (int i = 0; i < calificaciones.Length; i++)
            {
                promedio = promedio + calificaciones[i];
            }
            promedio = promedio / calificaciones.Length;
            return promedio;
        }

    }
}