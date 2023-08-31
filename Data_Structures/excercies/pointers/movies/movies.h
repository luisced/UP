#include <iostream>
#include <string>
#include <vector>

using namespace std;

class Movie
{
public:
    string name;
    string director;
    int year;
    string genre;

    Movie(string name, string director, int year, string genre)
    {
        this->name = name;
        this->director = director;
        this->year = year;
        this->genre = genre;
    };

    void print()
    {
        cout << "\nName: " << name << endl;
        cout << "Director: " << director << endl;
        cout << "Year: " << year << endl;
        cout << "Genre: " << genre << endl;
    };
};

static vector<Movie *> movieVector = {
    new Movie("Movie 1", "Director A", 2000, "Action"),
    new Movie("Movie 2", "Director B", 2005, "Comedy"),
    new Movie("Movie 3", "Director C", 2010, "Drama"),
    new Movie("Movie 4", "Director A", 2015, "Action"),
    new Movie("Movie 5", "Director D", 2020, "Horror")};
