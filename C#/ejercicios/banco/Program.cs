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
            string margen1 = "╔═══════════════════════════════════════╗";
            string margen2 = "╚═══════════════════════════════════════╝";
            string margen3 = "║═══════════════════════════════════════║";

            Console.WriteLine($"{margen1}\n║Bienvendio al Banco de Lui\t\t\n║Que desea hacer?\t\t\t║\n║1. Alta de usuario║\n║2. Ingresar al sistema║\n║3. Salir del sistema║4. Ver cuenta║\n{margen2}");

            int opcion = int.Parse(Console.ReadLine());
            while (opcion != 5)
            {
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine($"{margen1}\n║Alta de usuario\t\t\t\n║Nombre\t\t\t\t\t║\n{margen3}");

                        AltaCuenta();
                        break;
                    case 2:

                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
            }

        }

        static void AltaCuenta()
        {
            Cuenta cuenta = new Cuenta();

            Console.WriteLine("Ingrese su nombre: ");
            cuenta.nombre = Console.ReadLine();
            cuenta.NoCuenta = cuentas.Count + 1;
            Console.WriteLine("Ingrese su nip: ");
            // ternary operator for nip
            cuenta.nip = Console.ReadLine()?.Length == 4 ? Console.ReadLine() : "0000";
            Console.WriteLine("Ingrese su monto: ");
            cuenta.monto = double.Parse(Console.ReadLine());

            cuentas.Add(cuenta);
            Console.WriteLine("Cuenta creada con exito");
            Console.WriteLine($"Su numero de cuenta es: {cuenta.NoCuenta} y su nip es: {cuenta.nip} su monto es: {cuenta.monto}, su nombre es: {cuenta.nombre}");
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
    }
}