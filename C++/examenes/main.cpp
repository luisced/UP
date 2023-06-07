#include <iostream>
#include <fstream>
#include <sstream>
#include <string>

const int MAX_BOOKS = 100;

class Libro
{
public:
    int bookID;
    std::string titulo;
    std::string autor;
    std::string genero;
    std::string isbn;
    std::string isbn13;
    std::string language_code;
    int num_pages;
    int ratings_count;
    int text_reviews_count;
    std::string publication_date;
    std::string publisher;

    Libro()
    {
        bookID = 0;
        num_pages = 0;
        ratings_count = 0;
        text_reviews_count = 0;
    }
};
void dividirLineaCSV(const std::string &linea, Libro &libro)
{
    std::stringstream ss(linea);
    std::string campo;

    // Lee cada campo de la línea separado por comas
    std::getline(ss, campo, ',');
    libro.bookID = std::stoi(campo);

    std::getline(ss, campo, ',');
    libro.titulo = campo;

    std::getline(ss, campo, ',');
    libro.autor = campo;

    // Omitir el campo average_rating

    std::getline(ss, campo, ',');
    libro.isbn = campo;

    std::getline(ss, campo, ',');
    libro.isbn13 = campo;

    std::getline(ss, campo, ',');
    libro.language_code = campo;

    std::getline(ss, campo, ',');
    libro.num_pages = std::stoi(campo);

    std::getline(ss, campo, ',');
    libro.ratings_count = std::stoi(campo);

    std::getline(ss, campo, ',');
    libro.text_reviews_count = std::stoi(campo);

    std::getline(ss, campo, ',');
    libro.publication_date = campo;

    std::getline(ss, campo, ',');
    libro.publisher = campo;

    // Agrega más líneas para leer los atributos adicionales del libro
}
void crearArchivoBiblioteca(const std::string &archivoCSV, const std::string &archivoBiblioteca)
{
    std::ifstream archivoEntrada(archivoCSV);
    std::ofstream archivoSalida(archivoBiblioteca, std::ios::binary);

    if (!archivoEntrada)
    {
        std::cout << "No se pudo abrir el archivo CSV." << std::endl;
        return;
    }

    if (!archivoSalida)
    {
        std::cout << "No se pudo crear el archivo de biblioteca." << std::endl;
        return;
    }

    Libro libros[MAX_BOOKS];

    std::string linea;
    int contador = 0;

    // Lee cada línea del archivo CSV y crea el arreglo de libros
    while (std::getline(archivoEntrada, linea) && contador < MAX_BOOKS)
    {
        dividirLineaCSV(linea, libros[contador]);
        contador++;
    }

    // Escribe el arreglo de libros en el archivo de biblioteca
    archivoSalida.write(reinterpret_cast<const char *>(libros), sizeof(Libro) * contador);

    archivoEntrada.close();
    archivoSalida.close();

    std::cout << "Se ha creado el archivo de biblioteca exitosamente." << std::endl;
}

void imprimirLibro(const std::string &archivoBiblioteca)
{
    std::ifstream archivo(archivoBiblioteca, std::ios::binary);

    if (!archivo)
    {
        std::cout << "No se pudo abrir el archivo de biblioteca." << std::endl;
        return;
    }

    int bookID;
    std::cout << "Ingrese el bookID del libro que desea imprimir: ";
    std::cin >> bookID;

    Libro libro;
    archivo.seekg(sizeof(Libro) * (bookID - 1));
    archivo.read(reinterpret_cast<char *>(&libro), sizeof(Libro));

    if (libro.bookID != 0)
    {
        std::cout << "Libro encontrado:" << std::endl;
        std::cout << "BookID: " << libro.bookID << std::endl;
        std::cout << "Título: " << libro.titulo << std::endl;
        std::cout << "Autor: " << libro.autor << std::endl;
        std::cout << "Género: " << libro.genero << std::endl;
        // Imprime los atributos adicionales del libro
    }
    else
    {
        std::cout << "Libro no encontrado." << std::endl;
    }

    archivo.close();
}

int main()
{
    std::string archivoCSV = "libros.csv";
    std::string archivoBiblioteca = "biblioteca.dat";

    // Crear el archivo de biblioteca a partir del archivo CSV
    crearArchivoBiblioteca(archivoCSV, archivoBiblioteca);

    // Solicitar al usuario el bookID del libro a imprimir
    int bookID;
    std::cout << "Ingrese el bookID del libro que desea imprimir: ";
    std::cin >> bookID;

    // Imprimir la información del libro en consola
    imprimirLibro(archivoBiblioteca);

    return 0;
}
