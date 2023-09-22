#include "queue.h"
#include <iostream>

int main()
{
    Queue queue;
    for (int i = 0; i < 255; i++)
        queue.push(i);

    while (!queue.isEmpty())
    {
        std::cout << queue.pop() << std::endl;
    }
    return 0;
}