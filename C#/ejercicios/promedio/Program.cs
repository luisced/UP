namespace Promedio
{
    class Program
    {
        static void Main(string[] args)
        {
            float n1, n2, n3, n4;
            Console.Write("Ingrese el primer numero: ");
            n1 = float.Parse(Console.ReadLine());
            Console.Write("Ingrese el segundo numero: ");
            n2 = float.Parse(Console.ReadLine());
            Console.Write("Ingrese el tercer numero: ");
            n3 = float.Parse(Console.ReadLine());
            Console.Write("Ingrese el cuarto numero: ");
            n4 = float.Parse(Console.ReadLine());
            Console.Write($"El promedio es: {Promedio(n1, n2, n3, n4)} y el total es {n1 + n2 + n3 + n4}");
        }
        static float Promedio(float n1, float n2, float n3, float n4)
        {
            float promedio;
            promedio = (n1 + n2 + n3 + n4) / 4;
            return promedio;
        }
    }
}