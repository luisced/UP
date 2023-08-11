namespace VentaDeProductos
{
    class Program
    {
        struct Producto
        {
            public string SKU;
            public string nombre;
            public double costo_producto;
            public double precio_venta;
        }
        struct Venta
        {
            public string id;
            public Producto producto;
            public int cantidad;
            public double total;
        }
        static List<Producto> productos = new List<Producto>();
        static List<Venta> ventas = new List<Venta>();
        static void Main(string[] args)
        {
            Console.Write("Bienvenido al sistema de ventas de productos");
            Console.WriteLine("\nQué desea hacer?\n");
            Console.Write("1. Agregar producto\n2. Ver Producto\n3. Registrar Venta\n4. Mostrar ventas\n5. Salir\n");

            int opcion = Convert.ToInt32(Console.ReadLine());
            while (opcion != 5)
            {
                switch (opcion)
                {
                    case 1:
                        AgregarProducto();
                        break;
                    case 2:
                        VerProducto();
                        break;
                    case 3:
                        AgregarVenta();
                        break;
                    case 4:
                        verVenta();
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
                Console.WriteLine("¿Qué desea hacer?\n");
                Console.Write("1. Agregar producto\n2. Ver Producto\n3. Registrar Venta\n4. Mostrar ventas\n5. Salir\n");

                opcion = Convert.ToInt32(Console.ReadLine());
            }
        }
        static void AgregarProducto()
        {
            Producto producto = new Producto();
            producto.SKU = (new Random()).Next(1000, 9999).ToString();
            Console.Write("Ingrese el nombre del producto: ");
            producto.nombre = Console.ReadLine();
            Console.Write("Ingrese el costo del producto: ");
            producto.costo_producto = double.Parse(Console.ReadLine());
            Console.Write("Ingrese el precio de venta del producto: ");
            producto.precio_venta = double.Parse(Console.ReadLine());

            productos.Add(producto);
        }
        static void VerProducto()
        {
            Console.Write("\n1. Ver lista de todos los productos\n2. Ver Producto por SKU");
            int opcion_busqueda = Convert.ToInt32(Console.ReadLine());
            switch (opcion_busqueda)
            {
                case 1:

                    for (int i = 0; i < productos.Count; i++)
                    {
                        Console.WriteLine($"SKU: {productos[i].SKU}\nNombre: {productos[i].nombre}\nCosto: {productos[i].costo_producto}\nPrecio de venta: {productos[i].precio_venta}");
                    }
                    break;
                case 2:
                    Console.WriteLine("Ingrese el SKU del producto");
                    string sku = Console.ReadLine();
                    for (int i = 0; i < productos.Count; i++)
                    {
                        if (productos[i].SKU == sku)
                        {
                            Console.WriteLine($"SKU: {productos[i].SKU}\nNombre: {productos[i].nombre}\nCosto: {productos[i].costo_producto}\nPrecio de venta: {productos[i].precio_venta}");
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;

            }


        }
        static void AgregarVenta()
        {
            Venta venta = new Venta();
            venta.id = (ventas.Count + 1).ToString();
            Console.Write("Ingrese la cantidad de productos: ");
            venta.cantidad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el SKU del producto");
            string sku = Console.ReadLine();

            for (int i = 0; i < productos.Count; i++)
            {
                if (productos[i].SKU == sku)
                {
                    venta.total = venta.cantidad * productos[i].precio_venta;
                }
            }

            ventas.Add(venta);


        }
        static void verVenta()
        {
            Console.Write("\n1. Ver lista de todas las ventas\n2. Ver venta por ID\n");
            int opcion_busqueda = Convert.ToInt32(Console.ReadLine());
            switch (opcion_busqueda)
            {
                case 1:

                    for (int i = 0; i < ventas.Count; i++)
                    {
                        Console.WriteLine($"ID: {ventas[i].id} Nombre: {ventas[i].producto.nombre} Cantidad: {ventas[i].cantidad} Total: {ventas[i].total}");
                    }
                    break;
                case 2:
                    Console.WriteLine("Ingrese el ID de la venta");
                    string id = Console.ReadLine();
                    for (int i = 0; i < ventas.Count; i++)
                    {
                        if (ventas[i].id == id)
                        {
                            Console.WriteLine($"ID: {ventas[i].id} Nombre: {ventas[i].producto.nombre} Cantidad: {ventas[i].cantidad} Total: {ventas[i].total}");
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;

            }
        }
        static string verVentaID(string ID)
        {
            for (int i = 0; i < ventas.Count; i++)
            {
                if (ventas[i].id == ID)
                {
                    return $"ID: {ventas[i].id}\nCantidad: {ventas[i].cantidad}\nTotal: {ventas[i].total}";
                }
            }
            return "No se encontro la venta";

        }
    }

}