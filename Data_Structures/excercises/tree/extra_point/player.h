#pragma once

#include <vector>
#include <queue>
#include <algorithm>
#include <iostream>
#include <thread>
#include <chrono>
#include <map>
#include "tree.h" // Include the BinaryTree class header file

class Robot
{
public:
    Robot();
    ~Robot();

    std::vector<std::pair<int, int>> solve(int **maze, int width, int height, bool shouldDisplayMaze = false);

private:
    static const std::vector<std::pair<int, int>> DIRECTIONS;

    static void clearScreen();

    void displayMaze(int **maze, int width, int height, int x, int y) const;
};

const std::vector<std::pair<int, int>> Robot::DIRECTIONS = {{-1, 0}, {1, 0}, {0, -1}, {0, 1}};

Robot::Robot()
{
}

Robot::~Robot()
{
}

void Robot::clearScreen()
{
#ifdef _WIN32
    system("cls");
#else
    system("clear");
#endif
}

void Robot::displayMaze(int **maze, int width, int height, int x, int y) const
{
    clearScreen();
    for (int i = 0; i < width; ++i)
    {
        for (int j = 0; j < height; ++j)
        {
            if (i == x && j == y)
            {
                std::cout << "\033[1;31m"
                          << "◍"
                          << "\033[0m"; // Red robot
            }
            else
            {
                std::cout << (maze[i][j] == 0 ? "■" : " "); // Wall or space
            }
        }
        std::cout << '\n';
    }
    std::this_thread::sleep_for(std::chrono::milliseconds(25));
}

std::vector<std::pair<int, int>> Robot::solve(int **maze, int width, int height, bool shouldDisplayMaze)
{
    std::vector<std::vector<bool>> visited(width, std::vector<bool>(height, false));
    BinaryTree<std::pair<int, int>> pathTree; // Use BinaryTree to store the path

    std::queue<std::pair<int, int>> q;

    std::pair<int, int> start = {0, 0};
    std::pair<int, int> end = {width - 1, height - 1};

    q.push(start);
    visited[start.first][start.second] = true;

    std::map<std::pair<int, int>, std::pair<int, int>> parent; // Map to store parent-child relationships

    while (!q.empty())
    {
        std::pair<int, int> current = q.front();
        int x = current.first;
        int y = current.second;
        q.pop();

        if (current == end)
            break;

        for (size_t i = 0; i < DIRECTIONS.size(); i++)
        {
            int newX = x + DIRECTIONS[i].first;
            int newY = y + DIRECTIONS[i].second;
            if (newX >= 0 && newX < width && newY >= 0 && newY < height &&
                !visited[newX][newY] && maze[newX][newY] == 1)
            {
                q.push({newX, newY});
                visited[newX][newY] = true;
                parent[{newX, newY}] = current; // Store parent-child relationship
            }
        }

        if (shouldDisplayMaze)
            displayMaze(maze, width, height, x, y);
    }

    // Reconstruct the path from end to start using the parent-child relationships
    std::vector<std::pair<int, int>> path;
    std::pair<int, int> current = end;
    while (current != start)
    {
        path.push_back(current);
        current = parent[current];
    }
    path.push_back(start);
    std::reverse(path.begin(), path.end());

    // Now 'path' contains the path from start to end

    return path;
}
