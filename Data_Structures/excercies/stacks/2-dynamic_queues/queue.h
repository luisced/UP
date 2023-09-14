#include "node.h"
#include <iostream>
class stack
{
public:
    string push(string value)
    {
        node node1;
        node1.data = value;
        if (heap == NULL)
        {
            heap = &node1;
            base = &node1;
            return;
        }
        node1.next = heap;
        heap = &node1;
    };
    string pop(string)
    {
        if (heap == NULL)
            cout << "No hay más elementos en la pila" << endl;
        string value = heap->data;
        heap = heap->next;
        return value;
    }
    bool is_empty()
    {
        if (heap == NULL)
        {
            return true;
        }
        return false;
    };
    string top();

    stack(/* args */);

private:
    node *heap = NULL;
    node *base = NULL;
};

stack::stack(/* args */)
{
}

stack::~stack()
{
}
