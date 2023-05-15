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

            public Book(string name, string isbn_10, bool status)
            {
                this.name = name;
                this.isbn_10 = isbn_10;
                this.status = status;
            }

        }

        public struct Library
        {
            // list of books
            public List<Book> books;
            public string rfc;
            public string adress;
            public string bill;

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
                Console.WriteLine("Book name: ");
                string name = Console.ReadLine();
                Book book = new Book(name, generateISB(), true);
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
            }
        }

        static void Main(string[] args)
        {
            captureInventory();
            printInventory();
        }
    }
}