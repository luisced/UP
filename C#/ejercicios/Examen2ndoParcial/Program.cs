namespace UserSocialMedia
{
    struct Dish
    {
        public string name;
        public string type;
        public int rate;
    }
    struct User
    {
        public string name;
        public string username;
        public string password;
        public Dish favoriteDish;


    }
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
        static User EditUserInfo(User user)
        {
            Console.Clear();
            Console.Write("Ingrese nuevo nombre: ");
            user.name = Console.ReadLine();
            Console.Write("Ingrese nuevo username: ");
            user.username = Console.ReadLine();
            Console.Write("Ingrese nuevo password: ");
            Console.WriteLine($"Su nueva información es: Nombre:{user.name}, Username: {user.username}, Password: {user.password}");
            return user;
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
                            ShowMenu(user);
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

        static void ShowMenu(User user)
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
                        EditUserInfo(user);
                        break;
                    case 3:
                        // EditFavoriteDish(user);
                        break;
                    case 4:
                        // ShowFavoriteDish(user);
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
                Console.WriteLine("Que desea hacer?\n1. - Ver información de usuario\n2. - Editar información de usuario\n3. - Alta/edición de Platillo favorito\n4. Ver Platillo Favorito\n5. Salir\nIngrese la opción deseada: ");
                option = int.TryParse(Console.ReadLine(), out option) ? option : 0;
            }

        }
        static void Main(string[] args)
        {
            Console.Clear();
            EnterSystem();

        }
    }
}