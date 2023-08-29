#include "stack.h"
#include <cstdlib>

int main()
{

    Stack *pilas_p;
    pilas_p = (Stack *)malloc(2 * sizeof(Stack)); // reserver memory for two Stack classes
    for (int i = 0; i < 5; i++)
    {
        // assign new stack with new

        Stack *auxStack = new Stack(30 * i, 31.3);
        pilas_p[i] = *auxStack;

        return 0;
    };
}