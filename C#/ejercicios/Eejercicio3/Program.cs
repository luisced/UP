using System;

namespace Programa00
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el número del mes a consultar");
            int mes;
            mes = Convert.ToInt32(Console.ReadLine());
            if (mes == 1)
            {
                Console.WriteLine("Enero");
            }
            if (mes == 2)
            {
                Console.WriteLine("Febrero");
            }
            if (mes == 3)
            {
                Console.WriteLine("Marzo");
            }
            if (mes == 4)
            {
                Console.WriteLine("Abril");
            }
            if (mes == 5)
            {
                Console.WriteLine("Mayo");
            }
            if (mes == 6)
            {
                Console.WriteLine("Junio");
            }
            if (mes == 7)
            {
                Console.WriteLine("Julio");
            }
            if (mes == 8)
            {
                Console.WriteLine("Agosto");
            }
            if (mes == 9)
            {
                Console.WriteLine("Septiembre");
            }
            if (mes == 10)
            {
                Console.WriteLine("Octubre");
            }
            if (mes == 11)
            {
                Console.WriteLine("Noviembre");
            }
            if (mes == 12)
            {
                Console.WriteLine("Diciembre");
            }

        }
    }
}