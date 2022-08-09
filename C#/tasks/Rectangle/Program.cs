namespace Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal height, width;
            Console.Write("Ingrese el valor de la altura del rectángulo en cm: ");
            height = decimal.Parse(Console.ReadLine());
            Console.Write("Ingrese el valor de la base del rectánuglo en cm: ");
            width = decimal.Parse(Console.ReadLine());
            var area = height * width;
            Console.WriteLine($"El área del rectángulo es {area} cm2");
        }
    }

}