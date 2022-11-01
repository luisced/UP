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
            Menu();

        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1.- Agregar Materia\n2.- Agregar Actividad a Materias\n3.- Ver tabla de materias\n4.- Ver Materia\n5.-Salir");
            int opcion = Convert.ToInt32(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Materia materia = new Materia();

                    for (int i = 0; i > materias.Length; i++)
                    {
                        materia = AgregarMateria();
                        materias = new Materia[materias.Length + 1];
                    }
                    break;
                case 2:
                    // AgregarActividad();
                    break;
                case 3:
                    // VerTablaMaterias();
                    break;
                case 4:
                    // VerMateria();
                    break;
                case 5:
                    break;
            }
        }

        static Materia AgregarMateria()
        {
            Materia materia = new Materia();
            Console.Write($"Ingrese el nombre de la materia: ");
            materia.nombre = Console.ReadLine();
            return materia;


        }
    }
}