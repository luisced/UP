#include "quick_sort.h"
#include <iostream>
#include <string>
int main()
{
    // Testing with int
    List<int> intList;
    for (int i = 0; i < 1000000; i++)
        intList.insert(rand() % 100);
    QuickSort<int>::sort(intList);

    std::cout << "Sorted integers: ";
    for (int i = 0; i < intList.size_of_list(); i++)
        std::cout << intList.getAt(i) << " ";
    std::cout << std::endl;

    // Testing with double
    List<double> doubleList;
    doubleList.insert(3.3);
    doubleList.insert(1.1);
    doubleList.insert(4.4);
    doubleList.insert(1.1);
    doubleList.insert(5.5);
    doubleList.insert(9.9);

    QuickSort<double>::sort(doubleList);

    std::cout << "Sorted doubles: ";
    for (int i = 0; i < doubleList.size_of_list(); i++)
        std::cout << doubleList.getAt(i) << " ";
    std::cout << std::endl;

    // Testing with std::string
    List<std::string> stringList;
    stringList.insert("apple");
    stringList.insert("orange");
    stringList.insert("banana");
    stringList.insert("grape");
    stringList.insert("pineapple");
    stringList.insert("mango");

    QuickSort<std::string>::sort(stringList);

    std::cout << "Sorted strings: ";
    for (int i = 0; i < stringList.size_of_list(); i++)
        std::cout << stringList.getAt(i) << " ";
    std::cout << std::endl;

    return 0;
}
