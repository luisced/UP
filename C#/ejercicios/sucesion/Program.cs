namespace sucesion
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero;
            Console.Write("Ingrese un número: ");
            numero = Convert.ToInt32(Console.ReadLine());
            Sucesion(numero);
            Console.WriteLine();
            Fibonacci(numero);



        }
        static void Sucesion(int num)
        {
            int suma = 0;
            for (int i = 1; i <= num; i++)
            {
                suma += i;

                for (int j = 1; j <= i; j++)
                {
                    Console.Write($"{j}");
                    Console.Write(j < i ? " + " : " = ");
                }

                Console.WriteLine($"{suma}");
            }

        }
        static double Fn(int num)
        {
            double fn = (Math.Pow((1 + Math.Sqrt(5)), num) - Math.Pow((1 - Math.Sqrt(5)), num)) / (Math.Pow(2, num) * Math.Sqrt(5));
            return fn;
        }

        static void Fibonacci(int num)
        {
            int number = 0;
            for (int i = 0; i <= num; i++, number = (int)Fn(i), Console.WriteLine($"{number} + {(int)Fn(i + 1)} = {number + (int)Fn(i + 1)}")) ;
        }

    }
}