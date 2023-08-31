#include "stack.h"

void Stack::push(int i)
{
    if (heap < 5)
    {
        heap++;
        array[heap] = i;
    }
    else
    {
        cout << "Stack is full" << endl;
    }
}

int Stack::pop()
{
    int pop_v;
    if (heap >= base)
    {
        pop_v = array[heap];
        heap--;
    }

    return pop_v;
}

int Stack::top()
{
    int pop_v;
    if (heap >= base)
    {
        pop_v = array[heap];
        return pop_v;
    }
}

// bool Stack::is_empty()
// {

// }