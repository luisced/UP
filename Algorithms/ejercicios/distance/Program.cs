namespace Distance
{
    class Program
    {
        static void Main(string[] args)
        {
            float longitudcm;
            Console.Write("Ingrese la longitud en centimetros: ");
            longitudcm = float.Parse(Console.ReadLine());
            Console.WriteLine($"La longitud {longitudcm} en Km es: {Kilometros(longitudcm)}km, en M es: {metros(longitudcm)}m");
        }
        static float Kilometros(float longitud)
        {
            float kilometros;
            kilometros = longitud / 100000;
            return kilometros;
        }
        static float metros(float longitud)
        {
            float metros;
            metros = longitud / 100;
            return metros;
        }
    }
}