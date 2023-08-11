namespace ContadorCifras
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce un número");
            int numero = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"El número tiene {numero} {ContadorCifras(numero)} cifras");
            Console.WriteLine($"El número {numero} invertido es {InvertirCifras(numero)}");
        }

        static int ContadorCifras(int numero)
        {
            int contador = 0;
            while (numero > 0)
            {
                numero = numero / 10;
                contador++;
            }
            return contador;
        }

        static string InvertirCifras(int numero)
        {
            string invertido = "";
            while (numero > 0)
            {
                invertido = invertido + numero % 10;
                numero = numero / 10;
            }
            return invertido;
        }
    }
}