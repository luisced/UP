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
    bool is_empty()
    {
        if (heap < base)
        {
            return true;
        }
        return false;
    };

private:
    int array[5];
    int heap = -1;
    int base = 0;
};