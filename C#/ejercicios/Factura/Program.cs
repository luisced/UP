namespace Factura
{
    class Program
    {
        static void Main(string[] args)
        {
            // Se definen variables
            string id, nombre;
            double cantidad, temp, sobrecarga = 0, total = 0;

            // Se solicitan datos del cliente
            Console.Write("Ingrese su ID de usuario: ");
            id = Console.ReadLine();
            Console.Write("Ingrese su nombre: ");
            nombre = Console.ReadLine();
            Console.Write("Ingrese la cantidad de energía: ");
            cantidad = Convert.ToDouble(Console.ReadLine());

            // En esta condicional se evalua la cantidad de energía consumida y se estima el consumo extra
            if (cantidad <= 199)
            {
                temp = cantidad * 1.20;
            }
            else if (cantidad >= 200 && cantidad <= 399)
            {
                temp = cantidad * 1.50;
            }
            else if (cantidad >= 400 && cantidad <= 599)
            {
                temp = cantidad * 1.80;
            }
            else
            {
                temp = cantidad * 2;
            }

            // Este if checha la sobrecarga
            if (cantidad > 300)
            {
                total = temp * 1.15;
                sobrecarga = temp * 0.15;
            }
            else if (cantidad <= 99)
            {
                total = 100;
            }
            else
            {
                total = temp;
            }

            Console.WriteLine($"ID Cliente:{id}\nNombre del Cliente:{nombre}\nConsumo:{cantidad}\nTotal por consumo @Rs. p/unidad:{temp}\nTotal por sobrecarga: {sobrecarga} \nTotal a pagar:\t\t{total}");


        }
    }
}