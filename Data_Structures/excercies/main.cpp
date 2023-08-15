#include <iostream>
#include <cstdlib>
#include <string>
#include "util.cpp"

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

void modify(int *value)
{
    *value *= 5;
}

int main()
{
    // excercise get 2 numbers
    util my_util; // create an instance of the util class

    while (true)
    {
        cout << "Ingrese una opción: \n1. Suma\n2. Multiply\n3. Salir";
        int option;
        cin >> option;
        switch (option)
        {
        case 1:
            my_util.get_numbers();
            my_util.sum();
            break;
        case 2:
            my_util.get_numbers();
            my_util.multiply();
            break;
        case 3:
            return EXIT_SUCCESS;
        default:
            cout << "Opción inválida";
            break;
        }
    }
}
