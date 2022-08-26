namespace Ecuacion
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, x1, x2;
            Console.WriteLine("Ingrese el valor de a");
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ingrese el valor de b");
            b = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el valor de c");
            c = double.Parse(Console.ReadLine());
            if (Math.Sqrt(b * b - 4 * a * c) > 0)
            {
                x1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                x2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                Console.WriteLine($"x1 = {x1}\nx2 = {x2}");
            }
            else if (Math.Sqrt(b * b - 4 * a * c) > 0)
            {
                x1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                Console.WriteLine($"x1 = {x1}");
            }
            else
            {
                Console.WriteLine("No tiene solucion");
            }

        }
    }
}