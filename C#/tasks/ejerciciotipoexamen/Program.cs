namespace ejerciciotipoexamen
{
    class Program
    {
        static void Main(string[] args)
        {
            // Metodo numerico
            int num;
            Console.WriteLine("Escriba un número: ");
            num = Convert.ToInt32(Console.Read());
            int cantidad = 0;
            int numTemporal = num;

            while (numTemporal > 0)
            {
                numTemporal /= 10;
                Console.WriteLine(numTemporal);
                cantidad++;
            }

            Console.WriteLine($"Tu numero tiene {cantidad}");
            //Metodo string

            // string numtext;
            // Console.WriteLine("Escriba un numero: ");
            // numtext = "2";
            // Console.WriteLine($"Tu número tiene {numtext.Length} digitos");

        }
    }
}