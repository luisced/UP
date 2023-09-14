#include "node.h"
class Queue
{
private:
    Node *bottom = NULL;
    Node *heap = NULL;

public:
    void push(char val)
    {
        Node *new_node = new Node();
        new_node->set(val);
        if (heap == NULL)
        {
            heap = temp;
            bottom = temp;
            return;
        }
        temp->next = bottom;
        bottom = temp;
        free(temp);
    }

    char pop();
    char top();
    bool isEmpty();