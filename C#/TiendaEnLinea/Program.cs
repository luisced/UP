namespace proyecto

{
    class Program
    {
        struct Prenda
        {
            public int id;
            public string prenda;
            public string marca;
            public int talla;
            public int precio;
            public string color;
            public bool disponibilidad;
        }
        struct Venta
        {
            public int id;
            public double total;

            public List<Prenda> prendas; //Agregamos una lista de prendas

        }

        // Se crea una lista de ventas donde se guardaran las ventas realizadas
        static List<Venta> ventas = new List<Venta>();

        //  Se crea una lista de prendas donde se guardaran las prendas disponibles
        static List<Prenda> catalogo = new List<Prenda>{
            new Prenda { id = 1, prenda = "Camisa", marca = "Zara", talla = 40, precio = 10000, color = "Rojo", disponibilidad = true },
            new Prenda { id = 2, prenda = "Pantalon", marca = "Nike", talla = 40, precio = 10000, color = "Rojo", disponibilidad = true },
            new Prenda { id = 3, prenda = "Camisa", marca = "Adidas", talla = 40, precio = 10000, color = "Rojo", disponibilidad = true },
            new Prenda { id = 4, prenda = "Pantalon", marca = "Puma", talla = 40, precio = 10000, color = "Rojo", disponibilidad = true },
            new Prenda { id = 5, prenda = "Camisa", marca = "A&E", talla = 40, precio = 10000, color = "Rojo", disponibilidad = true },
            new Prenda { id = 6, prenda = "Pantalon", marca = "HM", talla = 40, precio = 10000, color = "Rojo", disponibilidad = true },
            new Prenda { id = 7, prenda = "Camisa", marca = "F21", talla = 40, precio = 10000, color = "Rojo", disponibilidad = true },
            new Prenda { id = 8, prenda = "Pantalon", marca = "Banana", talla = 40, precio = 10000, color = "Rojo", disponibilidad = true },
            new Prenda { id = 9, prenda = "Camisa", marca = "LV", talla = 40, precio = 10000, color = "Rojo", disponibilidad = true },
            new Prenda { id = 10, prenda = "Pantalon", marca = "Gucci", talla = 40, precio = 10000, color = "Rojo", disponibilidad = true },
            new Prenda { id = 11, prenda = "Camisa", marca = "Praga", talla = 40, precio = 10000, color = "Rojo", disponibilidad = true },
        };



        static Venta CrearVenta()
        {
            // Se crea una nueva venta
            Venta venta = new Venta();
            Console.Write("Ingrese la cantidad de prendas: ");
            int cantidad = int.Parse(Console.ReadLine());
            venta.prendas = new List<Prenda>();
            for (int i = 0; i < cantidad; i++)
            {
                Console.Write("Ingrese el id de la prenda: ");
                int id = int.Parse(Console.ReadLine());
                Prenda prenda = catalogo.Find(x => x.id == id);
                venta.prendas.Add(prenda);
                venta.total += prenda.precio;
            }
            venta.id = ventas.Count + 1;

            return venta;
        }
        static void Main(string[] args)
        {
            Menu();
        }

        static Prenda CrearPrenda()
        {
            Prenda prenda = new Prenda();
            Console.Write("Ingrese el nombre de la prenda: ");
            prenda.prenda = Console.ReadLine();
            Console.Write("Ingrese la marca de la prenda: ");
            prenda.marca = Console.ReadLine();
            Console.Write("Ingrese la talla de la prenda: ");
            prenda.talla = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el precio de la prenda: ");
            prenda.precio = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el color de la prenda: ");
            prenda.color = Console.ReadLine();
            Console.Write("Ingrese la disponibilidad de la prenda: ");
            prenda.disponibilidad = bool.Parse(Console.ReadLine());
            prenda.id = ventas[0].prendas.Count + 1;
            // añaadimos la prenda a la lista de prendas
            Venta venta = ventas[ventas.Count - 1];
            venta.prendas.Add(prenda);
            return prenda;

        }

        static void VerPrendasDisponibles()
        {
            foreach (Prenda prenda in catalogo)
            {
                if (prenda.disponibilidad == true)
                {
                    Console.WriteLine("Id: " + prenda.id + " Prenda: " + prenda.prenda + " Marca: " + prenda.marca + " Talla: " + prenda.talla + " Precio: " + prenda.precio + " Color: " + prenda.color + " Disponibilidad: " + prenda.disponibilidad);
                }
            }
        }

        static void VerVentas()
        {
            foreach (Venta venta in ventas)
            {
                Console.WriteLine("Id: " + venta.id);
                Console.WriteLine("Total: " + venta.total);
                Console.WriteLine("Prendas: ");
                foreach (Prenda prenda in venta.prendas)
                {
                    Console.WriteLine("\tId: " + prenda.id);
                    Console.WriteLine("\tPrenda: " + prenda.prenda);
                    Console.WriteLine("\tMarca: " + prenda.marca);
                    Console.WriteLine("\tTalla: " + prenda.talla);
                    Console.WriteLine("\tPrecio: " + prenda.precio);
                    Console.WriteLine("\tColor: " + prenda.color);
                    Console.WriteLine("\tDisponibilidad: " + prenda.disponibilidad);

                }
            }
        }

        static void Menu()
        {
            Console.Write("1. Crear prenda\n2. Ver prendas disponibles\n3. Crear venta\n4. Ver ventas\n5. Salir\nIngrese una opción: ");
            int opcion = int.Parse(Console.ReadLine());
            while (opcion != 5)
            {
                switch (opcion)
                {
                    case 1:
                        CrearPrenda();
                        break;
                    case 2:
                        VerPrendasDisponibles();
                        break;
                    case 3:
                        ventas.Add(CrearVenta());
                        break;
                    case 4:
                        VerVentas();
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
                Console.Write("1. Crear prenda\n2. Ver prendas disponibles\n3. Crear venta\n4. Ver ventas\n5. Salir\nIngrese una opción: ");
                opcion = int.Parse(Console.ReadLine());
            }

        }

    }
}
