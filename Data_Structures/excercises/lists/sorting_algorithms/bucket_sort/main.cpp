#include "bucket_sort.h"
#include <iostream>
#include <string>
int main()
{
    // Testing with int
    List<int> intList;
    for (int i = 0; i < 1000000; i++)
        intList.insert(rand() % 100);

    std::cout << "Unsorted integers: \n";

    BucketSort<int>::sort(intList);

    std::cout << "Sorted integers: \n";
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

    BucketSort<double>::sort(doubleList);

    std::cout << "\nSorted doubles: ";
    for (int i = 0; i < doubleList.size_of_list(); i++)
        std::cout << doubleList.getAt(i) << " ";
    std::cout << std::endl;

    return 0;
}
