namespace library
{
    class Program
    {

        // public List<Book> bookDB = {

        // }
        public struct Book
        {
            public string name;
            public string isbn_10;

            public bool status;

            public Book(string name, bool status)
            {
                this.name = name;
                this.isbn_10 = generateISB();
            }

            public string generateISB()
            {
                string isbn = "";
                Random rnd = new Random();
                for (int i = 0; i < 10; i++)
                {
                    isbn += rnd.Next(0, 9);
                }
                return isbn;
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


        static void Main(string[] args)
        {
        }
    }
}