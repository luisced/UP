namespace ExamenFinal
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Clear();
            ClasesCalificacion();
            NumerosPrimos();
            IvaODescuento();
            Renta();
        }

        // Primer Ejercicio
        static void ClasesCalificacion()
        {
            Console.Write("Programa 01 - Ingrese el número de materias: ");
            int n = int.Parse(Console.ReadLine());

            string[] materias = new string[n];
            int[] calificaciones = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Ingrese el nombre de la materia {i + 1}: ");
                materias[i] = Console.ReadLine();
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Ingrese la calificación de la materia {i + 1}: ");
                calificaciones[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Materias y calificaciones");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{materias[i]} - {calificaciones[i]}");
            }


            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        // Segundo Ejercicio
        static void NumerosPrimos()
        {
            Console.Clear();
            Console.Write("Programa 02 - Cuántos números enteros desea ingresar?: ");
            int n = int.Parse(Console.ReadLine());
            List<int> numeros = new List<int>();
            for (int i = 0; i < n; i++)
            {
                Console.Write("Ingrese el número: ");
                numeros.Add(int.Parse(Console.ReadLine()));
            }
            Console.WriteLine("Los números primos son: ");
            foreach (var numero in numeros)
            {
                Console.WriteLine(numero + (EsPrimo(numero) ? " es primo" : " no es primo"));
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        static bool EsPrimo(int numero)
        {
            int contador = 0;
            for (int i = 1; i <= numero; i++)
            {
                if (numero % i == 0)
                {
                    contador++;
                }
            }
            if (contador == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Tercer Ejercicio
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

        // Cuarto Ejercicio
        static void Renta()
        {
            Console.Clear();
            Console.Write("Programa 04 - Declaración de renta: ");
            Console.Write("Ingrese su renta mensual: ");
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
            Console.WriteLine($"Su renta mensual: {renta}\nTotal de renta anual: {renta * 12}\nPorcentaje de impuesto: {porcentaje_impuesto}%\nTotal a pagar con impuesto: {total}");
        }

    }
}