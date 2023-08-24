#include <iostream>
#include <vector>
#include <algorithm>
#include <ctime>
#include <random>
#include <queue>

using namespace std;

class Laberynth
{
private:
    const int width, height;
    const vector<int> DIR_X = {0, 0, -1, 1};
    const vector<int> DIR_Y = {-1, 1, 0, 0};

    int **generate_map()
    {
        int **maze = new int *[width];
        for (int i = 0; i < width; i++)
        {
            maze[i] = new int[height];
            fill(maze[i], maze[i] + height, 0);
        }
        maze[0][0] = 1;

        vector<pair<int, int>> cellsToExplore;
        cellsToExplore.push_back({0, 0});

        default_random_engine rng(random_device{}());

        while (!cellsToExplore.empty())
        {
            int currentX = cellsToExplore.back().first;
            int currentY = cellsToExplore.back().second;
            cellsToExplore.pop_back();

            vector<int> possibleDirections = {0, 1, 2, 3};
            shuffle(possibleDirections.begin(), possibleDirections.end(), rng);

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

    int **map;

public:
    Laberynth(int w, int h) : width(w), height(h)
    {
        map = generate_map();
    }

    ~Laberynth()
    {
        for (int i = 0; i < width; i++)
        {
            delete[] map[i];
        }
        delete[] map;
    }

    int **get_map() const
    {
        return map;
    }

    int get_width() const
    {
        return width;
    }

    int get_height() const
    {
        return height;
    }

    void print_map()
    {
        cout << "┌";
        for (int j = 0; j < height; ++j)
        {
            cout << "─";
        }
        cout << "┐" << endl;

        for (int i = 0; i < width; ++i)
        {
            cout << "│";
            for (int j = 0; j < height; ++j)
            {
                if (map[i][j] == 1)
                {
                    cout << " ";
                }
                else if (map[i][j] == 2)
                {
                    // change color to red
                    cout << "\033[1;31m";
                    cout << "R";
                    // change color to white
                    cout << "\033[0m";
                }
                else
                {
                    cout << "#";
                }
            }
            cout << "│\n";
        }

        cout << "└";
        for (int j = 0; j < height; ++j)
        {
            cout << "─";
        }
        cout << "┘" << endl;
    }
};
