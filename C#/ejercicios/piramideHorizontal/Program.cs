namespace Piramide
{
    class Program
    {
        static void Main(string[] args)
        {
            int nivel;
            Console.Write("Por favor dame un número entero " + "entre 1 y 10: ");
            nivel = int.Parse(Console.ReadLine());

            // Primera mitad de la pirámide

            // Bucle para crear cada fila
            for (int i = 1; i <= nivel; i++) // Se incrementa i de 1 hasta el número de niveles
            {
                for (int j = 1; j <= i; j++) // Bucle para imprimir la variable contador
                {
                    Console.Write($"{j}  ");  // Se imprime el valor de j concatenado con un espacio
                }
                for (int k = 1; k <= i; k++)
                {
                    Console.Write(" "); // Se imprime un espacio por cada iteración
                }
                Console.WriteLine("");
            }

            // Segunda mitad de la pirámide
            for (int i = nivel - 1; i >= 1; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write($"{j}  ");
                }
                for (int k = 1; k <= i; k++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("");
            }
        }
    }
}