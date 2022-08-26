namespace Circle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el valor del radio: ");
            double radio = double.Parse(Console.ReadLine());
            Console.WriteLine($"El area del circulo es: {Math.PI * Math.Pow(radio, 2)} y el perimetro es: {2 * Math.PI * radio}");
        }
    }
}