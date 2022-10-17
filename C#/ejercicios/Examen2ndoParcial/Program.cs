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

        static bool EnterSystem(User user)
        {
            bool login = false;
            int option;
            Console.Clear();
            Console.Write("Menu: \n1. - Alta de usuario \n2. - Ingresar al sistema \n3. - Salir \n");
            option = int.Parse(Console.ReadLine());
            while (!login)
            {
                Console.Write("Enter your password: ");
                if (Console.ReadLine() == user.password)
                {
                    login = true;
                    if (option == 1)
                    {
                        RegisterUser();
                        EnterSystem(user);
                    }
                    else if (option == 2)
                    {
                        ShowMenu(user);
                    }
                    else if (option == 3)
                    {
                        Environment.Exit(0);
                    }

                }
                else
                {
                    Console.WriteLine("Login failed");
                }
            }
            return login;
        }

        static void ShowMenu(User user)
        {
            int option;
            Console.Clear();
            Console.WriteLine($"Bienvendio al sistema de usuarios {user.username}\nQue desea hacer?\n1. - Ver información de usuario\n2. - Editar información de usuario\n3. - Alta/edición de Platillo favorito\n4. Ver Platillo Favorito\n5. Salir\nIngrese la opción deseada: ");
            option = int.TryParse(Console.ReadLine(), out option) ? option : 0;
            while (option < 6 && option > 0)
            {
                switch (option)
                {
                    case 1:
                        ShowUserInfo(user);
                        break;
                    case 2:
                        // EditUserInfo(user);
                        break;
                    case 3:
                        // EditFavoriteDish(user);
                        break;
                    case 4:
                        // ShowFavoriteDish(user);
                        break;
                    case 5:
                        EnterSystem(user);
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
            User user = RegisterUser();
            EnterSystem(user);

        }
    }
}