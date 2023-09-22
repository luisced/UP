#include <iostream>

class Stack
{
private:
    int top;
    int capacity;
    int *arr;

public:
    Stack() : top(-1), capacity(1)
    {
        arr = new int[capacity];
    }

    ~Stack()
    {
        delete[] arr;
    }

    void resize()
    {
        int *newArr = new int[capacity * 2];
        for (int i = 0; i <= top; ++i)
        {
            newArr[i] = arr[i];
        }
        delete[] arr;
        arr = newArr;
        capacity *= 2;
    }

    bool push(int x)
    {
        if (top >= capacity - 1)
        {
            resize();
        }
        arr[++top] = x;
        return true;
    }

    int pop()
    {
        if (top < 0)
        {
            return 0;
        }
        return arr[top--];
    }

    bool isEmpty()
    {
        return (top < 0);
    }
};
