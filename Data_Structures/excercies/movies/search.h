#include "movies.h"

class Search
{
public:
    // make a map by each property of movie class
    // ex quarantino : {movie 1, movie 2}
    map<string, vector<Movie *>> byName;
    map<string, vector<Movie *>> byDirector;
    map<int, vector<Movie *>> byYear;
    map<string, vector<Movie *>> byGenre;

    // add movie to static vector

    void remove(vector<Movie *> searchByName(string name));
};
