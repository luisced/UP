#include "class.h"

void util::get_numbers()
{
    cout << "ingrese un número 1" << endl;
    cin >> num1;
    cout << "ingrese un número 2" << endl;
    cin >> num2;

    cout << "numero1: " << num1 << endl;
    cout << "numero2: " << num2 << endl;
}

void util::multiply()
{

    result = num1 * num2;
    cout << "resultado multiplicación: " << result << endl;
}

void util::sum()
{
    result = num1 + num2;
    cout << "resultado suma: " << result << endl;
}

void util::mean_array(int *array, int size)
{

    int counter = 0;
    double mean = 0;
    for (size_t i = 0; i < sizeof(*array); ++i)
    {
        counter += array[i];
    }
    mean = counter / size;

    cout << "promedio: " << mean << endl;
}