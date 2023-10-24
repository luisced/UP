#include "tree.h" // Include your BinaryTree class
#include "list.h"
class Maze
{
public:
    // Constructor to initialize the maze with a given size
    Maze(int rows, int cols);

    // Destructor to clean up memory
    ~Maze();

    // Generate a maze using the binary tree algorithm
    void generateMaze();

    // Solve the maze using a specified algorithm (e.g., DFS)
    bool solveMaze();

    // Display the maze (optional, using a graphics library like OpenCV)
    void printMaze() const;

    void printSolution(const List<std::pair<int, int>> &solutionPath) const;

    List<std::pair<int, int>> getSolutionPath() const;

private:
    int rows_;
    int cols_;

    Node<int> ***maze_;
    BinaryTree<int> *mazeTree_;

    void initializeMaze();
    void buildMazeTree(int row, int col);
    bool solveRecursive(int row, int col, int endRow, int endCol);
};

Maze::Maze(int rows, int cols) : rows_(rows), cols_(cols), maze_(nullptr), mazeTree_(nullptr)
{
    initializeMaze();
}

Maze::~Maze()
{
    // Clean up memory for the maze
    if (maze_)
    {
        for (int i = 0; i < rows_; ++i)
        {
            for (int j = 0; j < cols_; ++j)
            {
                delete maze_[i][j];
            }
            delete[] maze_[i];
        }
        delete[] maze_;
    }

    // Clean up the maze tree
    delete mazeTree_;
}

void Maze::initializeMaze()
{
    // Allocate memory for the maze
    maze_ = new Node<int> **[rows_];
    for (int i = 0; i < rows_; ++i)
    {
        maze_[i] = new Node<int> *[cols_];
        for (int j = 0; j < cols_; ++j)
        {
            maze_[i][j] = new Node<int>(15); // Initialize each cell with all walls (bitwise OR with 15)
        }
    }

    // Initialize the maze tree
    mazeTree_ = new BinaryTree<int>();
}

// maze.cpp

void Maze::generateMaze()
{
    // Initialize the maze tree with the first cell
    mazeTree_->insert(0);

    // Iterate through each cell in the maze
    for (int row = 0; row < rows_; ++row)
    {
        for (int col = 0; col < cols_; ++col)
        {
            // Randomly choose to carve either to the right or down
            if (row < rows_ - 1 && col < cols_ - 1)
            {
                if (rand() % 2 == 0)
                {
                    // Carve to the right
                    maze_[row][col]->value |= 1;              // Set the right wall as open (bitwise OR with 1)
                    mazeTree_->insert(row * cols_ + col + 1); // Connect the current cell to the right one in the maze tree
                }
                else
                {
                    // Carve down
                    maze_[row][col]->value |= 2;                // Set the bottom wall as open (bitwise OR with 2)
                    mazeTree_->insert((row + 1) * cols_ + col); // Connect the current cell to the one below it in the maze tree
                }
            }
            else if (row < rows_ - 1)
            {
                // Carve down for the last column
                maze_[row][col]->value |= 2;                // Set the bottom wall as open (bitwise OR with 2)
                mazeTree_->insert((row + 1) * cols_ + col); // Connect the current cell to the one below it in the maze tree
            }
            else if (col < cols_ - 1)
            {
                // Carve to the right for the last row
                maze_[row][col]->value |= 1;              // Set the right wall as open (bitwise OR with 1)
                mazeTree_->insert(row * cols_ + col + 1); // Connect the current cell to the right one in the maze tree
            }
        }
    }
}

bool Maze::solveMaze()
{
    // Find the starting point (top-left corner)
    int startRow = 0;
    int startCol = 0;

    // Find the ending point (bottom-right corner)
    int endRow = rows_ - 1;
    int endCol = cols_ - 1;

    // Call the recursive solve function starting from the entry point
    return solveRecursive(startRow, startCol, endRow, endCol);
}

