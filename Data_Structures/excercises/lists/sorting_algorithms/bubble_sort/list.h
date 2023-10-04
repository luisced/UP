#pragma once

#include <iostream> // for std::cout, std::endl

template <typename T>
class List
{
public:
    List() : head(nullptr), tail(nullptr), size(0) {}
    ~List();
    void insert(const T &val);
    void insert(const T &val, int index);
    void set_at(const T &val, int index);
    T getAt(int index) const;
    T remove_at(int index);
    int size_of_list() const { return size; }

private:
    class Node
    {
    public:
        Node(const T &val) : value(val), next(nullptr), prev(nullptr) {}
        T get_value() const { return value; }
        void set_value(const T &val) { value = val; }
        Node *get_next() const { return next; }
        void set_next(Node *n) { next = n; }
        Node *get_prev() const { return prev; }
        void set_prev(Node *p) { prev = p; }

    private:
        T value;
        Node *next;
        Node *prev;
    };

    Node *head;
    Node *tail;
    int size;
};

// Definitions for the List methods will be similar but with adjustments for the previous pointers.

// Definitions for the List methods.

template <typename T>
List<T>::~List()
{
    Node *current = bottom;
    while (current)
    {
        Node *next = current->get_next();
        delete current;
        current = next;
    }
}

template <typename T>
void List<T>::insert(const T &val)
{
    Node *newNode = new Node(val);
    newNode->set_next(bottom);
    bottom = newNode;
    ++size;
}

template <typename T>
void List<T>::insert(const T &val, int index)
{
    if (index < 0 || index > size)
    {
        std::cout << "Index out of bounds" << std::endl;
        return;
    }
    Node *newNode = new Node(val);
    if (index == 0)
    {
        newNode->set_next(bottom);
        bottom = newNode;
    }
    else
    {
        Node *prev = bottom;
        for (int i = 0; i < index - 1; ++i)
            prev = prev->get_next();
        newNode->set_next(prev->get_next());
        prev->set_next(newNode);
    }
    ++size;
}

template <typename T>
void List<T>::set_at(const T &val, int index)
{
    if (index < 0 || index >= size)
    {
        std::cout << "Index out of bounds" << std::endl;
        return;
    }
    Node *current = bottom;
    for (int i = 0; i < index; ++i)
        current = current->get_next();
    current->set_value(val);
}

template <typename T>
T List<T>::getAt(int index) const
{
    if (index < 0 || index >= size)
    {
        std::cout << "Index out of bounds" << std::endl;
        return T(); // Return default-constructed object of type T
    }
    Node *current = bottom;
    for (int i = 0; i < index; ++i)
        current = current->get_next();
    return current->get_value();
}

template <typename T>
T List<T>::remove_at(int index)
{
    if (index < 0 || index >= size)
    {
        std::cout << "Index out of bounds" << std::endl;
        return T(); // Return default-constructed object of type T
    }
    Node *toDelete = bottom;
    T value;
    if (index == 0)
    {
        bottom = toDelete->get_next();
        value = toDelete->get_value();
        delete toDelete;
    }
    else
    {
        Node *prev = bottom;
        for (int i = 0; i < index - 1; ++i)
            prev = prev->get_next();
        toDelete = prev->get_next();
        value = toDelete->get_value();
        prev->set_next(toDelete->get_next());
        delete toDelete;
    }
    --size;
    return value;
}
