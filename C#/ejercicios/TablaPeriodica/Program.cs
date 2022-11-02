namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            // bidimensional array of elements, each element is a string array
            string[][][] elements = {
                // first group
                 new string[][]{
                    new string[] { "H", "Hydrogen", "1.008", "1"},
                },
            };

            Console.WriteLine("Elements in the first group:");
            foreach (string[] element in elements[0])
            {
                for (int i = 0; i < element.Length; i++)
                {
                    Console.Write(element[i] + " ");
                }
            }
        }
    }
}