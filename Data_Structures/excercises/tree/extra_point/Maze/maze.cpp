#include "maze.h"
#include <vector>
#include <cstdlib> // for rand() and srand()
#include <ctime>   // for time()

void Maze::initializeMaze()
{
    // Initialize random seed
    srand(time(NULL));

    // Create rows with 'height' and columns with 'width', initially with all walls (0s)
    for (int i = 0; i < height; ++i)
    {
        List<int> row;
        for (int j = 0; j < width; ++j)
        {
            row.insert(0); // 0 represents a wall
        }
        maze.insert(row);
    }
}

void Maze::setEntranceAndExit()
{
    // The entrance and exit will be on the boundaries of the maze.
    // We'll randomly choose which side of the boundary (top, bottom, left, right) the entrance/exit will be on,
    // and then randomly choose a point along that side.

    // Randomly choose the entrance side (0 = top, 1 = right, 2 = bottom, 3 = left)
    int entranceSide = rand() % 4;
    // Randomly choose the exit side, and make sure it's not the same as the entrance
    int exitSide;
    do
    {
        exitSide = rand() % 4;
    } while (exitSide == entranceSide);

    // Set the entrance
    switch (entranceSide)
    {
    case 0: // top
        entrance = {0, rand() % width};
        maze.getAt(0).set_at(1, entrance.second); // 1 represents a path
        break;
    case 1: // right
        entrance = {rand() % height, width - 1};
        maze.getAt(entrance.first).set_at(1, width - 1);
        break;
    case 2: // bottom
        entrance = {height - 1, rand() % width};
        maze.getAt(height - 1).set_at(1, entrance.second);
        break;
    case 3: // left
        entrance = {rand() % height, 0};
        maze.getAt(entrance.first).set_at(1, 0);
        break;
    }

    // Set the exit
    switch (exitSide)
    {
    case 0: // top
        exit = {0, rand() % width};
        maze.getAt(0).set_at(1, exit.second);
        break;
    case 1: // right
        exit = {rand() % height, width - 1};
        maze.getAt(exit.first).set_at(1, width - 1);
        break;
    case 2: // bottom
        exit = {height - 1, rand() % width};
        maze.getAt(height - 1).set_at(1, exit.second);
        break;
    case 3: // left
        exit = {rand() % height, 0};
        maze.getAt(exit.first).set_at(1, 0);
        break;
    }
}

void Maze::printMaze() const
{
    for (int i = 0; i < height; ++i)
    {
        for (int j = 0; j < width; ++j)
        {
            std::cout << maze.getAt(i).getAt(j) << ' ';
        }
        std::cout << '\n';
    }
}

void Maze::generateMaze()
{
    srand(time(NULL)); // Seed for the random number generator

    // Stack for the backtracking
    srand(time(NULL)); // Seed for the random number generator

    // Stack for the backtracking
    Stack<std::pair<int, int>> stack; // Using your custom Stack class

    // Start from the entrance
    std::pair<int, int> current = entrance;
    stack.push(current);

    // Mark the entrance as visited (2 indicates visited)
    maze.getAt(current.first).set_at(2, current.second);

    while (!stack.isEmpty())
    {                           // Using your custom isEmpty method
        current = stack.peek(); // Using your custom peek method
        stack.pop();

        // Get all neighbors of the current cell
        std::vector<std::pair<int, int>> neighbors;

        // Up neighbor
        if (current.first > 0 && maze.getAt(current.first - 1).getAt(current.second) == 0)
        {
            neighbors.push_back({current.first - 1, current.second});
        }

        // Down neighbor
        if (current.first < height - 1 && maze.getAt(current.first + 1).getAt(current.second) == 0)
        {
            neighbors.push_back({current.first + 1, current.second});
        }

        // Left neighbor
        if (current.second > 0 && maze.getAt(current.first).getAt(current.second - 1) == 0)
        {
            neighbors.push_back({current.first, current.second - 1});
        }

        // Right neighbor
        if (current.second < width - 1 && maze.getAt(current.first).getAt(current.second + 1) == 0)
        {
            neighbors.push_back({current.first, current.second + 1});
        }

        if (!neighbors.empty())
        {
            // If there are unvisited neighbors, push the current cell to the stack
            stack.push(current);

            // Choose one random neighbor
            int randIndex = rand() % neighbors.size();
            std::pair<int, int> chosenNeighbor = neighbors[randIndex];

            // Remove the wall between the current cell and the chosen cell
            // Here, we set the chosen cell's value to 2 to indicate it's visited.
            maze.getAt(chosenNeighbor.first).set_at(2, chosenNeighbor.second);

            // Push the chosen cell to the stack
            stack.push(chosenNeighbor);
        }
    }

    // Reset visited cells to make them paths (1 indicates path)
    for (int i = 0; i < height; ++i)
    {
        for (int j = 0; j < width; ++j)
        {
            if (maze.getAt(i).getAt(j) == 2)
            {
                maze.getAt(i).set_at(1, j);
            }
        }
    }
}