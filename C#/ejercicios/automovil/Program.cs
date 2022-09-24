namespace Estructuras
{
    class Program
    {
        struct Auto
        {
            // Se asignan atributos de la estructura Auto
            public string marca;
            public string modelo;
            public int ano;
            public string color;

            public string placa;

            public bool disponible;

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al programa de alquiler de autos");
            Console.Write("\n\nIngrese una opcion:\n1. Dar de alta un auto\n2. Dar de baja un auto\n3. Alquilar un auto\n4. Devolver un auto\n5. Consultar disponibilidad de un auto\n6. Salir\n\nOpcion: ");
            int opcion = Convert.ToInt32(Console.ReadLine());
            while (opcion != 6)
            {
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Dar de alta un auto:\n");
                        altaAuto();
                        break;
                    case 2:
                        Console.WriteLine("Dar de baja un auto:\n");

                        break;
                    case 3:
                        Console.WriteLine("Rentar un auto:\n");
                        rentarAuto();
                        break;
                    case 4:
                        Console.WriteLine("Devolver un auto:\n");
                        devolverAuto();
                        break;
                    case 5:
                        Console.WriteLine("Consultar disponibilidad de un auto:\n");
                        verAuto();
                        break;
                    default:
                        Console.WriteLine("Opcion invalida");
                        break;
                }
                Console.Write("\n\nIngrese una opcion:\n1. Dar de alta un auto\n2. Dar de baja un auto\n3. Alquilar un auto\n4. Devolver un auto\n5. Consultar disponibilidad de un auto\n6. Editar un auto\nSalir\n\nOpcion: ");
                opcion = Convert.ToInt32(Console.ReadLine());
            }
        }

        // Se define una lista de tipo Auto para almacenar los autos que se van a registrar
        static List<Auto> autos = new List<Auto>();

        // Se define un método para dar de alta un auto
        static void altaAuto()
        {

            // Se crea un objeto de tipo Auto
            Auto auto = new Auto();


            Console.Write("Ingrese la marca del auto: ");
            auto.marca = Console.ReadLine();
            Console.Write("Ingrese el modelo del auto: ");
            auto.modelo = Console.ReadLine();
            Console.Write("Ingrese el año del auto: ");
            auto.ano = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el color del auto: ");
            auto.color = Console.ReadLine();
            Console.Write("Ingrese la placa del auto: ");
            auto.placa = Console.ReadLine();
            Console.Write("Ingrese la disponibilidad del auto si/no: ");
            if (Console.ReadLine() == "si")
            {
                auto.disponible = true;
            }
            else
            {
                auto.disponible = false;
            }
            // Se comprueba que el auto no haya sido registrado previamente
            bool placaRepetida = false;
            foreach (Auto carro in autos)
            {
                if (carro.placa == auto.placa)
                {
                    placaRepetida = true;
                    break;
                }
            }
            if (placaRepetida)
            {
                Console.WriteLine("\nAtencion: El auto ya ha sido registrado");
            }
            else
            {
                // Se agrega el auto a la lista de autos
                autos.Add(auto);
                Console.WriteLine($"\nEl auto con las placas {auto.placa} ha sido registrado exitosamente");
            }

        }
        static void verAuto()
        {
            Console.Write("\n1. Ver lista de todos los autos\n2. Ver autos rentados\n3. Ver autos disponibles\n4. Salir\n\nOpcion: ");
            int opcion_busqueda = Convert.ToInt32(Console.ReadLine());
            switch (opcion_busqueda)
            {
                case 1:
                    for (int i = 0; i < autos.Count; i++)
                    {
                        Console.WriteLine($"Marca: {autos[i].marca}\nModelo: {autos[i].modelo}\nAño: {autos[i].ano}\nColor: {autos[i].color}\nPlaca: {autos[i].placa}\nDisponible: {autos[i].disponible}\n");
                    }
                    break;
                case 2:
                    for (int i = 0; i < autos.Count; i++)
                    {
                        if (autos[i].disponible == false)
                        {
                            Console.WriteLine($"\nMarca: {autos[i].marca}\nModelo: {autos[i].modelo}\nAño: {autos[i].ano}\nColor: {autos[i].color}\nPlaca: {autos[i].placa}\nDisponible: {autos[i].disponible}\n");
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < autos.Count; i++)
                    {
                        if (autos[i].disponible == true)
                        {
                            Console.WriteLine($"Marca: {autos[i].marca}\nModelo: {autos[i].modelo}\nAño: {autos[i].ano}\nColor: {autos[i].color}\nPlaca: {autos[i].placa}\nDisponible: {autos[i].disponible}\n");
                        }
                    }
                    break;
                case 4:
                    Console.WriteLine("Gracias por usar el programa");
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;

            }
        }
        static void devolverAuto()
        {
            Console.Write("\nIngrese la placa del auto: ");
            string placa = Console.ReadLine();

            for (int i = 0; i < autos.Count; i++)
            {
                if (autos[i].placa == placa)
                {
                    Auto car = autos[i];
                    car.disponible = true;
                    Console.WriteLine("El auto ha sido regresado");
                }
            }
        }

        static void rentarAuto()
        {
            Console.Write("\nIngrese la placa del auto que desea rentar: ");
            string placa = Console.ReadLine();
            foreach (Auto car in autos)
            {
                if (car.placa == placa)
                {
                    if (car.disponible == true)
                    {
                        Auto car2 = car;
                        car2.disponible = false;
                        Console.WriteLine("El auto ha sido rentado");
                    }
                    else
                    {
                        Console.WriteLine("El auto no está disponible");
                    }
                }
            }
        }




    }
}