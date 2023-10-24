#include "list.h"

template <typename T>
List<T>::~List()
{
    Node<T> *current = head;
    while (current)
    {
        Node<T> *next = current->next;
        delete current;
        current = next;
    }
}

template <typename T>
void List<T>::insert(const T &val)
{
    Node<T> *newNode = new Node<T>(val);
    if (!head)
    {
        head = newNode;
        tail = newNode;
    }
    else
    {
        tail->next = newNode;
        newNode->prev = tail;
        tail = newNode;
    }
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
    Node<T> *newNode = new Node<T>(val);
    if (index == 0)
    {
        newNode->next = head;
        if (head)
            head->prev = newNode;
        head = newNode;
        if (!tail)
            tail = newNode;
    }
    else
    {
        Node<T> *prev = head;
        for (int i = 0; i < index - 1; ++i)
            prev = prev->next;
        newNode->next = prev->next;
        if (prev->next)
            prev->next->prev = newNode;
        prev->next = newNode;
        newNode->prev = prev;
        if (!newNode->next)
            tail = newNode;
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
    Node<T> *current = head;
    for (int i = 0; i < index; ++i)
        current = current->next;
    current->value = val;
}

template <typename T>
T &List<T>::getAt(int index)
{
    if (index < 0 || index >= size) // Changed 'or' to '||'
    {
        std::cerr << "Index out of bounds" << std::endl;
        throw std::out_of_range("Index out of bounds"); // It's better to throw an exception here
    }
    Node<T> *current = head;
    for (int i = 0; i < index; ++i)
        current = current->next;
    return current->value; // Now returns a reference
}

template <typename T>
T List<T>::remove_at(int index)
{
    if (index < 0 or index >= size)
    {
        std::cout << "Index out of bounds" << std::endl;
        return T(); // Return default-constructed object of type T
    }
    Node<T> *toDelete = head;
    T value;
    if (index == 0)
    {
        head = toDelete->next;
        if (head)
            head->prev = nullptr;
        else
            tail = nullptr;
        value = toDelete->value;
        delete toDelete;
    }
    else
    {
        Node<T> *prev = head;
        for (int i = 0; i < index - 1; ++i)
            prev = prev->next;
        toDelete = prev->next;
        value = toDelete->value;
        prev->next = toDelete->next;
        if (toDelete->next)
            toDelete->next->prev = prev;
        else
            tail = prev;
        delete toDelete;
    }
    --size;
    return value;
}
