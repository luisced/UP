namespace TwoStones
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of stones: ");
            int numero_piedras = Convert.ToInt32(Console.ReadLine());
            if (numero_piedras % 2 == 0)
            {
                Console.WriteLine("Bob");
            }
            else
            {
                Console.WriteLine("Alice");
            }
        }
    }
}