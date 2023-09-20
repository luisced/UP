#include "node.h"
class Queue
{
private:
    Node *bottom = NULL;
    Node *heap = NULL;

public:
    void push(char val)
    {
        Node *new_node;
        new Node();
        new_node->set(val);
        if (heap == NULL)
        {
            heap = new_node;
            bottom = new_node;
            return;
        }
        new_node->next = bottom;
        bottom = new_node;
    }

    char pop()
    {
        if (heap == NULL)
            return ' ';
        char val = heap->get_c();
        Node *temp = heap;
        heap = heap->next;
        if (heap == NULL)
            bottom = NULL;
        free(temp);
        return val;
    }
    char top()
    {
        if (heap == NULL)
            return ' ';
        return heap->get_c();
    }
    bool isEmpty()
    {
        return heap == NULL;
    };
};