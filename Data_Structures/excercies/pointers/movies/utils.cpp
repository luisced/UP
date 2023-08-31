#include "search.h"

void clearConsole()
{
#ifdef _WIN32
    system("cls");
#else
    system("clear");
#endif
}

void pressEnterToContinue()
{
    cout << "Press Enter to continue...";
    cin.ignore();
    cin.get();
}

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
    cin.ignore();
    string name, director, genre;
    int year;
    cout << "Enter the name: ";
    getline(cin, name);
    cout << "Enter the director: ";
    getline(cin, director);
    cout << "Enter the year: ";
    cin >> year;
    cout << "Enter the genre: ";
    getline(cin, genre);

    // Add two vector
    Movie newMovie(name, director, year, genre);
    addMovieToVector(newMovie);
};
void search_menu()
{
    while (true)
    {
        clearConsole();

        cout << "1. Search by Name" << endl;
        cout << "2. Search by Director" << endl;
        cout << "3. Search by Year" << endl;
        cout << "4. Search by Genre" << endl;
        cout << "5. All movies" << endl;
        cout << "6. Exit" << endl;

        cout << "Enter your choice: ";
        int option = 0;
        cin >> option;
        cin.ignore();

        switch (option)
        {
        case 1:
        {
            clearConsole();
            string name;
            cout << "Enter the name to search: ";
            getline(cin, name);
            vector<Movie *> results = Search::searchByName(name);
            for (Movie *movie : results)
            {
                movie->print();
            }
            pressEnterToContinue();
            break;
        }
        case 2:
        {
            clearConsole();
            string director;
            cout << "Enter the director to search: ";
            getline(cin, director);
            vector<Movie *> results = Search::searchByDirector(director);
            for (Movie *movie : results)
            {
                movie->print();
            }
            pressEnterToContinue();
            break;
        }
        case 3:
        {
            clearConsole();
            int year;
            cout << "Enter the year to search: ";
            cin >> year;
            cin.ignore(); // Clear the newline character from the input buffer
            vector<Movie *> results = Search::searchByYear(year);
            for (Movie *movie : results)
            {
                movie->print();
            }
            pressEnterToContinue();
            break;
        }
        case 4:
        {
            clearConsole();
            string genre;
            cout << "Enter the genre to search: ";
            getline(cin, genre);
            vector<Movie *> results = Search::searchByGenre(genre);
            for (Movie *movie : results)
            {
                movie->print();
            }
            pressEnterToContinue();
            break;
        }
        case 5:
            clearConsole();
            print_vector();
            pressEnterToContinue();
            return;
        case 6:
            clearConsole();
            return;
        default:
            cout << "Invalid option. Please choose again." << endl;
            break;
        }
    }
}

void menu()
{
    while (true)
    {
        clearConsole();
        cout << "1. Add movie" << endl;
        cout << "2. Search movie" << endl;
        cout << "3. Exit" << endl;

        cout << "Enter your choice: ";
        int option = 0;
        cin >> option;

        switch (option)
        {
        case 1:
            clearConsole();
            create_movie();
            break;
        case 2:
            clearConsole();
            search_menu();
            break;
        case 3:
            clearConsole();
            return;
        default:
            cout << "Invalid option. Please choose again." << endl;
            break;
        }
    }
}
