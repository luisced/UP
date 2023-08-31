#include "stack.h"
#include <cstdlib>

void move(Stack *source, Stack *destiny, char source_name, char destiny_name)
{
    int stack1_top = source->top();
    int stack2_top = destiny->top();

    if (source->is_empty())
    {
        stack1_top = destiny->pop();
        destiny->push(stack1_top);

        // print name
        cout << "Move " << stack1_top << " from " << destiny_name << " to " << source_name << endl;

        return;
    }
    if (destiny->is_empty())
    {
        stack2_top = source->pop();
        destiny->push(stack2_top);
        // print name
        cout << "Move " << stack2_top << " from " << source_name << " to " << destiny_name << endl;
        return;
    }
    if (stack1_top > stack2_top)
    {
        stack1_top = destiny->pop();
        destiny->push(stack1_top);
        // print name
        cout << "Move " << stack1_top << " from " << destiny_name << " to " << source_name << endl;
        return;
    }
    if (stack1_top < stack2_top)
    {
        stack2_top = source->pop();
        destiny->push(stack2_top);
        // print name
        cout << "Move " << stack2_top << " from " << source_name << " to " << destiny_name << endl;
        return;
    }
}

int main()
{
    Stack pilaS(true), pilaA(false), pilaD(false);

    int movements = 31; // number of momvements

    for (int i = 0; i < movements; i++)
    {
        if (i % 3 == 0)
        {
            move(&pilaA, &pilaD, 'S', 'D');
        }
        if (i % 3 == 1)
        {
            move(&pilaS, &pilaA, 'D', 'A');
        }
        if (i % 3 == 2)
        {
            move(&pilaD, &pilaA, 'D', 'A');
        }
    }

    return 0;
}