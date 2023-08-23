#include "laberynth.h"

int main()
{
    Laberynth lab(21, 21);

    // Get the maze matrix.
    vector<vector<int>> mazeMatrix = lab.get_map();

    // Print the maze matrix.
    // for (int i = 0; i < mazeMatrix.size(); ++i)
    // {
    //     for (int j = 0; j < mazeMatrix[i].size(); ++j)
    //     {
    //         cout << mazeMatrix[i][j] << " ";
    //     }
    //     cout << endl;
    // }

    lab.print_map();
    return 0;
}
