#ifndef PROYECTOFINAL_H
#define PROYECTOFINAL_H

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

void dividirLineaCSV(const std::string &linea, Libro &libro);
void crearArchivoBiblioteca(const std::string &archivoCSV, const std::string &archivoBiblioteca);
void imprimirLibro(const std::string &archivoBiblioteca);

#endif // PROYECTOFINAL_H
