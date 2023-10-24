#include <iostream>
#include <vector>
#include <ctime>
#include <random>

using namespace std;

struct TreeNode
{
	int x, y;		 // Position of the node in the maze
	bool isWall;	 // true if this is a wall, false if it's a passage
	TreeNode *left;	 // left child node in the tree (represents a connection in one direction)
	TreeNode *right; // right child node in the tree (represents a connection in the other direction)

	TreeNode(int x, int y, bool wall) : x(x), y(y), isWall(wall), left(nullptr), right(nullptr) {}
};

class BinaryTreeMaze
{
private:
	TreeNode *root;
	const int width, height;
	vector<vector<int>> mazeGrid; // 2D vector to store the maze structure for rendering

public:
	BinaryTreeMaze(int w, int h) : root(nullptr), width(w), height(h)
	{
		mazeGrid = vector<vector<int>>(height, vector<int>(width, 0)); // Initialize all cells as walls
		generateMaze();
	}

	~BinaryTreeMaze()
	{
		// Destructor to properly delete the binary tree
		destroyTree(root);
	}

	TreeNode *insert(TreeNode *node, int x, int y, bool isWall)
	{
		if (node == nullptr)
		{
			node = new TreeNode(x, y, isWall);
			mazeGrid[y][x] = isWall ? 0 : 1; // 0 represents a wall, 1 represents a passage
			return node;
		}

		// Randomly decide to go left or right
		if (rand() % 2 == 0)
		{
			if (x + 1 < width)
			{
				node->right = insert(node->right, x + 1, y, false);
			}
		}
		else
		{
			if (y + 1 < height)
			{
				node->left = insert(node->left, x, y + 1, false);
			}
		}

		return node;
	}

	void generateMaze()
	{
		srand((unsigned)time(0));		  // Seed for random number generation
		root = insert(root, 0, 0, false); // starting point, not a wall

		// Continue adding nodes until you've reached your desired width and height
		// The insert function will handle the creation of passages and walls
	}

	void destroyTree(TreeNode *node)
	{
		// Post-order deletion of nodes to avoid memory leak
		if (node != nullptr)
		{
			destroyTree(node->left);
			destroyTree(node->right);
			delete node;
		}
	}

	void printMaze()
	{
		// Print the maze from the 2D vector
		for (int i = 0; i < height; ++i)
		{
			for (int j = 0; j < width; ++j)
			{
				if (mazeGrid[i][j] == 1)
				{
					cout << " "; // space for passage
				}
				else
				{
					cout << "■"; // symbol for wall
				}
			}
			cout << endl;
		}
	}
};