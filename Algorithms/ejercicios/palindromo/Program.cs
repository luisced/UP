namespace Palindromo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese una palabra: ");
            string palabra = Console.ReadLine();

            Console.Write($"{Palindromo(palabra.ToLower())}");
        }
        static bool Palindromo(string palabra)
        {
            string palabraInvertida = "";
            for (int i = palabra.Length - 1; i >= 0; i--)
            {
                palabraInvertida += palabra[i];
            }

            return true ? palabra == palabraInvertida : false;

        }
    }
}