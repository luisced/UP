namespace Materias
{
    class Program
    {
        struct Materia
        {
            public string nombre;
            public double promedio;
            public Actividad[] actividades;

        }
        static Materia[] materias;
        struct Actividad
        {
            public int id;
            public double calificacion;
        }
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("¿Cuantas materias tienes?");
            int num_materias = int.Parse(Console.ReadLine());
            materias = new Materia[num_materias];
            Console.Clear();
            // Menú
            Console.WriteLine("1. Agregar materias\n2. Agregar actividades \n3. Ver tabla de materias\n4. Ver detalles de materia\n5. Salir");
            int opcion = int.Parse(Console.ReadLine());
            while (opcion != 5)
            {
                switch (opcion)
                {
                    case 1:
                        for (int i = 0; i < num_materias; i++) { materias[i] = CrearMateria(); }
                        break;
                    case 2:
                        AgregarActividades();
                        break;
                    case 3:
                        VerTablaMaterias();
                        break;
                    case 4:
                        VerDetallesMateria();
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
                Console.WriteLine("1. Agregar materias\n2. Agregar actividades \n3. Ver tabla de materias\n4. Ver detalles de materia\n5. Salir");
                opcion = int.Parse(Console.ReadLine());
            }

        }
        static Materia CrearMateria()
        {
            Materia materia = new Materia();
            Console.WriteLine("Nombre de la materia: ");
            materia.nombre = Console.ReadLine();

            return materia;

        }
        static void VerTablaMaterias()
        {
            Console.WriteLine("Materias");
            Console.WriteLine("Nombre\t\tCalificacion");
            foreach (Materia materia in materias)
            {
                if (materia.nombre != null)
                {
                    Console.WriteLine(materia.nombre + "\t\t" + materia.promedio);
                }
                else
                {
                    Console.WriteLine("No hay materias");
                }
            }
        }
        static Actividad AgregarActividades()
        {
            // crear actividad y agregarla a la materia
            Actividad actividad = new Actividad();
            Console.WriteLine("¿A qué materia le quieres agregar una actividad?");
            int index = Array.FindIndex(materias, m => m.nombre == Console.ReadLine());
            if (index != -1)
            {
                Console.WriteLine("¿Cuántas materias deseas agregar?");
                int num_actividades = int.Parse(Console.ReadLine());
                materias[index].actividades = new Actividad[num_actividades];
                for (int i = 0; i < num_actividades; i++)
                {
                    actividad.id = i + 1;
                    Console.Write($"Calificación de la actividad {i + 1}: ");
                    actividad.calificacion = double.Parse(Console.ReadLine());
                    materias[index].actividades[i] = actividad;
                    materias[index].promedio = CalcularPromedio(materias[index].actividades);
                }
            }
            else
            {
                Console.WriteLine("No existe la materia");
            }
            return actividad;
        }
        static double CalcularPromedio(Actividad[] actividades)
        {
            double promedio = 0;
            foreach (Actividad actividad in actividades)
            {
                promedio += actividad.calificacion;
            }
            promedio /= actividades.Length;
            return promedio;
        }

        static void VerDetallesMateria()
        {
            Console.Write("Ingrese el nombre de la materia: ");
            int index = Array.FindIndex(materias, m => m.nombre == Console.ReadLine());
            if (index != -1)
            {
                Console.WriteLine($"Materia: {materias[index].nombre}\nCalificación: {materias[index].promedio}");
                Console.WriteLine("Actividades:");
                foreach (Actividad actividad in materias[index].actividades)
                {
                    Console.WriteLine($"\tActividad {actividad.id}: {actividad.calificacion}");
                }

            }
            else
            {
                Console.WriteLine("La materia no existe");
            }
        }
    }
}