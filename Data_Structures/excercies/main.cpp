#include <iostream>
#include <cstdlib>
#include <string>

// Excercise 1
// Write a program that asks the user to type 10 integers of an array and an integer value V.
// The program must search if V is in the array and if it is, it must display the position of V in the array.
// If V is not in the array, the program must display a message informing that V is not in the array.
// Use functions. Do not use global variables.
// Use the following array: 45, 78, 34, 56, 12, 9, 67, 43, 90, 23
using namespace std;

static void excercise1()
{
    int array[10] = {45, 78, 34, 56, 12, 9, 67, 43, 90, 23};
    int v;
    cout << "Enter a number: ";
    cin >> v;
    for (int i = 0; i < 10; i++)
    {
        if (array[i] == v)
        {
            cout << "The number " << v << " is in the array at position " << i << endl;
            return;
        }
    }
    cout << "The number " << v << " is not in the array" << endl;
}

int main()
{
    excercise1();
    // cout << "Hello, World!" << endl;
    return EXIT_SUCCESS;
}
