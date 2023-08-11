namespace examenfinal
{
    // Programa 1
    class Program
    {
        struct Materia
        {
            public string nombre;
            public double calificacion;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Ingresar materias");
            Console.WriteLine("¿Cuántas materias quiere ingresar?");
            int num = Convert.ToInt32(Console.ReadLine());
            Materia[] m = new Materia[num];
            for (int i = 0; i < num; i++)
            {
                Console.Write($"Ingrese la materia #{i + 1}: ");
                m[i].nombre = Console.ReadLine();

            }
            Console.WriteLine("");
            for (int i = 0; i < num; i++)
            {
                Console.Write($"Ingrese la calificación de {m[i].nombre}: ");
                m[i].calificacion = Convert.ToDouble(Console.ReadLine());

            }
            Console.WriteLine("");
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine($"Tu calificación de {m[i].nombre} es: {m[i].calificacion}");
            }

        }
        // Programa 2

        static void PrimeNumbers()
        {
            Console.WriteLine("Cuántos números primos desea ingresar?");
            int n = int.Parse(Console.ReadLine());
            int[] primos = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Ingrese el número " + (i + 1));
                int num = int.Parse(Console.ReadLine());
                primos[i] = num;
            }
            Console.WriteLine("Los números que son primos son:");
            for (int i = 0; i < n; i++)
            {
                int num = primos[i];
                bool primo = true;
                for (int l = 2; l < num; l++)
                {
                    if (num % l == 0)
                    {
                        primo = false;
                        break;
                    }
                }
                if (primo)
                {
                    Console.WriteLine(num + " es número primo");
                }
                else
                {
                    Console.WriteLine(num + " no es número primo");
                }
            }

        }
        // Programa 3
        static void IvaODescuento()
        {
            Console.Clear();
            Console.WriteLine("Programa 03 - Seleccione una opción: ");
            Console.WriteLine("1. IVA\n2. Descuento");
            int opcion = int.Parse(Console.ReadLine());
            while (opcion != 1 && opcion != 2)
            {
                Console.WriteLine("Opción inválida, intente de nuevo: ");
                opcion = int.Parse(Console.ReadLine());
            }
            Console.Write("Ingrese el precio del producto: ");
            double precio = double.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.WriteLine($"El precio del producto con IVA es: {precio * 1.16}");
                    break;
                case 2:
                    Console.Write("Ingrese el porcentaje de descuento: ");
                    double descuento = double.Parse(Console.ReadLine());
                    Console.WriteLine($"El descuento calculado es: {precio * (descuento / 100)} y el precio final es: {precio - (precio * (descuento / 100))}");
                    break;
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        //Programa 4
        static void Renta()
        {
            Console.Clear();
            Console.Write("Programa 4 - Declaración de la renta: ");
            Console.Write("Ingrese renta mensual: ");
            double renta = double.Parse(Console.ReadLine());
            double total = 0, porcentaje_impuesto = 0, renta_anual = renta * 12;
            if (renta_anual < 10000)
            {
                porcentaje_impuesto = 5;
                total = (renta * 12) + (renta * 12 * (porcentaje_impuesto / 100));
            }
            else if (renta_anual >= 10000 && renta_anual < 20000)
            {
                porcentaje_impuesto = 15;
                total = (renta * 12) + (renta * 12 * (porcentaje_impuesto / 100));
            }
            else if (renta_anual >= 20000 && renta_anual < 35000)
            {
                porcentaje_impuesto = 20;
                total = (renta * 12) + (renta * 12 * (porcentaje_impuesto / 100));
            }
            else if (renta_anual >= 35000 && renta_anual < 60000)
            {
                porcentaje_impuesto = 30;
                total = (renta * 12) + (renta * 12 * (porcentaje_impuesto / 100));
            }
            else if (renta_anual >= 60000)
            {
                porcentaje_impuesto = 45;
                total = (renta * 12) + (renta * 12 * (porcentaje_impuesto / 100));
            }
            Console.WriteLine($"Su renta mensual es: {renta}\nTotal de renta anual: {renta * 12}\nPorcentaje de impuesto: {porcentaje_impuesto}%\nTotal a pagar con impuesto: {total}");
        }
    }

}
