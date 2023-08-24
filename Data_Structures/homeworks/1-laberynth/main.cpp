#include "robot.h"
#include "laberynth.h"

int main()
{

    Laberynth maze(51, 101);
    // Laberynth maze(11, 21);

    Robot robot;
    vector<pair<int, int>> path = robot.solve(maze.get_map(), maze.get_width(), maze.get_height());

    for (const pair<int, int> &pos : path)
    {
        maze.get_map()[pos.first][pos.second] = 2;
    }

    maze.print_map();

    return 0;
}
