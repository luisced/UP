#include <vector>
#include <string>
#include <algorithm>

using namespace std;

class Laberynth
{
private:
    // Fixed dimensions of the labyrinth.
    const int width, height;

    // Variables for movement directions
    const int UP_X = 0, UP_Y = -1;
    const int DOWN_X = 0, DOWN_Y = 1;
    const int LEFT_X = -1, LEFT_Y = 0;
    const int RIGHT_X = 1, RIGHT_Y = 0;

    // Generates a map of the labyrinth.
    vector<vector<int>> generate_map()
    {
        // Create an empty maze filled with walls.
        vector<vector<int>> maze(width, vector<int>(height, 0));

        // Set the starting point in the maze.
        maze[0][0] = 1;

        // Lists to keep track of cells to explore.
        vector<int> cellsToExploreX;
        vector<int> cellsToExploreY;

        // Start exploration from the top-left corner.
        cellsToExploreX.push_back(0);
        cellsToExploreY.push_back(0);

        while (!cellsToExploreX.empty())
        {
            // Get the current cell's coordinates.
            int currentX = cellsToExploreX.back();
            int currentY = cellsToExploreY.back();
            cellsToExploreX.pop_back();
            cellsToExploreY.pop_back();

            // Define possible movement directions.
            vector<int> possibleDirections = {0, 1, 2, 3};
            random_shuffle(possibleDirections.begin(), possibleDirections.end());

            // Explore each possible direction.
            for (int direction : possibleDirections)
            {
                int newX = currentX;
                int newY = currentY;

                // Calculate new coordinates based on the chosen direction.
                switch (direction)
                {
                case 0:
                    newX += UP_X;
                    newY += UP_Y;
                    break;
                case 1:
                    newX += DOWN_X;
                    newY += DOWN_Y;
                    break;
                case 2:
                    newX += LEFT_X;
                    newY += LEFT_Y;
                    break;
                case 3:
                    newX += RIGHT_X;
                    newY += RIGHT_Y;
                    break;
                }

                // Check if the new position is valid.
                if (newX >= 0 && newX < width && newY >= 0 && newY < height && maze[newX][newY] == 0)
                {
                    // Create a path in the chosen direction.
                    switch (direction)
                    {
                    case 0:
                        maze[currentX][currentY + UP_Y / 2] = 1;
                        break;
                    case 1:
                        maze[currentX][currentY + DOWN_Y / 2] = 1;
                        break;
                    case 2:
                        maze[currentX + LEFT_X / 2][currentY] = 1;
                        break;
                    case 3:
                        maze[currentX + RIGHT_X / 2][currentY] = 1;
                        break;
                    }

                    // Mark the new cell as part of the path.
                    maze[newX][newY] = 1;

                    // Add the new cell to the exploration list.
                    cellsToExploreX.push_back(newX);
                    cellsToExploreY.push_back(newY);
                }
            }
        }

        return maze;
    }

    vector<vector<int>> map = generate_map();

public:
    Laberynth(int width, int height);
    void print_map();
};
