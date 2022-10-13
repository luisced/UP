namespace Banco
{
    class Program
    {
        struct Movimientos
        {
            public string accion;
            public double monto;
            public string fecha;
            public int id;
        }
        struct Cuenta
        {
            public string nombre;
            public int NoCuenta;
            public string nip;
            public double monto;
            // add a Movimientos list to the Cuenta struct
            public List<Movimientos> movimientos;



        }
        static List<Cuenta> cuentas = new List<Cuenta>();
        static void Main(string[] args) { Menu(); }

        static void AltaCuenta()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Cuenta cuenta = new Cuenta();
            cuenta.movimientos = new List<Movimientos>();
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
                        // write * instead of the key pressed and add a space between each *
                        // if the key pressed is a number and the length is 4
                        if (key.KeyChar >= '0' && key.KeyChar <= '9' && password.Length < 4)
                        {
                            password += key.KeyChar;
                            Console.Write(" * ");
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
                // cuenta.movimientos.Add(new Movimientos { accion = "Creacion Cuenta", monto = cuenta.monto, fecha = DateTime.Now, id = 1 });
                cuentas.Add(cuenta);
                GenerarMovimiento("Creación de cuenta", cuenta.monto, cuenta.NoCuenta);
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

            do
            {
                if (cantidad > 0)
                {
                    int index = cuentas.FindIndex(x => x.NoCuenta == NoCuenta);
                    Cuenta cuenta = cuentas[index];
                    cuenta.monto += cantidad;
                    cuentas_temporal.Add(cuenta);
                    cuentas.RemoveAt(index);
                    cuentas.AddRange(cuentas_temporal);
                    GenerarMovimiento("Deposito", cantidad, NoCuenta);
                    Console.WriteLine($"Se ha depositado {cantidad} a su cuenta\nPresione Enter para continuar");
                }
                else
                {
                    Console.WriteLine("No se puede depositar una cantidad negativa");
                }
            } while (Console.ReadKey().Key != ConsoleKey.Enter);
            Console.Clear();

        }

        static void Retirar(double cantidad, int NoCuenta)
        {
            List<Cuenta> cuentas_temporal = new List<Cuenta>();
            do
            {
                if (cantidad > 0 && cantidad <= cuentas.Find(x => x.NoCuenta == NoCuenta).monto)
                {
                    int index = cuentas.FindIndex(x => x.NoCuenta == NoCuenta);
                    Cuenta cuenta = cuentas[index];
                    cuenta.monto -= cantidad;
                    cuentas_temporal.Add(cuenta);
                    cuentas.RemoveAt(index);
                    cuentas.AddRange(cuentas_temporal);
                    GenerarMovimiento("Retiro", (cantidad * -1), NoCuenta);
                    Console.WriteLine($"Se ha retirado {cantidad} de su cuenta\nPresione Enter para continuar");
                }
                else
                {
                    Console.WriteLine("No se puede retirar una cantidad negativa o mayor al monto de la cuenta");
                }
            } while (Console.ReadKey().Key != ConsoleKey.Enter);
            Console.Clear();



        }

        static void ConsultarSaldo(int NoCuenta)
        {
            do
            {
                Cuenta cuenta = cuentas.Find(x => x.NoCuenta == NoCuenta);
                Console.WriteLine($"{cuenta.nombre}, su saldo actual es de: {cuenta.monto}\nPresione Enter para continuar: ");
            } while (Console.ReadKey().Key != ConsoleKey.Enter);
            Console.Clear();

        }

        static void VerUsuarios()
        {
            do
            {
                string margen1 = "╔═══════════════════════════════════════╗", margen2 = "╚═══════════════════════════════════════╝", margen3 = "║═══════════════════════════════════════║", margen4 = "║                                       ║";
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{margen1}\n║\t\tUsuarios\t\t║ \n{margen3}");
                Console.WriteLine($"{margen4}\n║\tNo. Cuenta\tNombre\t\t║");
                cuentas.Sort((x, y) => x.NoCuenta.CompareTo(y.NoCuenta));
                foreach (Cuenta cuenta in cuentas) { Console.WriteLine($"{margen4}\n║\t{cuenta.NoCuenta}\t\t{cuenta.nombre}\t\t║"); }
                Console.WriteLine($"{margen2}");
                Console.ResetColor();
                Console.WriteLine("Presione enter para continuar");
            } while (Console.ReadKey().Key != ConsoleKey.Enter);
            Console.Clear();
        }
        static void GenerarMovimiento(string accion, double cantidad, int NoCuenta)
        {
            Cuenta cuenta = cuentas.Find(x => x.NoCuenta == NoCuenta);
            cuenta.movimientos.Add(new Movimientos
            {
                accion = accion,
                monto = cantidad,
                fecha = DateTime.Now.ToString("dd/MM/yyyy"),
                id = cuenta.movimientos.Count + 1
            });
        }


        static void VerMovimientos(int NoCuenta)
        {
            string margen1 = "╔═══════════════════════════════════════╗", margen2 = "╚═══════════════════════════════════════╝", margen3 = "║═══════════════════════════════════════║", margen4 = "║                                       ║";
            List<Cuenta> cuenta_temporal = new List<Cuenta>();
            do
            {
                int index = cuentas.FindIndex(x => x.NoCuenta == NoCuenta);
                Cuenta cuenta = cuentas[index];
                cuenta.movimientos.Sort((x, y) => x.id.CompareTo(y.id));
                Console.ForegroundColor = ConsoleColor.Yellow;
                // Poner tabla de movimientos con id, fecha, accion, monto
                Console.WriteLine($"{margen1}\n║\t\tMovimientos\t\t║ \n{margen3}");
                foreach (Movimientos movimiento in cuenta.movimientos)
                {
                    Console.WriteLine($"{margen4}\n║\t{movimiento.id}\t\t{movimiento.fecha}\t\t{movimiento.accion}\t\t{movimiento.monto}\t\t║");
                }
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
                            Console.WriteLine($"{margen3}\n{margen4}\n║\t1. Depositar\t\t\t║\n{margen4}\n║\t2. Retirar\t\t\t║\n{margen4}\n║\t3. Consultar saldo\t\t║\n{margen4}\n║\t4. Ver movimientos\t\t║\n{margen4}\n║\t5. Salir\t\t\t║\n{margen2}");
                            Console.Write("Ingrese una opción: ");
                            int opcion = Convert.ToInt32(Console.ReadLine());
                            while (opcion != 5)
                            {
                                switch (opcion)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.Write("Ingrese el monto a depositar: ");
                                        double monto = Convert.ToDouble(Console.ReadLine());
                                        Depositar(monto, numero_cuenta.NoCuenta);

                                        break;
                                    case 2:
                                        Console.Clear();
                                        Console.Write("Ingrese el monto a retirar: ");
                                        monto = Convert.ToDouble(Console.ReadLine());

                                        Retirar(monto, numero_cuenta.NoCuenta);
                                        break;
                                    case 3:
                                        Console.Clear();
                                        ConsultarSaldo(numero_cuenta.NoCuenta);
                                        break;
                                    case 4:
                                        Console.Clear();
                                        VerMovimientos(numero_cuenta.NoCuenta);
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("Opción no válida");
                                        break;
                                }
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{margen1}\n║\tBienvenido al Banco de Luis\t║ \n║\t   ¿Qué desea hacer?\t\t║");
                                Console.WriteLine($"{margen3}\n{margen4}\n║\t1. Depositar\t\t\t║\n{margen4}\n║\t2. Retirar\t\t\t║\n{margen4}\n║\t3. Consultar saldo\t\t║\n{margen4}\n║\t4. Ver movimientos\t\t║\n{margen4}\n║\t5. Salir\t\t\t║\n{margen2}");

                                Console.Write("Ingrese una opción: ");
                                opcion = Convert.ToInt32(Console.ReadLine());
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
                    Console.WriteLine("Ingrese su numero de cuenta: ");
                    Console.Clear();
                    break;

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