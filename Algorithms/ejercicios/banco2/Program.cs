using System;

namespace ProgramaBanco
{
    class Program
    {
        struct Cuenta
        {
            public string Nombre;
            public int NumCuenta;
            public int NIP;
            public double Saldo;
        }
        static void Menu()
        {
            Console.WriteLine("Bienvenid@, por favor selecciona una opcion");
            Console.WriteLine("1) Alta de usuario");
            Console.WriteLine("2) Acceder al Sitema");
            Console.WriteLine("3) Salir");
        }
        static void Submenu(Cuenta cuenta)
        {
            // Cuenta temp = new Cuenta();
            Console.Clear();
            Console.WriteLine("Accediendo al sistema");
            Console.WriteLine("Ingresa tu NIP: ");
            int NIP = int.Parse(Console.ReadLine());
            if (NIP == cuenta.NIP)
            {
                Console.WriteLine($"Bienvenid@ {cuenta.Nombre}");
                Console.WriteLine("1) Ver Saldo");
                Console.WriteLine("2) Abonar");
                Console.WriteLine("3) Retirar");
                Console.WriteLine("4) Ver datos de usuario");
                Console.WriteLine("5) Salir");
                Console.Write("Elegir opcion: ");
            }
            else
            {
                Console.WriteLine("Lo siento, su NIP no es valido");
            }
        }
        static void Main(string[] args)
        {
            Cuenta cuenta = new Cuenta();
            bool correrPrograma = true;
            while (correrPrograma)
            {
                Menu();
                int opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        cuenta = AltaUsuario(cuenta);
                        LimpiarConsola();
                        break;
                    case 2:
                        Menu2(cuenta);
                        break;
                    case 3:
                        correrPrograma = false;
                        Console.WriteLine("Hasta luego...");
                        break;
                    default:
                        Console.Write("Opcion no valida. ");
                        LimpiarConsola();
                        break;
                }
            }
        }
        static void Menu2(Cuenta cuenta)
        {
            bool correrPrograma = true;
            while (correrPrograma)
            {
                Submenu(cuenta);
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        VerSaldo(cuenta);
                        LimpiarConsola();
                        break;
                    case 2:
                        cuenta.Saldo += Abonar(cuenta);
                        break;
                    case 3:
                        Retiro(cuenta);
                        correrPrograma = false;

                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("Datos del Cliente");
                        Console.WriteLine($"Nombre {cuenta.Nombre}\t Numero de Cuenta:{cuenta.NumCuenta},\t NIP: {cuenta.NIP}, \t Saldo: {cuenta.Saldo}");
                        break;
                    case 5:
                        correrPrograma = false;
                        Console.WriteLine("Hasta luego...");
                        break;
                    default:
                        Console.Write("Opcion no valida. ");
                        LimpiarConsola();
                        break;
                }
            }
        }
        static void LimpiarConsola()
        {
            Console.Write("Presione Enter para continuar...");
            Console.ReadLine();
            Console.Clear();
        }
        static Cuenta AltaUsuario(Cuenta cuenta)
        {
            Console.WriteLine("Alta de Usuario");
            Console.Write("Ingresa tu nombre: ");
            cuenta.Nombre = Console.ReadLine();
            Console.Write("Ingresa tu numero de cuenta: ");
            cuenta.NumCuenta = int.Parse(Console.ReadLine());
            Console.Write("Ingrese su NIP de 4 digitos: ");
            cuenta.NIP = int.Parse(Console.ReadLine());
            Console.Write("Ingrese su saldo: ");
            cuenta.Saldo = double.Parse(Console.ReadLine());

            Console.Write($"Su numero de cuenta es {cuenta.NumCuenta}: Usuario dado de alta correctamente...\n");

            return cuenta;
        }
        static void VerSaldo(Cuenta a)
        {
            Console.WriteLine($"Tu Saldo es de {a.Saldo}");

        }
        static double Abonar(Cuenta cuenta)
        {
            Console.WriteLine("¿Cuanto deseas abonar a tu cuenta?");
            double abono1 = double.Parse(Console.ReadLine());

            Console.WriteLine($"Se ha abonado {abono1} a tu cuenta");
            return abono1;
        }

        static void Retiro(Cuenta cuenta)
        {
            Console.WriteLine("¿Cuanto deseas retirar de tu cuenta?");
            double retiro1 = double.Parse(Console.ReadLine());
            if (retiro1 > cuenta.Saldo)
            {
                Console.WriteLine("No tienes suficiente saldo");
            }
            else
            {
                cuenta.Saldo -= retiro1;
                Console.WriteLine($"Se ha retirado {retiro1} de tu cuenta");
            }
        }
    }

}
//static double Retirar(Cuenta cuenta)
//{
//    Console.WriteLine("¿Cuanto deseas retir de tu cuenta?");
//    double retiro1 = double.Parse(Console.ReadLine());
//    if (cuenta.Saldo - retiro1 >= 0)
//    {
//        Console.WriteLine($"Se han retirado {retiro1} de tu cuenta");
//        cuenta.Saldo -= retiro1;
//        return cuenta.Saldo;
//    }
//    else
//    {
//        Console.WriteLine("Saldo insuficiente");

//    return 0;
//    }
