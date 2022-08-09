namespace Months
{
    class Program
    {
        static void Main(string[] args)
        {
            var months = new Dictionary<int, string>()
            {
                {1, "Enero"},
                {2, "Febrero"},
                {3, "Marzo"},
                {4, "Abril"},
                {5, "Mayo"},
                {6, "Junio"},
                {7, "Julio"},
                {8, "Agosto"},
                {9, "Septiembre"},
                {10, "Octubre"},
                {11, "Noviembre"},
                {12, "Diciembre"}
            };
            Console.WriteLine("Escriba un número entre el 1 y 12: ");
            var number = int.Parse(Console.ReadLine());

            if (months.ContainsKey(number))
            {
                Console.WriteLine($"{number}:{months[number]}");
            }
            else
            {
                Console.WriteLine($"El número {number} no es un mes válido");
            }

        }
    }
}