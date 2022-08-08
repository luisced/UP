using System;

namespace User
{
    class Program
    {
        static void Main(string[] args)
        {
            // Asking for user name
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            // Asking for user age
            Console.Write("Enter your age: ");
            int age = int.Parse(Console.ReadLine());
            // Asking for user id
            Console.Write("Enter your id: ");
            string id = Console.ReadLine();
            Console.Write($"Hello your name is {name}, you are {age} years old and your id is {id}");

        }
    }
}

