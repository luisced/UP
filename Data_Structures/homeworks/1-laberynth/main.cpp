#include "player.h"
#include "laberynth.h"

int main()
{
    Laberynth lab(21, 21);

    Robot robot;
    auto path = robot.solve(lab.get_map(), lab.get_width(), lab.get_height());

    for (const auto &pos : path)
    {
        lab.get_map()[pos.first][pos.second] = 2;
    }

    lab.print_map();

    return 0;
}
