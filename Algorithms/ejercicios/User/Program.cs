namespace User
{
    class Program
    {
        static void Main(string[] args)
        {
            // Se solicitan los datos al usuario separados por un espacio
            Console.WriteLine("Ingrese su nombre, edad y id separados por un espacio");

            // Se leen los datos ingresados y se asignan a las variables correspondientes 
            string[] datos = Console.ReadLine().Split(' ');

            // La variable nombre almacena el valor de la posición 0 de la variable datos
            string nombre = datos[0];

            // La variable edad almacena el valor de la posición 1 de la variable datos
            int edad = int.Parse(datos[1]);

            // La variable id almacena el valor de la posición 2 de la variable datos
            string ID = datos[2];


            // Asking for user name
            Console.Write($"Hola {nombre}, Tienes {edad} años y tu ID es {ID}");
        }
    }
}