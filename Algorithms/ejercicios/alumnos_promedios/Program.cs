namespace Alumnospromedios
{
    class Program
    {
        static void Main(string[] args)
        {
            int alumnos;
            float promedio = 0, suma = 0, calificacion, suma_grupal = 0;
            Console.Write("Ingrese el numero de alumnos: ");
            alumnos = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= alumnos; i++)
            {

                Console.Write("\nIngrese el nombre del alumno: ");
                string nombre = Console.ReadLine();
                Console.Write("\nIngrese las materias tienes: ");
                int materias = Convert.ToInt32(Console.ReadLine());
                for (int j = 0; j < materias; j++)
                {
                    Console.Write("\nIngrese la calificacion de la materia: ");
                    calificacion = float.Parse(Console.ReadLine());
                    if (calificacion >= 0 && calificacion <= 10)
                    {
                        suma += calificacion;
                        promedio = suma / materias;
                    }
                    else
                    {
                        Console.WriteLine("La calificacion no es valida");
                        break;
                    }
                }


                Console.WriteLine($"\n\nEl promedio del alumno {nombre} es: {promedio}");
                Console.WriteLine($"\nEl promedio grupal es: {suma_grupal += (suma / materias) / (alumnos)}");
                // el alumno con el mejor promedio

                if (promedio >= suma_grupal / (alumnos)) // Si el promedio del alumno es mayor o igual al promedio grupal
                {
                    Console.WriteLine($"El mejor alumno es {nombre} con un promedio de {promedio}");
                }
                else
                {
                    Console.WriteLine("\nNo hay ningun alumno con mejor promedio");
                }
                if (promedio < suma_grupal / (alumnos)) // Si el promedio del alumno es menor al promedio grupal
                {
                    Console.WriteLine($"El peor alumno es {nombre} con un promedio de {promedio}");
                }
                else
                {
                    Console.WriteLine("\nNo hay ningun alumno con peor promedio");
                }
                // reset de variables para que no se acumulen
                suma = 0;
                promedio = 0;

            }
        }
    }
}