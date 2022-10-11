// estructura cuenta: nombre, no. cuenta, nip, monto
// alta de usuario
// realizar un retiro, depósito
// entra al sistema, salir del sistema
// ver, abonar, retirar saldo, ingresar su nip (validación)

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
        static void Main(string[] args)
        {
            Menu();
        }

        static void AltaCuenta()
        {
            Cuenta cuenta = new Cuenta();

            do
            {


                Console.Write("Ingrese su nombre: ");
                while (true)
                {
                    cuenta.nombre = Console.ReadLine();
                    if (cuenta.nombre.Length > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ingrese un nombre válido");
                        Console.Write("Ingrese su nombre: ");
                    }
                }
                cuenta.NoCuenta = cuentas.Count + 1;
                Console.Write("Ingrese su nip: ");
                // write asteriks instead of the characters
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

                } while (key.Key != ConsoleKey.Enter);
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
                Console.WriteLine("Cuenta creada con exito");
                Console.WriteLine($"Saludos {cuenta.nombre}, su numero de cuenta es: {cuenta.NoCuenta} y su nip es: {cuenta.nip} su monto es: ${cuenta.monto}, gracias por preferirnos");
                Console.WriteLine("Presione Enter para continuar");
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



        static void Menu()
        {

            string margen1 = "╔═══════════════════════════════════════╗";
            string margen2 = "╚═══════════════════════════════════════╝";
            string margen3 = "║═══════════════════════════════════════║";
            string margen4 = "║                                       ║";
            Console.Clear();
            Console.WriteLine($"{margen1}\n║\tBienvenido al Banco de Lui\t║ \n║\t   ¿Qué desea hacer?\t\t║");
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
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
                Console.WriteLine($"{margen1}\n║\tBienvenido al Banco de Lui\t║ \n║\t   ¿Qué desea hacer?\t\t║");
                Console.WriteLine($"{margen3}\n{margen4}\n║\t1. Alta de usuario\t\t║\n{margen4}\n║\t2. Ingresar al sistema\t\t║\n{margen4}\n║\t3. Ver Usuarios\t\t\t║\n{margen4}\n║\t4. Salir\t\t\t║\n{margen2}");
                Console.Write("Ingrese una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

            }
        }
        static void IngresarSistema()
        {
            string margen1 = "╔═══════════════════════════════════════╗";
            string margen2 = "╚═══════════════════════════════════════╝";
            string margen3 = "║═══════════════════════════════════════║";
            string margen4 = "║                                       ║";
            Console.Clear();
            Console.WriteLine($"{margen1}\n║\t\tSistema\t\t\t║ \n║\t   ¿Qué desea hacer?\t\t║");
            Console.WriteLine($"{margen3}\n{margen4}\n║\t1. Ver saldo\t\t\t║\n{margen4}\n║\t2. Abonar cuenta\t\t║\n{margen4}\n║\t3. Retirar dinero\t\t║\n{margen4}\n║\t4. Transferir dinero\t\t║\n{margen4}\n║\t5. Ver movimientos\t\t║\n{margen4}\n║\t6. Salir\t\t\t║\n{margen2}");
            Console.Write("Ingrese una opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());
            while (opcion != 6)
            {
                switch (opcion)
                {
                    case 1:
                        // VerSaldo();
                        break;
                    case 2:
                        // AbonarCuenta();
                        break;
                    case 3:
                        // RetirarDinero();
                        break;
                    case 4:
                        // TransferirDinero();
                        break;
                    case 5:
                        // VerMovimientos();
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
                Console.Clear();

                Console.WriteLine($"{margen1}\n║\t\tSistema\t\t\t║ \n║\t   ¿Qué desea hacer?\t\t║");
                Console.WriteLine($"{margen3}\n{margen4}\n║\t1. Ver saldo\t\t\t║\n{margen4}\n║\t2. Abonar cuenta\t\t║\n{margen4}\n║\t3. Retirar dinero\t\t║\n{margen4}\n║\t4. Transferir dinero\t\t║\n{margen4}\n║\t5. Ver movimientos\t\t║\n{margen4}\n║\t6. Salir\t\t\t║\n{margen2}");
                Console.Write("Ingrese una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());
            }
            Console.Clear();
        }
    }
}