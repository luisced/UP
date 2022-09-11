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
            // print the all the numbers between n1 and n2
            for (int i = n1; i <= n2; i++)
            {
                //   know if the number is armstrong or not
                if (isArmstrong(i))
                {
                    Console.WriteLine($"{i}");
                }
                else
                {
                    Console.WriteLine($"no hay números armstrong entre {n1} y {n2}");
                }

            }

        }
        // function to know if the number is armstrong or not
        static bool isArmstrong(int n)
        {
            int sum = 0, temp = n, digits = 0;

            while (temp > 0)
            {
                int lastDigit = temp % 10;
                digits++;
                sum += (int)Math.Pow(lastDigit, digits);
                temp /= 10;
            }
            if (sum == n)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
