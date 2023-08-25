#include "robot.h"
#include "laberynth.h"

string asciiArt =
    "\x1B[36m   _____                           _________      .__                     \n"
    "  /     \\ _____  ________ ____    /   _____/ ____ |  |___  __ ___________ \n"
    " /  \\ /  \\\\__  \\ \\___   _/ __ \\   \\_____  \\ /  _ \\|  |\\  \\/ _/ __ \\_  __ \\\n"
    "/    Y    \\/ __ \\_/    /\\  ___/   /        (  <_> |  |_\\   /\\  ___/|  | \\/\n"
    "\\____|__  (____  /_____ \\\\___  > /_______  /\\____/|____/\\_/  \\___  |__|   \n"
    "        \\/     \\/      \\/    \\/          \\/                      \\/        \x1B[0m\n";

// Main menu of the program
string ascii_menu =
    "\x1B[36m╔════════════════╗\n"
    "║ O P T I O N S  ║\n"
    "╠════════════════╣\n"
    "║ 1. E A S Y     ║\n"
    "║ 2. M E D I U M ║\n"
    "║ 3. H A R D     ║\n"
    "║ 4. C U S T O M ║\n"
    "║ 5. E X I T     ║\n"
    "╚════════════════╝\x1B[0m\n";

void pressEnterToContinue()
{
    cout << "Press Enter to continue...";
    cin.ignore();
    cin.get();
}

void give_maze_to_robot(const int x, const int y, bool visualize_robot = false)
{
    system("clear");

    Laberynth maze(x, y);
    Robot robot;
    vector<pair<int, int>> path;

    if (visualize_robot)
    {
        path = robot.solve(maze.get_map(), maze.get_width(), maze.get_height(), true);
        for (const pair<int, int> &pos : path)
        {
            maze.get_map()[pos.first][pos.second] = 2;
        }

        // maze.print_map();
    }
    else
    {
        path = robot.solve(maze.get_map(), maze.get_width(), maze.get_height());
        for (const pair<int, int> &pos : path)
        {
            maze.get_map()[pos.first][pos.second] = 2;
        }

        maze.print_map();
    }

    pressEnterToContinue();
}

void menu()
{
    int option;

    // Menu loop
    while (true)
    {
        system("clear");

        cout << asciiArt << endl;
        cout << ascii_menu << endl;

        int option;
        cin >> option;

        switch (option)
        {
        case 1:
            cout << "Easy" << endl;
            give_maze_to_robot(11, 21);
            break;
        case 2:
            cout << "Medium" << endl;
            give_maze_to_robot(21, 41);
            break;
        case 3:
            cout << "Hard" << endl;
            give_maze_to_robot(41, 81);
            break;
        case 4:
            cout << "Custom" << endl;
            int x, y;
            cout << "Enter the width of the maze: ";
            cin >> x;
            cout << "Enter the height of the maze: ";
            cin >> y;
            cout << "Would you like to see the robot's position? y/n" << endl;
            char visualize_robot;
            cin >> visualize_robot;
            visualize_robot == 'y' ? give_maze_to_robot(x, y, true) : give_maze_to_robot(x, y, false);
            break;
        case 5:
            cout << "Exiting..." << endl;
            return;
        default:
            cout << "Invalid option" << endl;
            break;
        }
    }
}