namespace Alumnospromedios
{
    class Program
    {
        static void Main(string[] args)
        {
            int alumnos;
            Console.WriteLine("Ingrese el numero de alumnos");
            alumnos = int.Parse(Console.ReadLine());
            for (int i = 0; i < alumnos; i++)
            {
                Console.WriteLine("Ingrese el nombre del alumno");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese las materias tienes:");
                int materias = Convert.ToInt32(Console.ReadLine());
                for (int j = 0; j < materias; j++)
                {



                }
            }
        }
    }
}