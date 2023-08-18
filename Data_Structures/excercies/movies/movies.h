#include <iostream>
#include <string>
#include <vector>
#include <map>

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
        cout << "Name: " << name << endl;
        cout << "Director: " << director << endl;
        cout << "Year: " << year << endl;
        cout << "Genre: " << genre << endl;
    };
};