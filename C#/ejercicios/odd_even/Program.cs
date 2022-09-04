using System;

namespace OddEven
{
    class Program
    {
        static void Main(string[] args)
        {
            //Primero se definen las variable de la altura y el ancho del rectángulo
            Console.WriteLine("Enter a number: ");
            var number = int.Parse(Console.ReadLine());

            // Si el residuo de la división entre el número ingresado y 2 es 0, el número es par.
            if (number % 2 == 0)
            {
                Console.WriteLine("The number is even.");
            }
            // De lo contrario, el número es impar
            else if (number % 2 != 0)
            {
                Console.WriteLine("The number is odd.");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

        }
    }
}