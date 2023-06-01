
public struct Libro
{
    public string Titulo;
    public string Autor;
    public string ISBN13;
}

class Program
{
    static Libro[] libros = new Libro[5];


    static void Main(string[] args)
    {

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("libro: " + (i + 1));
            Console.Write("titulo: ");
            libros[i].Titulo = Console.ReadLine();
            Console.Write("autor: ");
            libros[i].Autor = Console.ReadLine();
            libros[i].ISBN13 = GenerarISBN13();
            Console.WriteLine("ISBN  " + libros[i].ISBN13);
        }


        Console.WriteLine("Libros ordenados por título:");
        OrdenarPorTitulo();
        for (int i = 0; i < libros.Length; i++)
        {
            Console.WriteLine($"Libro {i + 1}: \nTítulo: {libros[i].Titulo} \nAutor: {libros[i].Autor} \nISBN-13: {libros[i].ISBN13}\n");
        }

        Console.Write("ingrese isb: ");
        string isbn = Console.ReadLine();
        int indice = BusquedaSecuencial(isbn);
        if (indice != -1)
        {
            Console.WriteLine("ttulo: " + libros[indice].Titulo);
            Console.WriteLine("autor: " + libros[indice].Autor);
            Console.WriteLine("isb: " + libros[indice].ISBN13);
        }
        else
        {
            Console.WriteLine(":(");
        }
    }

    // Ordena los libros por título utilizando el algoritmo Bubble Sort
    static void OrdenarPorTitulo()
    {
        for (int i = 0; i < libros.Length; i++)
        {
            for (int j = 0; j < libros.Length - i - 1; j++)
            {
                if (CompararTextos(libros[j].Titulo, libros[j + 1].Titulo) > 0)
                {
                    // Intercambia los libros
                    Libro temp = libros[j];
                    libros[j] = libros[j + 1];
                    libros[j + 1] = temp;
                }
            }
        }
    }

    // Compara dos cadenas de caracteres y devuelve un valor entero que indica su orden lexicográfico
    static int CompararTextos(string cadena1, string cadena2)
    {
        int i = 0;
        while (i < cadena1.Length && i < cadena2.Length)
        {
            if (cadena1[i] < cadena2[i])
                return -1;
            if (cadena1[i] > cadena2[i])
                return 1;
            i++;
        }
        if (cadena1.Length < cadena2.Length)
            return -1;
        if (cadena1.Length > cadena2.Length)
            return 1;
        return 0;
    }

    // Realiza una búsqueda secuencial del libro con el ISBN-13 dado
    static int BusquedaSecuencial(string isbn)
    {
        for (int i = 0; i < libros.Length; i++)
        {
            if (libros[i].ISBN13 == isbn)
            {
                return i;
            }
        }
        return -1;
    }
    // Genera un número ISBN-13 aleatorio
    static string GenerarISBN13()
    {
        Random random = new Random();
        string isbn = "";
        for (int i = 0; i < 13; i++)
        {
            isbn += random.Next(0, 10).ToString();
        }
        return isbn;
    }

    static void ImprimirLibro()
    {

    }


}
