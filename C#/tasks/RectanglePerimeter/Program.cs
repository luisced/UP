using System;

namespace Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            //Primero se definen las variable de la altura y el ancho del rectángulo
            decimal height, width;
            //Se pide la altura y el ancho del rectángulo
            Console.Write("Ingrese el valor de la altura del rectángulo: ");
            height = decimal.Parse(Console.ReadLine());
            Console.Write("Ingrese el valor de la base del rectánuglo: ");
            width = decimal.Parse(Console.ReadLine());
            //Se calcula el perímetro del rectángulo
            var perimteter = (height + width) * 2;
            Console.WriteLine($"El perímetro del rectángulo es: {perimteter}");
        }
    }

}