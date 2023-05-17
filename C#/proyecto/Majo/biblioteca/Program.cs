namespace library
{
    class Program
    {

        static List<Book> bookDB = new List<Book>();
        static List<Library> libraryDB = new List<Library>();
        public struct Book
        {
            public string name;
            public string isbn_10;

            public bool status;

            public float price;

            public Book(string name, string isbn_10, bool status, float price)
            {
                this.name = name;
                this.isbn_10 = isbn_10;
                this.status = status;
                this.price = price;
            }

        }

        public struct Library
        {
            // list of books
            public List<Book> books;
            public string rfc;
            public string adress;
            public string bill;

            public float price;

            public Library(string rfc, string adress, string bill)
            {
                this.rfc = rfc;
                this.adress = adress;
                this.bill = generateBill();
            }

            public string generateBill()
            {
                string bill = "";
                Random rnd = new Random();
                for (int i = 0; i < 10; i++)
                {
                    bill += rnd.Next(0, 9);
                }
                return bill;
            }

        }



        static string generateISB()
        {
            string isbn = "";
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                isbn += rnd.Next(0, 9);
            }
            return isbn;
        }

        static void captureInventory()
        {
            Console.WriteLine("Capture the inventory");
            Console.WriteLine("How many books do you want to add?");
            int books = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < books; i++)
            {
                Console.Write("Book name: ");
                string name = Console.ReadLine();
                Console.Write("Enter the price: ");
                float price = Convert.ToSingle(Console.ReadLine());
                Book book = new Book(name, generateISB(), true, price);
                bookDB.Add(book);

            }
        }

        static void printInventory()
        {
            Console.WriteLine("Inventory");
            foreach (Book book in bookDB)
            {
                Console.WriteLine("Book name: " + book.name);
                Console.WriteLine("Book isbn: " + book.isbn_10);
                Console.WriteLine("Book status: " + book.status);
                Console.WriteLine("Book price: " + book.price);
            }
        }

        static void modifyInventoryByISB()
        {
            Console.WriteLine("Enter the ISBN of the book you want to modify: ");
            string isbn = Console.ReadLine();

            for (int i = 0; i < bookDB.Count; i++)
            {
                if (bookDB[i].isbn_10 == isbn)
                {
                    Console.Write("Enter the new name: ");
                    string newName = Console.ReadLine();

                    Console.Write("Enter the new status (true for available, false for not available): ");
                    bool newStatus = Convert.ToBoolean(Console.ReadLine());

                    Console.Write("Enter the new price: ");
                    float newPrice = Convert.ToSingle(Console.ReadLine());

                    Book newBook = new Book(newName, isbn, newStatus, newPrice);
                    bookDB[i] = newBook;

                    Console.WriteLine("Book updated successfully.");
                    return;
                }
            }
            Console.WriteLine("Book not found.");
        }

        static void printAvailableBooks()
        {
            Console.WriteLine("Available books");
            foreach (Book book in bookDB)
            {
                if (book.status)
                {
                    Console.WriteLine("Book name: " + book.name);
                    Console.WriteLine("Book isbn: " + book.isbn_10);
                    Console.WriteLine("Book status: " + book.status);
                    Console.WriteLine("Book price: " + book.price);
                }
            }
        }

        static void removeBook()
        {
            Console.WriteLine("Enter the ISBN of the book you want to remove: ");
            string isbn = Console.ReadLine();

            for (int i = 0; i < bookDB.Count; i++)
            {
                if (bookDB[i].isbn_10 == isbn)
                {
                    bookDB.RemoveAt(i);
                    Console.WriteLine("Book removed successfully.");
                    return;
                }
            }
            Console.WriteLine("Book not found.");
        }


        static void purchaseBook()
        {
            Console.Write("How many books would you like to purchase?: ");
            int books = Convert.ToInt32(Console.ReadLine());
            float total = 0;
            for (int i = 0; i < books; i++)
            {
                Console.Write("Enter the ISBN or Name of the book you want to purchase: ");
                string isbn = Console.ReadLine();
                for (int j = 0; j < bookDB.Count; j++)
                {
                    if (bookDB[j].isbn_10 == isbn || bookDB[j].name == isbn)
                    {
                        total += bookDB[j].price;
                        bookDB.RemoveAt(j);
                        Console.WriteLine("Book purchased successfully.");
                        break;
                    }
                }
            }

            // Print a ticket containing all the books and the price:
            Console.WriteLine("Ticket");
            Console.WriteLine("Books purchased: " + books);
            Console.WriteLine("Total: " + total);



        }



        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the library");
            Console.WriteLine("1. Capture inventory");
            Console.WriteLine("2. Adjust inventory");
            Console.WriteLine("3. Book list report");
            Console.WriteLine("4. Available books");
            Console.WriteLine("5. Purchase a book");
            Console.WriteLine("6. Captura library details");
            Console.WriteLine("7. Exit");

            Console.Write("Option: ");
            int option = Convert.ToInt32(Console.ReadLine());
            while (option < 7)
            {
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        captureInventory();
                        break;
                    case 2:
                        Console.Clear();

                        Console.WriteLine("1. Modify inventory by ISBN");
                        Console.WriteLine("2. Remove book");
                        int option2 = Convert.ToInt32(Console.ReadLine());
                        if (option2 == 1)
                        {
                            modifyInventoryByISB();
                        }
                        else if (option2 == 2)
                        {
                            removeBook();
                        }
                        else
                        {
                            Console.WriteLine("Invalid option");
                        }
                        break;
                    case 3:
                        Console.Clear();

                        printInventory();
                        break;
                    case 4:
                        Console.Clear();

                        printAvailableBooks();
                        break;
                    case 5:
                        Console.Clear();

                        purchaseBook();
                        break;
                    case 6:
                        Console.Clear();

                        Console.WriteLine("Enter the RFC of the library: ");
                        break;
                    default:
                        Console.Clear();

                        Console.WriteLine("Invalid option");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Welcome to the library");
                Console.WriteLine("1. Capture inventory");
                Console.WriteLine("2. Adjust inventory");
                Console.WriteLine("3. Book list report");
                Console.WriteLine("4. Available books");
                Console.WriteLine("5. Purchase a book");
                Console.WriteLine("6. Captura library details");
                Console.WriteLine("7. Exit");

                Console.Write("Option: ");
                option = Convert.ToInt32(Console.ReadLine());

            }

        }

        static void Main(string[] args)
        {
            Menu();

        }
    }
}