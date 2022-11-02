namespace Materias
{
    class Program
    {
        struct Materia
        {
            public string nombre;
            public double calif_acumulada;
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
                        // AgregarActividades();
                        break;
                    case 3:
                        VerTablaMaterias();
                        break;
                    case 4:
                        // VerDetallesMateria();
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
                    Console.WriteLine(materia.nombre + "\t\t" + materia.calif_acumulada);
                }
                else
                {
                    Console.WriteLine("No hay materias");
                }
            }
        }
        static Actividad CrearActividad()
        {
            Actividad actividad = new Actividad();
            Console.Write("Ingrese el nombre de la materia: ");
            int index = Array.FindIndex(materias, m => m.nombre == Console.ReadLine());
            if (index != -1)
            {
                Console.Write("Ingrese el número de actividades: ");
                int num_actividades = int.Parse(Console.ReadLine());
                for (int i = 0; i < num_actividades; i++)
                {
                    Console.Write("Ingrese el nombre de la actividad: ");
                    actividad.id = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese la calificación de la actividad: ");
                    actividad.calificacion = double.Parse(Console.ReadLine());
                    materias[index].actividades[i] = actividad;
                    materias[index].calif_acumulada = (float)actividad.calificacion / num_actividades;
                }
                return actividad;
            }
            else
            {
                Console.WriteLine("La materia no existe");
                return actividad;
            }
        }
    }
}