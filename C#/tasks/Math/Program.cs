namespace Maths
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            Console.WriteLine("Enter a number: ");
            num = Convert.ToInt32(Console.ReadLine());
            if (num < 0)
            {
                Console.WriteLine("Number is negative");
            }
            else if (num > 0 && num <= 5)
            {
                Console.WriteLine($"Number {num} is between 1 and 5");
            }
            else if (num >= 6 && num <= 10)
            {
                Console.WriteLine($"Number {num} is between 6 and 10");
            }
            else
            {
                Console.WriteLine($"Number {num} is greater than 10");
            }
        }

    }
}