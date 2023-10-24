#include <iostream>
#include <cstdlib> // for std::rand and std::srand
#include <ctime>   // for std::time
#include "../DoubleLinkedLIst/list.cpp"

enum class CellType
{
    Open,
    Wall,
    Entrance,
    Exit,
    Visited
};

struct Cell
{
    CellType type;
    int x; // x-coordinate
    int y; // y-coordinate

    Cell(int x, int y, CellType type = CellType::Open) : x(x), y(y), type(type) {}
};

class Maze
{
private:
    int width, height;
    List<List<Cell>> grid; // A list of lists, representing the 2D grid of cells
    Cell *entrance;
    Cell *exit;

    void setEntrance(int x, int y);
    void setExit(int x, int y);
    void setWall(int x, int y);
    void setEntrance(int x, int y);
    void setExit(int x, int y);
    void setWall(int x, int y);
    void walkableNeighbors(Cell *cell, List<Cell *> &neighbors);
    bool isWalkable(Cell *cell);

public:
    Maze(int width, int height)
        : width(width), height(height), entrance(nullptr), exit(nullptr)
    {
        if (width <= 0 || height <= 0)
        {
            throw std::invalid_argument("Maze dimensions must be positive.");
        }

        // Initialize random seed
        std::srand(std::time(nullptr));

        // Initialize the grid with random cells
        for (int i = 0; i < height; ++i)
        {
            List<Cell> row;
            for (int j = 0; j < width; ++j)
            {
                CellType type = CellType::Open; // Default to open

                // Randomly decide if this should be a wall, but we'll keep a border of open cells
                // Also ensure the entrance and exit are not walls
                if (i > 0 && i < height - 1 && j > 0 && j < width - 1)
                {
                    if (std::rand() % 3 == 0)
                    { // Approximately a 1 in 3 chance to be a wall
                        type = CellType::Wall;
                    }
                }

                row.insert(Cell(j, i, type));
            }
            grid.insert(row);
        }

        // Set entrance and exit
        setEntrance(0, 0);              // Top-left corner
        setExit(width - 1, height - 1); // Bottom-right corner
    }
    void printMaze();
};