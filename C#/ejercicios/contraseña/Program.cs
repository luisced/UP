namespace CorreoContraseña
{
    class Program
    {
        static void Main(string[] args)
        {
            string correo, password, nombre, apellido_paterno, apellido_materno, mes, dia, año, shuffled_password = "";
            Console.Write("Ingrese su nombre: ");
            nombre = Console.ReadLine().ToLower();
            Console.Write("Ingrese su apellido Paterno: ");
            apellido_paterno = Console.ReadLine().ToLower();
            Console.Write("Ingrese su apellido Materno: ");
            apellido_materno = Console.ReadLine().ToLower();
            Console.Write("Ingrese su fecha de nacimiento (mes día año) separados por espacios: ");
            string[] fecha = Console.ReadLine().Split(' ');
            mes = fecha[0];
            dia = fecha[1];
            año = fecha[2];

            password = nombre + mes + dia + año;
            // mezclamos la contraseña con 8 caracteres al azar
            for (int i = 0; i < 8; i++)
            {
                int random = new Random().Next(0, password.Length);
                shuffled_password += password[random];
            }

            Console.WriteLine("Su correo es: " + nombre.Substring(0, 1) + apellido_paterno.Substring(0, 1) + apellido_materno.Substring(apellido_materno.Length - 3, 3) + "@gmail.com");
            Console.WriteLine("Su contraseña es: " + shuffled_password);


        }

    }
}


