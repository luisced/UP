using System;

public struct Book
{
    public string Title;
    public string Author;
    public string ISBN13;
}

class Program
{
    static Book[] books = new Book[5];


    static string GenerateISBN13()
    {
        Random random = new Random();
        string isbn = "";
        for (int i = 0; i < 13; i++)
        {
            isbn += random.Next(0, 10).ToString();
        }
        return isbn;
    }

    static void Main(string[] args)
    {
        Console.Clear();
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(" \nEnter details for book " + (i + 1));
            Console.Write("Title: ");
            books[i].Title = Console.ReadLine();
            Console.Write("Author: ");
            books[i].Author = Console.ReadLine();
            Console.WriteLine("Generating ISBN-13...");
            books[i].ISBN13 = GenerateISBN13();
            Console.WriteLine("Generated ISBN-13: " + books[i].ISBN13);
        }

        Console.Clear();
        Console.WriteLine("Sorted books by title:");
        BubbleSort();
        PrintBooks();


        Console.Write("Enter ISBN-13 to search: ");
        string isbn = Console.ReadLine();
        int index = SequentialSearch(isbn);
        if (index != -1)
        {
            Console.WriteLine("Book found!");
            Console.WriteLine("Title: " + books[index].Title);
            Console.WriteLine("Author: " + books[index].Author);
            Console.WriteLine("ISBN-13: " + books[index].ISBN13);
        }
        else
        {
            Console.WriteLine("Book not found!");
        }
    }

    static void BubbleSort()
    {
        for (int i = 0; i < books.Length; i++)
        {
            for (int j = 0; j < books.Length - i - 1; j++)
            {
                if (CompareStrings(books[j].Title, books[j + 1].Title) > 0)
                {
                    // Swap
                    Book temp = books[j];
                    books[j] = books[j + 1];
                    books[j + 1] = temp;
                }
            }
        }
    }

    static int CompareStrings(string str1, string str2)
    {
        int i = 0;
        while (i < str1.Length && i < str2.Length)
        {
            if (str1[i] < str2[i])
                return -1;
            if (str1[i] > str2[i])
                return 1;
            i++;
        }
        if (str1.Length < str2.Length)
            return -1;
        if (str1.Length > str2.Length)
            return 1;
        return 0;
    }
    static int SequentialSearch(string isbn)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i].ISBN13 == isbn)
            {
                return i;
            }
        }
        return -1;
    }

    static void PrintBooks()
    {
        for (int i = 0; i < books.Length; i++)
        {
            Console.WriteLine("Book " + (i + 1) + ":");
            Console.WriteLine("Title: " + books[i].Title);
            Console.WriteLine("Author: " + books[i].Author);
            Console.WriteLine("ISBN-13: " + books[i].ISBN13);
            Console.WriteLine();
        }
    }
}
