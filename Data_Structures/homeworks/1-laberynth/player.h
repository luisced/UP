#include <vector>
#include <queue>
#include <algorithm>

using namespace std;

class Robot
{
private:
    const vector<int> DIR_X = {-1, 1, 0, 0};
    const vector<int> DIR_Y = {0, 0, -1, 1};

public:
    vector<pair<int, int>> solve(int **maze, int width, int height)
    {
        int startX = 0, startY = 0;
        int endX = width - 1, endY = height - 1;

        vector<vector<bool>> visited(width, vector<bool>(height, false));
        vector<vector<pair<int, int>>> prev(width, vector<pair<int, int>>(height, {-1, -1}));

        queue<pair<int, int>> q;
        q.push({startX, startY});
        visited[startX][startY] = true;

        while (!q.empty())
        {
            auto [x, y] = q.front();
            q.pop();

            if (x == endX && y == endY)
                break;

            for (int i = 0; i < 4; i++)
            {
                int newX = x + DIR_X[i];
                int newY = y + DIR_Y[i];

                if (newX >= 0 && newX < width && newY >= 0 && newY < height &&
                    !visited[newX][newY] && maze[newX][newY] == 1)
                {
                    q.push({newX, newY});
                    visited[newX][newY] = true;
                    prev[newX][newY] = {x, y};
                }
            }
        }

        vector<pair<int, int>> path;
        for (pair<int, int> at = {endX, endY}; at != make_pair(-1, -1); at = prev[at.first][at.second])
        {
            path.push_back(at);
        }
        reverse(path.begin(), path.end());

        if (path[0] == make_pair(startX, startY))
            return path;
        return {};
    }
};
