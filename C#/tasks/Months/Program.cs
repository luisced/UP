namespace Months
{
    class Program
    {
        static void Main(string[] args)
        {
            // Se define un diccionario con los meses del año
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
            // Se pide el número del mes y se asigna a la variable numero
            Console.WriteLine("Escriba un número entre el 1 y 12: ");
            var number = int.Parse(Console.ReadLine());

            // Si el número ingresado se encuentra dentro del rango de los meses del año, se imprime el nombre del mes
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