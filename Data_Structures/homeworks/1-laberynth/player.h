#include <vector>
#include <queue>
#include <algorithm>
#include <iostream>
#include <thread>
#include <chrono>

using namespace std;

class Robot
{
private:
    static const vector<pair<int, int>> DIRECTIONS;

    static void clearScreen()
    {
#ifdef _WIN32
        system("cls");
#else
        system("clear");
#endif
    }

    void displayMaze(int **maze, int width, int height, int x, int y) const
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

public:
    vector<pair<int, int>> solve(int **maze, int width, int height)
    {
        vector<vector<bool>> visited(width, vector<bool>(height, false));
        vector<vector<pair<int, int>>> prev(width, vector<pair<int, int>>(height, {-1, -1}));
        queue<pair<int, int>> q;

        pair<int, int> start = {0, 0};
        pair<int, int> end = {width - 1, height - 1};

        q.push(start);
        visited[start.first][start.second] = true;

        while (!q.empty())
        {
            auto [x, y] = q.front();
            q.pop();

            if (make_pair(x, y) == end)
                break;

            for (const auto &[dx, dy] : DIRECTIONS)
            {
                int newX = x + dx, newY = y + dy;
                if (newX >= 0 && newX < width && newY >= 0 && newY < height &&
                    !visited[newX][newY] && maze[newX][newY] == 1)
                {
                    q.push({newX, newY});
                    visited[newX][newY] = true;
                    prev[newX][newY] = {x, y};
                }
            }
            // Uncomment the below line to display maze while solving
            // displayMaze(maze, width, height, x, y);
        }

        vector<pair<int, int>> path;
        for (pair<int, int> at = end; at != make_pair(-1, -1); at = prev[at.first][at.second])
        {
            path.push_back(at);
        }
        reverse(path.begin(), path.end());

        return (path[0] == start) ? path : vector<pair<int, int>>{};
    }
};
const vector<pair<int, int>> Robot::DIRECTIONS = {{-1, 0}, {1, 0}, {0, -1}, {0, 1}};
//                                                   Up     Down    Left      Right