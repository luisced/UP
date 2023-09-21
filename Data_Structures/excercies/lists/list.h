#include "node.h"
#include <iostream>
class List
{
private:
    Node *bottom = NULL;

public:
    void insert(char val);
    void insert(char val, int index);
    char getAt(int index);
    int size_of_list();
    char remove_at();
};

void List::insert(char val)
{
    Node *temp;
    temp = new Node();
    temp->set(val);
    if (size_of_list == 0)
    {
        bottom = temp;
    }
    temp->next = bottom;
    bottom = temp;
}

void List::insert(char val, int index)
{
    if (index > size_of_list())
    {
        std::cout << "Index out of bounds" << std::endl;
        return;
    }
    Node *counter;
    if (index == 0)
    {
        insert(val);
        return;
    }
    counter = bottom;
    for (int i = 1; i <= index; i++)
    {
        counter = counter->next;
    }
}

List::~List()
{
}
