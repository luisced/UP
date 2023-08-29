#include <iostream>
using namespace std;

class Stack
{
public:
    // constructor
    Stack(bool fullStack)
    {
        if (fullStack)
            for (int i = 5; i > 0; i--)
            {
                push(i);
            }
    };
    void push(int i);
    int pop();
    int top();

private:
    int array[5];
    int heap = -1;
    int base = 0;
};