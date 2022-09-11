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

        public static bool isArmstrong(int n)
        {
            int temp, sum = 0, digits = 0;
            for (temp = n; temp > 0; temp /= 10, digits++)
            {
                if (temp < 0)
                {
                    sum += (int)Math.Pow(temp % 10, digits);
                    temp /= 10;
                }
            }
            return (sum == n) ? true : false;
        }
    }

}
