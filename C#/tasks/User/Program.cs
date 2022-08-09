using System;

namespace User
{
    class Program
    {
        static void Main(string[] args)
        {
            // Asking for user name
            Console.Write("Ingrese su nombre: ");
            string name = Console.ReadLine();
            // Asking for user age
            Console.Write("Ingrese su edad: ");
            int age = int.Parse(Console.ReadLine());
            // Asking for user id
            Console.Write("Ingrese su ID: ");
            string id = Console.ReadLine();
            Console.Write($"Hello your name is {name}, you are {age} years old and your id is {id}");

        }
    }
}

