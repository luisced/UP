#include <iostream>
#include <vector>
#include <algorithm>
#include <ctime>
#include <random>

using namespace std;

class Laberynth
{
private:
    // Fixed dimensions of the labyrinth.
    const int width, height;

    // Variables for movement directions.
    const vector<int> DIR_X = {0, 0, -1, 1};
    const vector<int> DIR_Y = {-1, 1, 0, 0};

    // Generates a map of the labyrinth.
    vector<vector<int>> generate_map()
    {
        vector<vector<int>> maze(width, vector<int>(height, 0));
        maze[0][0] = 1;

        // Lists to keep track of cells to explore.
        vector<pair<int, int>> cellsToExplore;
        cellsToExplore.push_back({0, 0});

        // Random engine
        std::default_random_engine rng(std::random_device{}());

        while (!cellsToExplore.empty())
        {
            // Randomly select a cell from the stack
            int currentX = cellsToExplore.back().first;
            int currentY = cellsToExplore.back().second;
            cellsToExplore.pop_back();

            // Define possible movement directions.
            vector<int> possibleDirections = {0, 1, 2, 3};
            shuffle(possibleDirections.begin(), possibleDirections.end(), rng);

            // Explore each possible direction.
            for (int i : possibleDirections)
            {
                int newX = currentX + 2 * DIR_X[i];
                int newY = currentY + 2 * DIR_Y[i];

                if (newX >= 0 && newX < width && newY >= 0 && newY < height && maze[newX][newY] == 0)
                {
                    cellsToExplore.push_back({newX, newY});
                    maze[newX][newY] = 1;
                    maze[currentX + DIR_X[i]][currentY + DIR_Y[i]] = 1;
                }
            }
        }

        return maze;
    }

    vector<vector<int>> map;

public:
    Laberynth(int w, int h) : width(w), height(h), map(generate_map()) {}

    // Getter method for the maze matrix.
    vector<vector<int>> get_map() const
    {
        return map;
    }

    void print_map()
    {
        // Top border
        cout << "┌";
        for (int j = 0; j < height; ++j)
        {
            cout << "─";
        }
        cout << "┐" << endl;

        for (int i = 0; i < width; ++i)
        {
            // Left border
            cout << "│";

            for (int j = 0; j < height; ++j)
            {
                if (i == 0 && j == 0)
                {
                    cout << "S";
                }
                else if (i == width - 1 && j == height - 1)
                {
                    cout << "E";
                }
                else if (map[i][j] == 1)
                {
                    cout << " ";
                }
                else
                {
                    cout << "#";
                }
            }

            // Right border
            cout << "│";

            cout << "\n";
        }

        // Bottom border
        cout << "└";
        for (int j = 0; j < height; ++j)
        {
            cout << "─";
        }
        cout << "┘" << endl;
    }
};
