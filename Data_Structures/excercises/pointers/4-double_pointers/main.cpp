#include <iostream>

using namespace std;

int main()
{
    int **p_double = {new int *[5]};

    int *p1 = new int[4];
    int *p2 = new int[2];
    int *p3 = new int[1];
    int *p4 = new int[10];

    p_double[2] = p1;
    p_double[0] = p2;
    p_double[1] = p4;
    p_double[3] = p3;
    p_double[4] = new int[6];

    p_double[0][0] = 8;
    p_double[0][1] = 5;

    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            cout << p_double[i][j] << " ";
        }
    }
}