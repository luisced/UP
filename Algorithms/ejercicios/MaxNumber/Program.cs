namespace MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // Se define una lista con los números del 1 al 10
            List<int> numbers = new List<int>()
            { 1, 2, 3, 20, 5, 6, 7, 8, 9, 10, 11, 12};

            // Se define una variable para almacenar el primer número de la lista
            int max_number = numbers[0];

            foreach (int number in numbers)
            {
                // Si el número actual es mayor que el número almacenado en la variable max_number, se asigna el número actual a la variable max_number
                if (number > max_number)
                {
                    max_number = number;
                }
            }
            // Se imprime el número mayor de la lista
            Console.WriteLine(max_number);
        }
    }
}



