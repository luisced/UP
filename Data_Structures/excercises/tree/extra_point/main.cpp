#include "player.h"
#include "maze.h"
#include <vector>
#include <iostream>
#include <string>

std::string asciiArt =
	"\x1B[36m   _____                           _________      .__                     \n"
	"  /     \\ _____  ________ ____    /   _____/ ____ |  |___  __ ___________ \n"
	" /  \\ /  \\\\__  \\ \\___   _/ __ \\   \\_____  \\ /  _ \\|  |\\  \\/ _/ __ \\_  __ \\\n"
	"/    Y    \\/ __ \\_/    /\\  ___/   /        (  <_> |  |_\\   /\\  ___/|  | \\/\n"
	"\\____|__  (____  /_____ \\\\___  > /_______  /\\____/|____/\\_/  \\___  |__|   \n"
	"        \\/     \\/      \\/    \\/          \\/                      \\/        \x1B[0m\n";

// Main menu of the program
std::string ascii_menu =
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
	std::cout << "Press Enter to continue...";
	std::cin.ignore();
	std::cin.get();
}

void give_maze_to_robot(const int x, const int y, bool visualize_robot = false)
{
	system("clear");

	Laberynth maze(x, y);
	Robot robot;
	std::vector<std::pair<int, int>> path;

	if (visualize_robot)
	{
		path = robot.solve(maze.get_map(), maze.get_width(), maze.get_height(), true);
		for (const std::pair<int, int> &pos : path)
		{
			maze.get_map()[pos.first][pos.second] = 2;
		}
	}
	else
	{
		path = robot.solve(maze.get_map(), maze.get_width(), maze.get_height());
		for (const std::pair<int, int> &pos : path)
		{
			maze.get_map()[pos.first][pos.second] = 2;
		}
		std::cout << "The robot has found the exit!" << std::endl;

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

		std::cout << asciiArt << std::endl;
		std::cout << ascii_menu << std::endl;

		int option;
		std::cin >> option;

		switch (option)
		{
		case 1:
			std::cout << "Easy" << std::endl;
			give_maze_to_robot(11, 21);
			break;
		case 2:
			std::cout << "Medium" << std::endl;
			give_maze_to_robot(21, 41);
			break;
		case 3:
			std::cout << "Hard" << std::endl;
			give_maze_to_robot(41, 81);
			break;
		case 4:
			std::cout << "Custom" << std::endl;
			int x, y;
			std::cout << "Enter the width of the maze: ";
			std::cin >> x;
			std::cout << "Enter the height of the maze: ";
			std::cin >> y;
			std::cout << "Would you like to see the robot's position? y/n" << std::endl;
			char visualize_robot;
			std::cin >> visualize_robot;
			visualize_robot == 'y' ? give_maze_to_robot(x, y, true) : give_maze_to_robot(x, y, false);
			break;
		case 5:
			std::cout << "Exiting..." << std::endl;
			return;
		default:
			std::cout << "Invalid option" << std::endl;
			break;
		}
	}
}

int main()
{
	system("clear");
	menu();
	return 0;
}
