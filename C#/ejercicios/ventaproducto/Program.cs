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
            AgregarProducto();
            verProducto();
            verVenta();
        }
        static void AgregarProducto()
        {
            Producto producto = new Producto();
            Console.Write("Ingrese el SKU del producto: ");
            producto.SKU = Console.ReadLine();
            Console.Write("Ingrese el nombre del producto: ");
            producto.nombre = Console.ReadLine();
            Console.Write("Ingrese el costo del producto: ");
            producto.costo_producto = double.Parse(Console.ReadLine());
            Console.Write("Ingrese el precio de venta del producto: ");
            producto.precio_venta = double.Parse(Console.ReadLine());

            productos.Add(producto);
            agregarVenta(producto.SKU);
        }
        static void verProducto()
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
        static string agregarVenta(string sku)
        {
            Venta venta = new Venta();
            Console.WriteLine("Ingrese el ID de la venta");
            venta.id = Console.ReadLine();
            Console.WriteLine("Ingrese la cantidad de productos");
            venta.cantidad = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < productos.Count; i++)
            {
                if (productos[i].SKU == venta.producto.SKU)
                {
                    venta.producto = productos[i];
                    venta.total = venta.cantidad * venta.producto.precio_venta;

                }
            }

            ventas.Add(venta);
            return verVentaID(venta.id);


        }
        static void verVenta()
        {
            Console.Write("\n1. Ver lista de todas las ventas\n2. Ver venta por ID");
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