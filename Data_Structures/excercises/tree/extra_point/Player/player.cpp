#include "player.h"

using namespace std;

const vector<pair<int, int>> Robot::DIRECTIONS = {{-1, 0}, {1, 0}, {0, -1}, {0, 1}};

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
                cout << "\033[1;31m"
                     << "◍"
                     << "\033[0m"; // Red robot
            }
            else
            {
                cout << (maze[i][j] == 0 ? "■" : " "); // Wall or space
            }
        }
        cout << '\n';
    }
    this_thread::sleep_for(chrono::milliseconds(25));
}

vector<pair<int, int>> Robot::solve(int **maze, int width, int height, bool shouldDisplayMaze)
{
    vector<vector<bool>> visited(width, vector<bool>(height, false));

    BinaryTree<pair<int, int>> pathTree; // Use BinaryTree to store the path

    queue<pair<int, int>> q;

    pair<int, int> start = {0, 0};
    pair<int, int> end = {width - 1, height - 1};

    q.push(start);
    visited[start.first][start.second] = true;

    while (!q.empty())
    {
        pair<int, int> current = q.front();
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

                // Use the existing BinaryTree implementation to store the path
                // You can insert (newX, newY) as a new node in the binary tree
            }
        }

        if (shouldDisplayMaze)
            displayMaze(maze, width, height, x, y);
    }

    vector<pair<int, int>> path;
    pair<int, int> current_position = end;
    while (current_position != make_pair(-1, -1))
    {
        path.push_back(current_position);
        // Use the existing BinaryTree implementation to get the parent
        // You can get the parent of (currentX, currentY) from the binary tree
    }
    reverse(path.begin(), path.end());

    return (path[0] == start) ? path : vector<pair<int, int>>{};
}
