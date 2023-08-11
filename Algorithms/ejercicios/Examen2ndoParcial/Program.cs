namespace UserSocialMedia
{
    struct Dish
    {
        public string name;
        public string type;
        public float rate;
    }
    struct User
    {
        public string name;
        public string username;
        public string password;
        public Dish favoriteDish;


    }
    // array of user


    class Program
    {
        static User RegisterUser()
        {
            User user = new User();

            Console.Write("Enter your name: ");
            user.name = Console.ReadLine();
            Console.Write("Enter your username: ");
            user.username = Console.ReadLine();
            Console.Write("Enter your password: ");
            user.password = Console.ReadLine();
            Console.WriteLine($"Su usuario es: {user.username} y su contraseña es: {user.password}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            return user;
        }

        static void ShowUserInfo(User user)
        {
            Console.Clear();
            Console.Write($"Name: {user.name} Username: {user.username} Password: {user.password}\n");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        // edit user info
        static User EditUserInfo(User user)
        {
            Console.Clear();
            Console.WriteLine("1. Editar nombre\n2. Editar usuario\n3. Editar contraseña\n4. Salir");
            Console.Write("Seleccione una opción: ");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.Write("Ingrese su nuevo nombre: ");
                    user.name = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Ingrese su nuevo usuario: ");
                    user.username = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("Ingrese su nueva contraseña: ");
                    user.password = Console.ReadLine();
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }
            return user;
        }

        static Dish RegisterDish(User user)
        {
            Dish dish = new Dish();
            Console.Write("Ingrese el nombre del plato: ");
            dish.name = Console.ReadLine();
            Console.Write("Ingrese el tipo de plato: ");
            dish.type = Console.ReadLine();
            Console.Write("Ingrese la calificación del plato: ");
            dish.rate = float.Parse(Console.ReadLine());


            return dish;
        }
        static Dish ShowDishInfo(User user)
        {
            Console.Clear();
            Console.Write($"Nombre del plato: {user.favoriteDish.name} Tipo de plato: {user.favoriteDish.type} Calificación: {user.favoriteDish.rate}/5.0\n");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            return user.favoriteDish;
        }


        static void EnterSystem()
        {
            int option;
            Console.Clear();
            Console.Write("Menu: \n1. - Alta de usuario \n2. - Ingresar al sistema \n3. - Salir \n");
            option = int.Parse(Console.ReadLine());
            User user = new User();
            while (option != 3)
            {
                switch (option)
                {
                    case 1:
                        user = RegisterUser();
                        break;
                    case 2:
                        Console.Write("Ingrese su password: ");
                        if (Console.ReadLine() == user.password)
                        {
                            Console.WriteLine("Bienvenido al sistema");
                            user = ShowMenu(user);
                        }
                        else
                        {
                            Console.WriteLine("Contraseña incorrecta");
                            Console.WriteLine("Presione cualquier tecla para continuar...");
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Opcion invalida");
                        break;
                }
                Console.Clear();
                Console.Write("Menu: \n1. - Alta de usuario \n2. - Ingresar al sistema \n3. - Salir \n");
                option = int.Parse(Console.ReadLine());
            }

        }

        static User ShowMenu(User user)
        {

            int option;
            Console.Clear();
            Console.WriteLine($"Bienvendio al sistema de usuarios {user.username}\nQue desea hacer?\n1. - Ver información de usuario\n2. - Editar información de usuario\n3. - Alta/edición de Platillo favorito\n4. Ver Platillo Favorito\n5. Salir\nIngrese la opción deseada: ");
            option = int.TryParse(Console.ReadLine(), out option) ? option : 0;
            while (option < 5 && option > 0)
            {
                switch (option)
                {
                    case 1:
                        ShowUserInfo(user);
                        break;
                    case 2:
                        user = EditUserInfo(user);
                        break;
                    case 3:
                        user.favoriteDish = RegisterDish(user);
                        break;
                    case 4:
                        ShowDishInfo(user);
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
                Console.WriteLine("Que desea hacer?\n1. - Ver información de usuario\n2. - Editar información de usuario\n3. - Alta/edición de Platillo favorito\n4. Ver Platillo Favorito\n5. Salir\nIngrese la opción deseada: ");
                option = int.TryParse(Console.ReadLine(), out option) ? option : 0;
            }
            return user;

        }
        static void Main(string[] args)
        {
            Console.Clear();
            EnterSystem();

        }
    }
}