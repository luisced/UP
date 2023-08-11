namespace Bienvenida
{
    class Program
    {
        static void Main(string[] args)
        {
            string colorFondo = "", colorTexto = "";
            Console.WriteLine("Proporciona el mensaje de bienvenida:");
            string mensaje = Console.ReadLine();

            Console.WriteLine("Proporciona el color de fondo en inglés:");
            colorFondo = Console.ReadLine();
            // si colorFondo está vacío ponemos el color por defecto
            if (string.IsNullOrEmpty(colorFondo))
                colorFondo = "Black";
            else
            {
                colorFondo = char.ToUpper(colorFondo[0]) + colorFondo.Substring(1).ToLower();
            }

            Console.WriteLine("Proporciona el color del texto en inglés:");
            colorTexto = Console.ReadLine();
            // si colorTexto está vacío ponemos el color por defecto
            if (colorTexto == "")
                colorTexto = "White";
            else
            {
                colorTexto = char.ToUpper(colorTexto[0]) + colorTexto.Substring(1).ToLower();
            }

            Bienvenida(mensaje, colorFondo, colorTexto);

        }

        static void Bienvenida(string mensaje, string color_fondo, string color_letra)
        {


            Console.ResetColor();
            Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color_fondo);
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color_letra);
            Console.WriteLine(mensaje);
        }
    }
}