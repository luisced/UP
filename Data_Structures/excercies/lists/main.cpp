#include "list.h"
#include <iostream>

int main()
{
    List<int> generic_list;

    // Insert elements into the list
    generic_list.insert('a');
    generic_list.insert(20);
    generic_list.insert(30);
    generic_list.insert(40, 1); // Insert 40 at index 1

    // Display the elements in the list
    std::cout << "List contents:\n";
    for (int i = 0; i < generic_list.size_of_list(); ++i)
    {
        std::cout << "Element at index " << i << ": " << generic_list.getAt(i) << '\n';
    }

    // Remove an element from the list
    try
    {
        int value = generic_list.remove_at(2); // Remove element at index 2
        std::cout << "\nRemoved Element: " << value << '\n';
    }
    catch (const std::out_of_range &e)
    {
        std::cerr << e.what() << '\n';
    }

    // Display the elements in the list after removal
    std::cout << "\nList contents after removal:\n";
    for (int i = 0; i < generic_list.size_of_list(); ++i)
    {
        std::cout << "Element at index " << i << ": " << generic_list.getAt(i) << '\n';
    }

    return 0;
}
