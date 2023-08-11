namespace FiftySum
{
    class Program
    {
        static void Main(string[] args)
        {
            // Se define una variable contador
            int sum = 0;

            // Se hace un ciclo for que recorre los números del 1 al 50
            for (int i = 1; i <= 50; i++)
            {
                // Se suma el número actual a la variable sum
                sum += i;
            }
            // foreach (int number in Enumerable.Range(1, 50))
            // {   // En cada iteeración, se suma el número actual a la variable contador
            //     sum += number;
            // }
            // Se imprime el resultado de la suma y su promedio
            Console.WriteLine($"La suma de los primeros 50 números es {sum} y su promedio es: {sum / 50}");
        }
    }
}

