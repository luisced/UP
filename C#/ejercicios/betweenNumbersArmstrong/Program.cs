namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1, n2;
            Console.WriteLine("Ingrese un numero: ");
            n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese otro numero: ");
            n2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Los números armstrong entre: {n1} y {n2} son: ");
            // print the all the numbers between n1 and n2
            for (int i = n1; i <= n2; i++)
            {
                //   know if the number is armstrong or not
                if (isArmstrong(i))
                {
                    Console.Write($"{i}, ");
                }

            }

        }
        // function to know if the number is armstrong or not
        static bool isArmstrong(int n)
        {
            int sum = 0, temp = n, digits = 0;
            // count the number of digits
            for (int i = n; i > 0; i /= 10, digits++) ;

            while (temp > 0)
            {
                sum += (int)Math.Pow((temp % 10), digits);
                temp /= 10;

            }
            return sum == n ? true : false;
        }
    }

}
