#include <iostream> // for std::cout, std::endl
#include <cstdlib>  // for std::rand, std::srand
#include <ctime>    // for std::time
#include <cmath>

#include "list.h"
#include "bubble_sort.h"

int main()
{
    List<int> myList;

    std::srand(static_cast<unsigned>(std::time(nullptr)));

    for (int i = 0; i < 1000; ++i)
    {
        int randomNum = std::rand() % 100;
        myList.insert(randomNum);
    }

    std::cout << "Unsorted List: " << std::endl;
    std::cout << '[';
    for (int i = 0; i < myList.size_of_list(); ++i)
    {
        std::cout << myList.getAt(i) << " ";
    }
    std::cout << ']';
    std::cout << std::endl;

    // Now sort the list
    BubbleSort<int>::sort(myList);

    std::cout << "Sorted List: " << std::endl;
    for (int i = 0; i < myList.size_of_list(); ++i)
    {
        std::cout << myList.getAt(i) << " ";
    }
    std::cout << std::endl;

    return 0;
}
