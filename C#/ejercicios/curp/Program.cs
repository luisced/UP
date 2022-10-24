namespace Curp
{
    class Program
    {

        static Dictionary<string, string> estados = new Dictionary<string, string>{
            {"AS", "AGUASCALIENTES"},
            {"BC", "BAJA CALIFORNIA"},
            {"BS", "BAJA CALIFORNIA SUR"},
            {"CC", "CAMPECHE"},
            {"CL", "COAHUILA"},
            {"CM", "COLIMA"},
            {"CS", "CHIAPAS"},
            {"CH", "CHIHUAHUA"},
            {"DF", "DISTRITO FEDERAL"},
            {"DG", "DURANGO"},
            {"GT", "GUANAJUATO"},
            {"GR", "GUERRERO"},
            {"HG", "HIDALGO"},
            {"JC", "JALISCO"},
            {"MC", "MEXICO"},
            {"MN", "MICHOACAN"},
            {"MS", "MORELOS"},
            {"NT", "NAYARIT"},
            {"NL", "NUEVO LEON"},
            {"OC", "OAXACA"},
            {"PL", "PUEBLA"},
            {"QT", "QUERETARO"},
            {"QR", "QUINTANA ROO"},
            {"SP", "SAN LUIS POTOSI"},
            {"SL", "SINALOA"},
            {"SR", "SONORA"},
            {"TC", "TABASCO"},
            {"TS", "TAMAULIPAS"},
            {"TL", "TLAXCALA"},
            {"VZ", "VERACRUZ"},
            {"YN", "YUCATAN"},
            {"ZS", "ZACATECAS"},
            {"NE", "EXTRANJERO"}
        };
        static void Main(string[] args)
        {
            string nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, sexo, entidadNacimiento;
            Console.Clear();
            Console.Write("Ingrese su nombre: ");
            nombre = Console.ReadLine();
            Console.Write("Ingrese su apellido paterno: ");
            apellidoPaterno = Console.ReadLine();
            Console.Write("Ingrese su apellido materno: ");
            apellidoMaterno = Console.ReadLine();
            Console.Write("Ingrese su fecha de nacimiento (dd/mm/aaaa): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
            {
                Console.Write("Fecha incorrecta");
                return;
            }
            else
            {
                fechaNacimiento = fecha.ToString("ddMMyyyy");
                Console.Write(fechaNacimiento);
            }

            Console.Write("Ingrese su sexo (H/M): ");
            sexo = Console.ReadLine();
            Console.WriteLine($"Ingrese su entidad de nacimiento: ");
            foreach (var item in estados)
            {
                // imprime el valor de la llave y el valor
                Console.WriteLine($"{item.Value}");
            }
            Console.Write("Ingrese su entidad de nacimiento: ");
            // entidad de nacimiento es un string de 2 letras que se obtiene de la lista de estados
            entidadNacimiento = Console.ReadLine();
            entidadNacimiento = estados.FirstOrDefault(x => x.Value == entidadNacimiento.ToUpper()).Key; // Obtiene el valor de la llave en el diccionario de estados a partir del valor de la entidad de nacimiento y se convierte a mayusculas
            // Imprime GenerarCurp con los parametros y pon fondo de la consola en cyan
            Console.BackgroundColor = ConsoleColor.Cyan;
            // Console.WriteLine(GenerarCurp(nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, sexo, entidadNacimiento));
            Console.WriteLine($"Su CURP es: {GenerarCurp(nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, sexo, entidadNacimiento)}");


        }

        static string ObtenerVocales(string cadena)
        {
            string firstVowel = cadena.FirstOrDefault(c => "AEIOU".Contains(c.ToString().ToUpper())).ToString();
            // Se le asigna a la variable el primber caracter de la cadena, si el parámetro que se le pasa es AEIOU, o sea vocales, y se convierte a mayusculas
            return firstVowel.ToUpper();
        }
        static string ObtenerConsonantes(string cadena)
        {
            string firstConsonant = cadena.FirstOrDefault(c => !"AEIOU".Contains(c.ToString().ToUpper())).ToString();
            // Se le asigna a la variable el primber caracter de la cadena que sea distinto a las vocales, y se convierte a mayusculas
            return firstConsonant.ToUpper();
        }
        static string apellidoPaternoPrimeraLetra(string apellidoPaterno)
        {
            string firstLetter = apellidoPaterno.Substring(0, 1); // posición 1
            return firstLetter.ToUpper();
        }
        static string apellidoMaternoPrimeraLetra(string apellidoMaterno)
        {
            string firstLetter = apellidoMaterno.Substring(0, 1); // posición 3
            return firstLetter.ToUpper();
        }
        static string nombrePrimeraLetra(string nombre)
        {
            string firstLetter = nombre.Substring(0, 1); // posición 4
            return firstLetter.ToUpper();
        }
        static string añosDigitos(string fechaNacimiento)
        {
            string añosDigitos = fechaNacimiento.Substring(6, 2); // posición 5 y 6
            return añosDigitos;
        }
        static string mesDigitos(string fechaNacimiento)
        {
            string mesDigitos = fechaNacimiento.Substring(2, 2); // posición 7 y 8
            return mesDigitos;
        }
        static string diaDigitos(string fechaNacimiento)
        {
            string diaDigitos = fechaNacimiento.Substring(0, 2); // posición 9 y 10: 
            return diaDigitos;
        }
        static string sexo_funcion(string sexo)
        {
            Console.Write(sexo.ToUpper());
            return sexo.ToUpper();
        }
        static string entidadNacimiento_funcion(string entidadNacimiento)
        {
            return entidadNacimiento.ToUpper();
        }

        static string GenerarCurp(string nombre, string apellidoPaterno, string apellidoMaterno, string fechaNacimiento, string sexo, string entidadNacimiento)
        {
            string curp = ($"{apellidoPaternoPrimeraLetra(apellidoPaterno)}{ObtenerVocales(apellidoPaterno)}{apellidoMaternoPrimeraLetra(apellidoMaterno)}{nombrePrimeraLetra(nombre)}{añosDigitos(fechaNacimiento)}{mesDigitos(fechaNacimiento)}{diaDigitos(fechaNacimiento)}{sexo_funcion(sexo)}{entidadNacimiento_funcion(entidadNacimiento)}{ObtenerConsonantes(apellidoPaterno)}{ObtenerConsonantes(apellidoMaterno)}{ObtenerConsonantes(nombre)}");
            return curp;
        }

    }
}