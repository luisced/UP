namespace Banco
{
    class Program
    {
        struct Cuenta
        {
            public string nombre;
            public int NoCuenta;
            public string nip;
            public double monto;
        }
        struct Movimientos
        {
            public string accion;
            public double monto;
            public string fecha;
            public string id;
        }
        static List<Cuenta> cuentas = new List<Cuenta>();
        static List<Movimientos> movimientos = new List<Movimientos>();
        static void Main(string[] args) { Menu(); }

        static void AltaCuenta()
        {
            Cuenta cuenta = new Cuenta();
            Random random = new Random();
            int cvv = random.Next(1000, 9999);
            string exp = DateTime.Now.AddYears(4).ToString("MM/yy");
            string card = string.Join(" ", Enumerable.Range(0, 16).Select(x => random.Next(0, 10)).Select(x => x.ToString()).ToArray()).Substring(0, 19);
            do
            {


                Console.Write("Ingrese su nombre: ");
                while (true)
                {
                    cuenta.nombre = Console.ReadLine();
                    if (cuenta.nombre.Length > 0) { break; }
                    else
                    {
                        Console.WriteLine("Ingrese un nombre válido");
                        Console.Write("Ingrese su nombre: ");
                    }
                }
                cuenta.NoCuenta = cuentas.Count + 1;
                Console.Write("Ingrese su nip: ");
                string password = "";
                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        if (char.IsNumber(key.KeyChar) && password.Length < 4)
                        {
                            password += key.KeyChar;
                            Console.Write("*");
                            cuenta.nip = password;

                        }

                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                        {
                            password = password.Substring(0, (password.Length - 1));
                            Console.Write("\b \b");
                        }
                    }

                } while (key.Key != ConsoleKey.Enter || password.Length < 4);
                string password2 = "";
                do
                {
                    Console.Write("\nConfirme su nip: ");
                    ConsoleKeyInfo key2;
                    do
                    {
                        key2 = Console.ReadKey(true);
                        if (key2.Key != ConsoleKey.Backspace && key2.Key != ConsoleKey.Enter)
                        {
                            if (char.IsNumber(key2.KeyChar) && password2.Length < 4)
                            {
                                password2 += key2.KeyChar;
                                Console.Write("*");
                            }
                        }
                        else
                        {
                            if (key2.Key == ConsoleKey.Backspace && password2.Length > 0)
                            {
                                password2 = password2.Substring(1, (password2.Length - 1));
                                Console.Write("\b \b");
                            }
                        }

                    } while (key2.Key != ConsoleKey.Enter);
                    if (password2 != cuenta.nip)
                    {
                        Console.WriteLine("\nLos nips no coinciden");
                        password2 = "";
                    }
                } while (password2 != cuenta.nip);



                Console.Write("\nIngrese un monto inicial: ");
                while (true)
                {
                    try
                    {
                        cuenta.monto = double.Parse(Console.ReadLine());
                        if (cuenta.monto > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.Write("El monto debe ser mayor a 0, intente de nuevo: ");
                        }
                    }
                    catch (Exception)
                    {
                        Console.Write("Ingrese un monto valido: ");
                    }
                }

                cuentas.Add(cuenta);
                Console.WriteLine("Cuenta creada con exito, tome su tarjeta");

                int no = cuenta.NoCuenta;
                // Color the console text green
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@$"
                ||====================================================================||
                ||//$\\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\//$\\||
                ||(LUIS)=================|       LUIS BANK      |===============(LUIS)||
                ||\\$//                  '------========--------'                \\$//||
                ||<< /     /========\          // ____ \\                         \ >>||
                ||>>|      |  |  |  |         // ///..) \\           ))) {cvv}      |<<||
                ||<<|      |  |  |  |        || <||  >\  ||                        |>>||
                ||>>|      \========/        ||  $$ --/  ||    Exp.Date: {exp}     |<<||
                ||<<|        40000            *\\  |\_/  //*                       |>>||
                ||>>|                         *\\/___\_//*                         |<<||
                ||<<\     No.Cuenta: {no}   ______/PLATINUM\________                  />>||
                ||//$\                 ~|         {cuenta.nombre}          |~               /$\\||
                ||(LUIS)=================  {card} =================(LUIS)||
                ||\\$//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\\$//||
                ||====================================================================||");
                Console.ResetColor();
                Console.WriteLine("\n\nPresione Enter para continuar");
            } while (Console.ReadKey().Key != ConsoleKey.Enter);
            Console.Clear();
        }

        static void VerCuenta()
        {
            Console.WriteLine("Ingrese su numero de cuenta: ");
            int NoCuenta = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese su nip: ");
            string nip = Console.ReadLine();

            Cuenta cuenta = cuentas.Find(x => x.NoCuenta == NoCuenta && x.nip == nip);
            if (cuenta.nombre != null)
            {
                Console.WriteLine($"Su numero de cuenta es: {cuenta.NoCuenta} y su nip es: {cuenta.nip} su monto es: {cuenta.monto}, su nombre es: {cuenta.nombre}");
            }
            else
            {
                Console.WriteLine("Cuenta no encontrada");
            }
        }

        static void Depositar(double cantidad, int NoCuenta)
        {
            List<Cuenta> cuentas_temporal = new List<Cuenta>();
            if (cantidad > 0)
            {
                for (int i = 0; i < cuentas.Count; i++)
                {
                    if (cuentas[i].NoCuenta == NoCuenta)
                    {
                        Cuenta cuenta = cuentas[i];
                        cuenta.monto += cantidad;
                        cuentas_temporal.Add(cuenta);
                        Console.WriteLine($"Se ha depositado {cantidad} a su cuenta");
                        cuentas.RemoveAt(i);
                    }
                    else
                    {
                        cuentas_temporal.Add(cuentas[i]);
                    }
                }
                cuentas.AddRange(cuentas_temporal);
            }
            else
            {
                Console.WriteLine("No se puede depositar una cantidad negativa");
            }
        }

        static void Retirar(double cantidad, int NoCuenta)
        {
            List<Cuenta> cuentas_temporal = new List<Cuenta>();
            // cantidad no puede ser negativa ni mayor al monto de la cuenta
            if (cantidad > 0 && cantidad <= cuentas.Find(x => x.NoCuenta == NoCuenta).monto)
            {
                for (int i = 0; i < cuentas.Count; i++)
                {
                    if (cuentas[i].NoCuenta == NoCuenta)
                    {
                        Cuenta cuenta = cuentas[i];
                        cuenta.monto -= cantidad;
                        cuentas_temporal.Add(cuenta);
                        Console.WriteLine($"Se ha retirado {cantidad} de su cuenta");
                        cuentas.RemoveAt(i);
                    }
                    else
                    {
                        cuentas_temporal.Add(cuentas[i]);
                    }
                }
                cuentas.AddRange(cuentas_temporal);
            }
            else
            {
                Console.WriteLine("No se puede retirar una cantidad negativa o mayor al monto de la cuenta");
            }



        }

        static void ConsultarSaldo(int NoCuenta)
        {
            Cuenta cuenta = cuentas.Find(x => x.NoCuenta == NoCuenta);
            Console.WriteLine($"{cuenta.nombre}, su saldo actual es de: {cuenta.monto}");
        }

        static void VerUsuarios()
        {
            do
            {
                string margen1 = "╔═══════════════════════════════════════╗", margen2 = "╚═══════════════════════════════════════╝", margen3 = "║═══════════════════════════════════════║", margen4 = "║                                       ║";
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{margen1}\n║\t\tUsuarios\t\t║ \n{margen3}");
                Console.WriteLine($"{margen4}\n║\tNo. Cuenta\tNombre\t\t║");
                foreach (Cuenta cuenta in cuentas) { Console.WriteLine($"{margen4}\n║\t{cuenta.NoCuenta}\t\t{cuenta.nombre}\t\t║"); }
                Console.WriteLine($"{margen2}");
                Console.ResetColor();
                Console.WriteLine("Presione enter para continuar");
            } while (Console.ReadKey().Key != ConsoleKey.Enter);
            Console.Clear();
        }
        static void IngresarSistema()
        {
            string margen1 = "╔═══════════════════════════════════════╗", margen2 = "╚═══════════════════════════════════════╝", margen3 = "║═══════════════════════════════════════║", margen4 = "║                                       ║";
            string password = "";
            ConsoleKeyInfo key2;

            Console.Write("Ingrese su numero de cuenta: ");
            int NoCuenta = Convert.ToInt32(Console.ReadLine());
            // find no. cuenta
            Cuenta numero_cuenta = cuentas.Find(x => x.NoCuenta == NoCuenta);
            while (true)
            {
                if (cuentas.Contains(numero_cuenta))
                {
                    while (true)
                    {

                        Console.Write("Ingrese su nip: ");
                        ConsoleKeyInfo key;

                        do
                        {
                            key = Console.ReadKey(true);
                            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                            {
                                if (char.IsNumber(key.KeyChar) && password.Length < 4)
                                {
                                    password += key.KeyChar;
                                    Console.Write("*");


                                }
                            }
                            else
                            {
                                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                                {
                                    password = password.Substring(1, (password.Length - 1));
                                    Console.Write("\b \b");
                                }
                            }

                        } while (key.Key != ConsoleKey.Enter || password.Length < 4);
                        // if nip is correct
                        if (password == numero_cuenta.nip)
                        {

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{margen1}\n║\tBienvenido {numero_cuenta.nombre}  \t\t║ \n║\t   ¿Qué desea hacer?\t\t║");
                            Console.WriteLine($"{margen3}\n{margen4}\n║\t1. Depositar\t\t\t║\n{margen4}\n║\t2. Retirar\t\t\t║\n{margen4}\n║\t3. Consultar saldo\t\t║\n{margen4}\n║\t4. Salir\t\t\t║\n{margen2}");
                            Console.Write("Ingrese una opción: ");
                            int opcion = Convert.ToInt32(Console.ReadLine());
                            while (opcion != 4)
                            {
                                switch (opcion)
                                {
                                    case 1:
                                        Console.Write("Ingrese el monto a depositar: ");
                                        double monto = Convert.ToDouble(Console.ReadLine());
                                        Depositar(monto, numero_cuenta.NoCuenta);
                                        break;
                                    case 2:
                                        Console.Write("Ingrese el monto a retirar: ");
                                        monto = Convert.ToDouble(Console.ReadLine());
                                        Retirar(monto, numero_cuenta.NoCuenta);
                                        break;
                                    case 3:
                                        ConsultarSaldo(numero_cuenta.NoCuenta);
                                        break;
                                    default:
                                        Console.WriteLine("Opción no válida");
                                        break;
                                }
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{margen1}\n║\tBienvenido al Banco de Luis\t║ \n║\t   ¿Qué desea hacer?\t\t║");
                                Console.WriteLine($"{margen3}\n{margen4}\n║\t1. Depositar\t\t\t║\n{margen4}\n║\t2. Retirar\t\t\t║\n{margen4}\n║\t3. Consultar saldo\t\t║\n{margen4}\n║\t4. Salir\t\t\t║\n{margen2}");
                                Console.Write("Ingrese una opción: ");
                                opcion = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nNip incorrecto");
                            password = "";
                            continue;
                        }
                    }
                    break;
                }

                else
                {
                    Console.WriteLine("Cuenta no encontrada");
                    Console.Write("Ingrese su numero de cuenta: ");
                    NoCuenta = Convert.ToInt32(Console.ReadLine());

                }
            }


        }
        static void Menu()
        {

            string margen1 = "╔═══════════════════════════════════════╗";
            string margen2 = "╚═══════════════════════════════════════╝";
            string margen3 = "║═══════════════════════════════════════║";
            string margen4 = "║                                       ║";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{margen1}\n║\tBienvenido al Banco de Luis\t║ \n║\t   ¿Qué desea hacer?\t\t║");
            Console.WriteLine($"{margen3}\n{margen4}\n║\t1. Alta de usuario\t\t║\n{margen4}\n║\t2. Ingresar al sistema\t\t║\n{margen4}\n║\t3. Ver Usuarios\t\t\t║\n{margen4}\n║\t4. Salir\t\t\t║\n{margen2}");

            Console.Write("Ingrese una opción: ");

            int opcion = Convert.ToInt32(Console.ReadLine());
            while (opcion != 4)
            {
                switch (opcion)
                {
                    case 1:
                        AltaCuenta();
                        break;
                    case 2:
                        IngresarSistema();
                        break;
                    case 3:
                        VerUsuarios();
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{margen1}\n║\tBienvenido al Banco de Luis\t║ \n║\t   ¿Qué desea hacer?\t\t║");
                Console.WriteLine($"{margen3}\n{margen4}\n║\t1. Alta de usuario\t\t║\n{margen4}\n║\t2. Ingresar al sistema\t\t║\n{margen4}\n║\t3. Ver Usuarios\t\t\t║\n{margen4}\n║\t4. Salir\t\t\t║\n{margen2}");
                Console.Write("Ingrese una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.ResetColor();

            }
        }
    }
}