#include "search.h"

static vector<Movie *> movieVector;

void addMovieToVector(const Movie &m)
{
    Movie *newMovie = new Movie(m);  // Create a new Movie object on the heap
    movieVector.push_back(newMovie); // Add pointer to the new Movie object to the vector
}

void print_vector()
{
    for (int i = 0; i < movieVector.size(); i++)
    {
        movieVector[i]->print();
    }
};

void create_movie()
{
    string name, director, genre;
    int year;
    cout << "Enter the name: ";
    cin >> name;
    cout << "Enter the director: ";
    cin >> director;
    cout << "Enter the year: ";
    cin >> year;
    cout << "Enter the genre: ";
    cin >> genre;

    // Add two vector
    Movie newMovie(name, director, year, genre);
    addMovieToVector(newMovie);
};

void search_menu()
{
    cout << "1. Search by Name" << endl;
    cout << "2. Search by Director" << endl;
    cout << "3. Search by Year" << endl;
    cout << "4. Search by Genre" << endl;
    cout << "5. Exit" << endl;

    cout << "Enter your choice: ";
    int option = 0;
    cin >> option;
    while (option != 5)
    {
        switch (option)
        {
        case 1:
            print_vector();
            break;
        default:
            break;
        }
    }
}

void menu()
{
    cout << "1. Add movie" << endl;
    cout << "2. Search movie" << endl;
    cout << "3. Remove movie" << endl;
    cout << "4. Exit" << endl;

    cout << "Enter your choice: ";
    int option = 0;
    cin >> option;
    switch (option)
    {
    case 1:
        create_movie();
        break;
    case 2:
        search_menu();
        break;
    default:
        break;
    }
};