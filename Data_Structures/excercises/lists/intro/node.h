#pragma once

template <typename T>
class Node
{
private:
    T value;
    Node *next;

public:
    Node() : value(T()), next(nullptr) {}

    Node(const T &val) : value(val), next(nullptr) {}

    T get_value() const
    {
        return value;
    }

    void set_value(const T &val)
    {
        value = val;
    }

    Node *get_next() const
    {
        return next;
    }

    void set_next(Node *n)
    {
        next = n;
    }
};
