namespace Veterinaria
{
    class Program
    {
        //En un hospital veterinario se esta realizando una investigación en un tema de endocrinología en mascotas y se desea llevar un control de la masa corporal  de los pacientes .Esta se calcula a partir de su altura (entre 20 y 70cms) 
        // y su peso (entre 6 y 60 kgs). Masa corporal=estatura*peso.
        // Diseñe un programa que se encargue de leer la altura y el peso y guardar la masa corporal y el nombre de cada mascota .Al principio del programa se puede averiguar la cantidad de mascotas registradas .
        // Se desea obtener como resultado (en un submenú)el promedio general de masa corporal, así como encontrar la masa corporal y el nombre de las cuatro mascotas con mayor masa corporal.
        // El programa debe tener un menú principal que incluya las opciones de :
        // Entrada de datos 
        // Resultados 
        // Terminar 
        // Y un submenú que incluya las opciones de 
        // Promedio general de masa corporal
        // Datos de las cuatro mascotas con mayor masa 
        // Terminar


        public struct Mascota
        {
            public string nombre;
            public double estatura;
            public double peso;
            public double masa;
        }
        static Mascota[] mascotas;
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Ingrese la cantidad de mascotas");
            int cantidadMascotas = Convert.ToInt32(Console.ReadLine());
            mascotas = new Mascota[cantidadMascotas];
            Menu();

        }
        static double MasaCorporal(double estatura, double peso)
        {
            return estatura * peso;
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1. Entrada de datos");
            Console.WriteLine("2. Resultados");
            Console.WriteLine("3. Terminar");
            int opcion = Convert.ToInt32(Console.ReadLine());
            while (opcion != 3)
            {
                switch (opcion)
                {
                    case 1:
                        CrearMascota();
                        break;
                    case 2:
                        Resultados();
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
                Console.WriteLine("1. Entrada de datos");
                Console.WriteLine("2. Resultados");
                Console.WriteLine("3. Terminar");
                opcion = Convert.ToInt32(Console.ReadLine());
            }
        }

        static Mascota CrearMascota()
        {
            Mascota mascota = new Mascota();

            Console.Clear();
            for (int i = 0; i < mascotas.Length; i++)
            {
                Console.Write("Ingrese el nombre de la mascota: ");
                mascota.nombre = Console.ReadLine();
                Console.Write("Ingrese la estatura de la mascota: ");
                while (true)
                {
                    if (double.TryParse(Console.ReadLine(), out double estatura))
                    {
                        if (estatura >= 20 && estatura <= 70)
                        {
                            mascota.estatura = estatura;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("La estatura debe estar entre 20 y 70 cms");
                        }
                    }
                    else
                    {
                        Console.WriteLine("La estatura debe ser un número");
                    }
                }
                Console.Write("Ingrese el peso de la mascota: ");
                while (true)
                {
                    if (double.TryParse(Console.ReadLine(), out double peso))
                    {
                        if (peso >= 6 && peso <= 60)
                        {
                            mascota.peso = peso;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("El peso debe estar entre 6 y 60 kgs");
                        }
                    }
                    else
                    {
                        Console.WriteLine("El peso debe ser un número");
                    }
                }
                mascota.masa = MasaCorporal(mascota.estatura, mascota.peso);
                mascotas[i] = mascota;
            }

            return mascota;
        }
        static void Resultados()
        {
            Console.Clear();
            Console.WriteLine("1. Promedio general de masa corporal");
            Console.WriteLine("2. Datos de las cuatro mascotas con mayor masa");
            Console.WriteLine("3. Terminar");
            int opcion = Convert.ToInt32(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    PromedioGeneral();
                    break;
                case 2:
                    MascotasMayorMasa();
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }

        static void PromedioGeneral()
        {
            double suma = 0;
            foreach (Mascota mascota in mascotas)
            {
                suma += mascota.masa;
            }
            double promedio = suma / mascotas.Length;
            Console.WriteLine($"El promedio general de masa corporal es {promedio}");
        }
        static void MascotasMayorMasa()
        {
            Console.Clear();
            Mascota[] mascotasOrdenadas = mascotas.OrderBy(mascota => mascota.masa).ToArray();
            for (int i = mascotasOrdenadas.Length - 1; i >= mascotasOrdenadas.Length - 4; i--)
            {
                Console.WriteLine($"Nombre: {mascotasOrdenadas[i].nombre} Masa corporal: {mascotasOrdenadas[i].masa}");
            }
        }


    }
}