bool Maze::solveRecursive(int row, int col, int endRow, int endCol)
{
    // Base case: If we have reached the end of the maze, we have solved it
    if (row == endRow && col == endCol)
    {
        return true;
    }

    // Check if the cell is within bounds and not a wall
    if (row >= 0 && row < rows_ && col >= 0 && col < cols_ && (maze_[row][col]->value & 1) == 0 && (maze_[row][col]->value & 2) == 0)
    {
        // Mark the cell as visited by setting a flag (e.g., using a bitwise OR)
        maze_[row][col]->value |= 4;

        // Try to move in all four directions (up, right, down, left)
        if (solveRecursive(row - 1, col, endRow, endCol) || // Up
            solveRecursive(row, col + 1, endRow, endCol) || // Right
            solveRecursive(row + 1, col, endRow, endCol) || // Down
            solveRecursive(row, col - 1, endRow, endCol))
        { // Left
            // If any of the recursive calls returns true, we found a path
            return true;
        }

        // If none of the directions led to a solution, mark the cell as unvisited
        maze_[row][col]->value &= ~4; // Clear the flag (bitwise AND with the complement of 4)
    }

    return false; // No path found from this cell
}

void Maze::printMaze() const
{
    for (int row = 0; row < rows_; ++row)
    {
        // Print the top walls of each cell in this row
        for (int col = 0; col < cols_; ++col)
        {
            if (maze_[row][col]->value & 1)
            {
                // Right wall is closed
                std::cout << "+---";
            }
            else
            {
                // Right wall is open
                std::cout << "+   ";
            }
        }
        std::cout << "+" << std::endl;

        // Print the middle row of each cell in this row
        for (int col = 0; col < cols_; ++col)
        {
            if (maze_[row][col]->value & 2)
            {
                // Bottom wall is closed
                std::cout << "|   ";
            }
            else
            {
                // Bottom wall is open
                std::cout << "    ";
            }
        }
        std::cout << "|" << std::endl;
    }

    // Print the bottom walls of the last row
    for (int col = 0; col < cols_; ++col)
    {
        std::cout << "+---";
    }
    std::cout << "+" << std::endl;
}

// maze.cpp

#include "list.h" // Include your List class
#include <iostream>

// ...

void Maze::printSolution(const List<std::pair<int, int>> &solutionPath) const
{
    if (solutionPath.isEmpty())
    {
        std::cout << "No solution found." << std::endl;
        return;
    }

    // Create a 2D array of boolean flags to mark the cells in the solution path
    bool **solutionGrid = new bool *[rows_];
    for (int i = 0; i < rows_; ++i)
    {
        solutionGrid[i] = new bool[cols_];
        for (int j = 0; j < cols_; ++j)
        {
            solutionGrid[i][j] = false;
        }
    }

    // Mark the cells in the solution path using List methods
    for (int i = 0; i < solutionPath.size_of_list(); ++i)
    {
        int row = solutionPath.getAt(i).first;
        int col = solutionPath.getAt(i).second;
        solutionGrid[row][col] = true;
    }

    // Print the maze with the solution path
    for (int row = 0; row < rows_; ++row)
    {
        // Print the top walls of each cell in this row
        for (int col = 0; col < cols_; ++col)
        {
            if (maze_[row][col]->value & 1)
            {
                // Right wall is closed
                std::cout << "+---";
            }
            else
            {
                // Right wall is open
                std::cout << "+   ";
            }
        }
        std::cout << "+" << std::endl;

        // Print the middle row of each cell in this row
        for (int col = 0; col < cols_; ++col)
        {
            if (solutionGrid[row][col])
            {
                std::cout << "| * "; // Mark cells in the solution path with '*'
            }
            else
            {
                if (maze_[row][col]->value & 2)
                {
                    // Bottom wall is closed
                    std::cout << "|   ";
                }
                else
                {
                    // Bottom wall is open
                    std::cout << "    ";
                }
            }
        }
        std::cout << "|" << std::endl;
    }

    // Print the bottom walls of the last row
    for (int col = 0; col < cols_; ++col)
    {
        std::cout << "+---";
    }
    std::cout << "+" << std::endl;

    // Clean up the dynamically allocated solutionGrid
    for (int i = 0; i < rows_; ++i)
    {
        delete[] solutionGrid[i];
    }
    delete[] solutionGrid;
}