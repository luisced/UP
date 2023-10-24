#include <iostream>
#include "./Maze/maze.h" // Adjust the include path as necessary

int main()
{
	// Seed for random number generation
	srand((unsigned int)time(NULL));

	// Create a maze with width and height
	int width = 10;
	int height = 10;
	Maze maze(width, height);

	// Print the initial maze
	std::cout << "Initial Maze:" << std::endl;
	maze.printMaze();
	std::cout << std::endl;

	// Now, you might want to add some walls manually or perform other operations,
	// but since your maze is randomly generated, this is optional.

	// Uncomment below if you want to add walls manually
	/*
	maze.setWall(1, 1);
	maze.setWall(2, 2);
	// ... more walls
	*/

	// Print the maze after adding walls
	std::cout << "Maze after adding walls:" << std::endl;
	maze.printMaze();
	std::cout << std::endl;

	// If you had a solveMaze function, you would call it here
	// maze.solveMaze();

	// Uncomment below to print the maze after solving
	/*
	std::cout << "Maze after solving:" << std::endl;
	maze.printMaze();
	*/

	return 0;
}

// #include <opencv2/opencv.hpp>

// int matrix[8][10] = {
// {0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
// {2, 0, 1, 0, 0, 0, 0, 0, 0, 0},
// {0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
// {0, 1, 1, 1, 1, 1, 1, 1, 1, 0},
// {0, 0, 0, 0, 0, 0, 0, 0, 1, 1},
// {1, 1, 1, 1, 1, 1, 1, 0, 0, 3},
// {0, 0, 0, 0, 0, 0, 1, 1, 1, 1},
// {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
// };

// void drawCell(cv::Point origin, int type, cv::Mat * canvas)
// {
// 	int sizeCell = 20;
// 	int sizeThick = 2;
// 	cv::Point final(0,0);

// 	switch (type)
// 	{
// 		//celda completa
// 	case 0:

// 		final.y = origin.y + sizeCell;
// 		final.x = origin.x + sizeCell;
// 		cv::rectangle(*canvas, origin, final,
// 			cv::Scalar(255, 200, 200),
// 			sizeThick, cv::LINE_8);
// 		//cv::line(*canvas, origin, final, (255, 200, 200), 5);
// 		break;
// 	case 1:
// 		final.x = origin.x;
// 		final.y = origin.y;
// 		//pared izquierda solamente
// 		final.y = origin.y + sizeCell;
// 		cv::line(*canvas, origin, final, (255, 200, 200), sizeThick);
// 		break;
// 	case 2:
// 		final.x = origin.x;
// 		final.y = origin.y;
// 		//pared superior solamente
// 		//origin.x = origin.x + sizeCell;
// 		final.x = origin.x + sizeCell;
// 		cv::line(*canvas, origin, final, (255, 200, 200), sizeThick);
// 		break;
// 	case 3:
// 		final.x = origin.x;
// 		final.y = origin.y;
// 		//pared derecha solamente
// 		origin.x = origin.x + sizeCell;
// 		final.y = origin.y + sizeCell;
// 		final.x += sizeCell;
// 		cv::line(*canvas, origin, final, (255, 200, 200), sizeThick);
// 		break;
// 	case 4:
// 		final.x = origin.x;
// 		final.y = origin.y;
// 		//pared inferior solamente
// 		origin.y = origin.y + sizeCell;
// 		final.x = origin.x + sizeCell;
// 		final.y += sizeCell;
// 		cv::line(*canvas, origin, final, (255, 200, 200), sizeThick);
// 		break;
// 	case 5:
// 		final.x = origin.x;
// 		final.y = origin.y;
// 		//pared izquiera y derecha solamente
// 		final.y = origin.y + sizeCell;
// 		cv::line(*canvas, origin, final, (255, 200, 200), sizeThick);

// 		origin.y = origin.y + sizeCell;
// 		cv::line(*canvas, origin, final, (255, 200, 200), sizeThick);

// 		break;
// 	case 6:
// 		final.x = origin.x;
// 		final.y = origin.y;
// 		//pared superior e inferior solamente
// 		final.x = origin.x + sizeCell;
// 		cv::line(*canvas, origin, final, (255, 200, 200), sizeThick);

// 		origin.y = origin.y + sizeCell;

// 		cv::line(*canvas, origin, final, (255, 200, 200), sizeThick);
// 		break;
// 	}

// }

// void fillCell(cv::Point origin, cv::Mat* canvas)
// {
// 	cv::Point fin;
// 	origin.x++;
// 	origin.y++;
// 	fin.x = origin.x + 18;
// 	fin.y = origin.y + 18;
// 	cv::Scalar color;

// 	cv::rectangle(*canvas, origin, fin, cv::Scalar(0, 255, 0), -1, cv::LINE_8);
// }

// int main()
// {
// 	cv::Mat imagen(500, 500, CV_8UC3, cv::Scalar(0, 0, 100));;

// 	drawCell(cv::Point(10, 10), 0, &imagen);

// 	int ini_x = (500 - 8 * 20)/2;
// 	int ini_y = (500 - 10 * 20) / 2;

// 	for (int i = 0; i < 8; i += 7)
// 	{
// 		for (int j = 0; j < 10; j++)
// 		{
// 			if (matrix[i][j] != 2 && matrix[i][j] != 3 )
// 			{

// 				if (i == 0)
// 				{
// 					drawCell(cv::Point(ini_x + (j * 20), ini_y), 2, &imagen);
// 				}
// 				else
// 				{
// 					drawCell(cv::Point(ini_x + (j * 20), ini_y+ 7*20 ), 4, &imagen);

// 				}

// 			}
// 		}
// 	}
// 	for (int i = 0; i < 8; i ++)
// 	{
// 		for (int j = 0; j < 10; j+=9)
// 		{
// 			if (matrix[i][j] != 2 && matrix[i][j] != 3)
// 			{
// 				if (j == 0)
// 				{
// 					drawCell(cv::Point(ini_x, ini_y + i * 20), 1, &imagen);
// 				}
// 				else
// 				{
// 					drawCell(cv::Point(ini_x + (9 * 20), ini_y + i * 20), 3, &imagen);

// 				}
// 			}
// 		}
// 	}

// 	for (int i = 0; i < 8; i++)
// 	{
// 		for (int j = 0; j < 10; j ++)
// 		{
// 			if (matrix[i][j] == 1)
// 			{
// 				if (j > 0 && matrix[i][j] != matrix[i][j - 1])
// 				{
// 					drawCell(cv::Point(ini_x + j * 20, ini_y + i * 20), 1, &imagen);
// 				}
// 				if (j < 9 && matrix[i][j] != matrix[i][j + 1])
// 				{
// 					drawCell(cv::Point(ini_x + j * 20, ini_y + i * 20), 3, &imagen);
// 				}
// 				if (i > 0 && matrix[i][j] != matrix[i - 1][j])
// 				{
// 					drawCell(cv::Point(ini_x + j * 20, ini_y + i * 20), 2, &imagen);
// 				}
// 				if (i < 7 && matrix[i][j] != matrix[i + 1][j])
// 				{
// 					drawCell(cv::Point(ini_x + j * 20, ini_y + i * 20), 4, &imagen);
// 				}
// 			}

// 		}
// 	}

// 	fillCell(cv::Point(ini_x, ini_y), &imagen);

// 	cv::imshow("Prueba imagen", imagen);

// 	cv::waitKey(0);
// 	return 0;
// }
