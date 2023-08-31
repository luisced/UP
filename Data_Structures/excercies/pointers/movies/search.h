#include <vector>
#include "movies.h"

class Search
{
public:
    // Search by Name
    static vector<Movie *> searchByName(const string &name)
    {
        vector<Movie *> results;
        for (Movie *movie : movieVector)
        {
            if (movie->name == name)
            {
                results.push_back(movie);
            }
        }
        return results;
    }

    // Search by Director
    static vector<Movie *> searchByDirector(const string &director)
    {
        vector<Movie *> results;
        for (Movie *movie : movieVector)
        {
            if (movie->director == director)
            {
                results.push_back(movie);
            }
        }
        return results;
    }

    // Search by Year
    static vector<Movie *> searchByYear(int year)
    {
        vector<Movie *> results;
        for (Movie *movie : movieVector)
        {
            if (movie->year == year)
            {
                results.push_back(movie);
            }
        }
        return results;
    }

    // Search by Genre
    static vector<Movie *> searchByGenre(const string &genre)
    {
        vector<Movie *> results;
        for (Movie *movie : movieVector)
        {
            if (movie->genre == genre)
            {
                results.push_back(movie);
            }
        }
        return results;
    }
};
