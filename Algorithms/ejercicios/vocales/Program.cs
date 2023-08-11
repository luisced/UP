namespace Vocales
{
    class Program
    {
        static void Main(string[] args)
        {
            ContarVocales();
        }
        static void ContarVocales()
        {
            int total = 0;
            int a = 0;
            int e = 0;
            int I = 0;
            int o = 0;
            int u = 0;

            Console.Write("Ingrese una palabra: ");
            string palabra = Console.ReadLine().ToLower();
            for (int i = 0; i < palabra.Length; i++)
            {
                if (palabra[i] == 'a')
                {
                    a++;
                    total++;
                }
                else if (palabra[i] == 'e')
                {
                    e++;
                    total++;
                }
                else if (palabra[i] == 'i')
                {
                    i++;
                    total++;
                }
                else if (palabra[i] == 'o')
                {
                    o++;
                    total++;
                }
                else if (palabra[i] == 'u')
                {
                    u++;
                    total++;
                }

            }
            Console.WriteLine($"La palabra tiene {total} vocales");
            if (a > 0)
            {
                Console.WriteLine($"La palabra tiene {a} vocales a");
            }
            if (e > 0)
            {
                Console.WriteLine($"La palabra tiene {e} vocales e");
            }
            if (I > 0)
            {
                Console.WriteLine($"La palabra tiene {I} vocales i");
            }
            if (o > 0)
            {
                Console.WriteLine($"La palabra tiene {o} vocales o");
            }
            if (u > 0)
            {
                Console.WriteLine($"La palabra tiene {u} vocales u");
            }

        }
    }
}