namespace Estructuras
{
    class Program
    {
        struct Auto
        {
            public string marca;
            public string modelo;
            public int ano;
            public string color;

            public string placa;

            public bool disponible;

        }
        static void Main(string[] args)
        {
            //alta de coche, ver detalles del automovil, ver automóviles disponibles, ver automóviles rentados, salir
            altaAuto();
            verAuto();
        }

        static List<Auto> autos = new List<Auto>();

        static void altaAuto()
        {

            Auto auto;

            Console.WriteLine("Ingrese la marca del auto");
            auto.marca = Console.ReadLine();
            Console.WriteLine("Ingrese el modelo del auto");
            auto.modelo = Console.ReadLine();
            Console.WriteLine("Ingrese el año del auto");
            auto.ano = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el color del auto");
            auto.color = Console.ReadLine();
            Console.WriteLine("Ingrese la placa del auto");
            auto.placa = Console.ReadLine();
            Console.WriteLine("Ingrese si el auto esta disponible: si/no");
            if (Console.ReadLine() == "si")
            {
                auto.disponible = true;
            }
            else
            {
                auto.disponible = false;
            }

            autos.Add(auto);
            Console.WriteLine("Desea agregar otro auto? si/no");
            if (Console.ReadLine() == "si")
            {
                altaAuto();
            }
            else
            {
                Console.WriteLine("Gracias por usar el programa");
            }
        }
        static void verAuto()
        {
            Console.Write("\n1. Ver lista de todos los autos\n2. Ver autos rentados\n4. Salir\n");
            int opcion_busqueda = Convert.ToInt32(Console.ReadLine());
            switch (opcion_busqueda)
            {
                case 1:
                    for (int i = 0; i < autos.Count; i++)
                    {
                        Console.WriteLine($"{autos[i].marca} {autos[i].modelo} {autos[i].ano} {autos[i].color} {autos[i].placa} {autos[i].disponible}");
                    }
                    break;
                case 2:
                    for (int i = 0; i < autos.Count; i++)
                    {
                        if (autos[i].disponible == false)
                        {
                            Console.WriteLine($"{autos[i].marca} {autos[i].modelo} {autos[i].ano} {autos[i].color} {autos[i].placa} {autos[i].disponible}");
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;

            }


        }


    }
}