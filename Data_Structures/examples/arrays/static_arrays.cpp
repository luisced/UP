#include <iostream>
#include <array>
#include <iomanip>
#include <string>

using namespace std;

// Exercise 1: Sum of Array Elements
// Write a function that takes in a static array of integers and returns the sum of all its elements.

static int sum_of_array_elements(array<int, 5> numbers)
{
    int result = 0;
    for (int i = 0; i < numbers.size(); i++)
    {
        result += numbers[i];
    }

    return result;
}

// Exercise 2: Find Maximum Element
// Write a function that takes in a static array of integers and returns the maximum element in the array.
static int maximum_number(array<int, 5> numbers)
{
    int result = numbers[0];
    for (int i = 0; i < numbers.size(); i++)
    {
        if (numbers[i] > result)
        {
            result = numbers[i];
        }
    }

    return result;
}

// Exercise 3: Check Array Equality
// Write a function that takes in two static arrays of integers and returns true if they are equal (i.e., contain the same elements in the same order) and false otherwise.
static bool check_array_equality(array<int, 5> numbers1, array<int, 5> numbers2)
{
    bool result = true;
    for (int i = 0; i < numbers1.size(); i++)
    {
        if (numbers1[i] != numbers2[i])
        {
            result = false;
        }
    }

    return result;
}

// Exercise 4: Reverse Array
// Write a function that takes in a static array of integers and reverses the order of its elements. The function should modify the original array.

// Exercise 5: Remove Duplicates
// Write a function that takes in a static array of integers and removes any duplicate elements, returning a new array with unique elements only.

// Exercise 6: Insert Element
// Write a function that takes in a static array of integers, an index, and a value. The function should insert the value at the given index, shifting all the elements to the right.

// Exercise 7: Merge Arrays
// Write a function that takes in two static arrays of integers and merges them into a new array, combining all the elements from both arrays.

// Exercise 8: Find Element Index
// Write a function that takes in a static array of integers and a target value. The function should return the index of the first occurrence of the target value in the array, or -1 if the value is not found.

int main()
{
    array<int, 5> numbers = {1, 2, 3, 4, 5};
    // cout << sum_of_array_elements(numbers) << endl;
    cout << maximum_number(numbers) << endl;
    return 0;
}
