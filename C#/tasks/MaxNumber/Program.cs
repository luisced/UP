namespace MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>()
            { 1, 2, 3, 20, 5, 6, 7, 8, 9, 10, 11, 12};

            int max_number = numbers[0];
            foreach (int number in numbers)
            {
                if (number > max_number)
                {
                    max_number = number;
                }
            }
            Console.WriteLine(max_number);
        }
    }
}



