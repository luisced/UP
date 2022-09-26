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
        // Se define una lista de tipo Auto para almacenar los autos que se van a registrar
        static List<Auto> autos = new List<Auto>
        {
            new Auto { marca = "Chevrolet", modelo = "Spark", ano = 2017, color = "Azul", placa = "EFG456", disponible = true },
            new Auto { marca = "Toyota", modelo = "Corolla", ano = 2015, color = "Blanco", placa = "ABC-123", disponible = true },
            new Auto { marca = "Nissan", modelo = "Versa", ano = 2016, color = "Rojo", placa = "XYZ-789", disponible = true },
            new Auto { marca = "Mazda", modelo = "3", ano = 2018, color = "Negro", placa = "ACD-345", disponible= false },
        };
        static void Main(string[] args)
        {

            Console.WriteLine("Bienvenido al programa de alquiler de autos");
            Console.Write("\n\nIngrese una opcion:\n1. Dar de alta un auto\n2. Dar de baja un auto\n3. Rentar un auto\n4. Devolver un auto\n5. Consultar disponibilidad de un auto\n6. Editar un auto\n7. Salir\n\nOpcion: ");

            int opcion = Convert.ToInt32(Console.ReadLine());
            while (opcion != 7)
            {
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Dar de alta un auto:\n");
                        altaAuto();
                        break;
                    case 2:
                        Console.WriteLine("Dar de baja un auto:\n");
                        bajaAuto();
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
                    case 6:
                        Console.WriteLine("Editar un auto:\n");
                        editarAuto();
                        break;
                    default:
                        Console.WriteLine("Opcion invalida");
                        break;
                }
                Console.Write("\n\nIngrese una opcion:\n1. Dar de alta un auto\n2. Dar de baja un auto\n3. Alquilar un auto\n4. Devolver un auto\n5. Consultar disponibilidad de un auto\n6. Editar un auto\n7. Salir\n\nOpcion: ");
                opcion = Convert.ToInt32(Console.ReadLine());
            }
        }
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


        static void rentarAuto()
        {
            Console.Write("\nIngrese la placa del auto que desea rentar: ");
            string placa = Console.ReadLine();
            // lista temporal
            List<Auto> autosTemp = new List<Auto>();
            for (int i = 0; i < autos.Count; i++)
            {
                if (autos[i].placa == placa)
                {
                    Auto car = autos[i];
                    car.disponible = false;
                    autosTemp.Add(car);
                    Console.WriteLine("El auto ha sido rentado");
                    autos.RemoveAt(i);
                }
            }
            autos.AddRange(autosTemp);
        }
        static void devolverAuto()
        {
            Console.Write("\nIngrese la placa del auto: ");
            string placa = Console.ReadLine();
            List<Auto> autosTemp = new List<Auto>();
            for (int i = 0; i < autos.Count; i++)
            {
                if (autos[i].placa == placa)
                {
                    Auto car = autos[i];
                    car.disponible = true;
                    autosTemp.Add(car);
                    Console.WriteLine("El auto ha sido devuelto");
                    autos.RemoveAt(i);
                }
            }
            autos.AddRange(autosTemp);
        }

        static void bajaAuto()
        {
            Console.Write("\nIngrese la placa del auto que desea dar de baja: ");
            string placa = Console.ReadLine();
            for (int i = 0; i < autos.Count; i++)
            {
                if (autos[i].placa == placa)
                {
                    autos.RemoveAt(i);
                    Console.WriteLine("El auto ha sido dado de baja");
                }
            }

        }

        static void editarAuto()
        {
            Console.Write("\nIngrese la placa del auto que desea editar: ");
            string placa = Console.ReadLine();
            List<Auto> autosTemp = new List<Auto>();
            for (int i = 0; i < autos.Count; i++)
            {
                if (autos[i].placa == placa)
                {
                    Auto car = autos[i];
                    Console.Write("Ingrese la marca del auto: ");
                    if (Console.ReadLine() != "")
                    {
                        car.marca = Console.ReadLine();
                    }
                    else
                    {
                        car.marca = autos[i].marca;
                    }
                    Console.Write("Ingrese el modelo del auto: ");
                    if (Console.ReadLine() != "")
                    {
                        car.modelo = Console.ReadLine();
                    }
                    else
                    {
                        car.modelo = autos[i].modelo;
                    }
                    Console.Write("Ingrese el año del auto: ");
                    if (Console.ReadLine() != "")
                    {
                        car.ano = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        car.ano = autos[i].ano;
                    }
                    Console.Write("Ingrese el color del auto: ");
                    if (Console.ReadLine() != "")
                    {
                        car.color = Console.ReadLine();
                    }
                    else
                    {
                        car.color = autos[i].color;
                    }
                    Console.Write("Ingrese la placa del auto: ");
                    if (Console.ReadLine() != "")
                    {
                        car.placa = Console.ReadLine();
                    }
                    else
                    {
                        car.placa = autos[i].placa;
                    }
                    Console.Write("Ingrese si el auto esta disponible si/no: ");
                    if (Console.ReadLine() != "")
                    {
                        if (Console.ReadLine() == "si")
                        {
                            car.disponible = true;
                        }
                        else
                        {
                            car.disponible = false;
                        }
                    }
                    else
                    {
                        car.disponible = autos[i].disponible;
                    }
                    autosTemp.Add(car);
                    autos.RemoveAt(i);
                }
                autos.AddRange(autosTemp);
            }
        }
    }
}
