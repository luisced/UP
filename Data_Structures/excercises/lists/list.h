#pragma once

#include "node.h"
#include <stdexcept> // for std::out_of_range
#include <iostream>  // for std::cout, std::endl

template <typename T>
class List
{
private:
    Node<T> *bottom = nullptr;
    int size = 0;

public:
    ~List();
    void insert(T val);
    void insert(T val, int index);
    T getAt(int index) const;
    T remove_at(int index);
    int size_of_list() const { return size; }
};

template <typename T>
List<T>::~List()
{
    while (bottom)
    {
        Node<T> *next = bottom->get_next();
        delete bottom;
        bottom = next;
    }
}

template <typename T>
void List<T>::insert(T val)
{
    Node<T> *temp = new Node<T>(val);
    temp->set_next(bottom);
    bottom = temp;
    size++;
}

template <typename T>
void List<T>::insert(T val, int index)
{
    if (index < 0 || index > size)
    {
        std::cout << "Index out of bounds" << std::endl;
        return;
    }

    Node<T> *temp = new Node<T>(val);
    if (index == 0)
    {
        temp->set_next(bottom);
        bottom = temp;
    }
    else
    {
        Node<T> *prev = bottom;
        for (int i = 0; i < index - 1; ++i)
            prev = prev->get_next();
        temp->set_next(prev->get_next());
        prev->set_next(temp);
    }
    size++;
}

template <typename T>
T List<T>::getAt(int index) const
{
    if (index < 0 || index >= size)
        throw std::out_of_range("Index out of bounds");
    Node<T> *temp = bottom;
    for (int i = 0; i < index; ++i)
        temp = temp->get_next();
    return temp->get_value();
}

template <typename T>
T List<T>::remove_at(int index)
{
    if (index < 0 || index >= size)
        throw std::out_of_range("Index out of bounds");
    Node<T> *temp;
    T value;
    if (index == 0)
    {
        temp = bottom;
        bottom = temp->get_next();
        value = temp->get_value();
        delete temp;
    }
    else
    {
        Node<T> *prev = bottom;
        for (int i = 0; i < index - 1; ++i)
            prev = prev->get_next();
        temp = prev->get_next();
        value = temp->get_value();
        prev->set_next(temp->get_next());
        delete temp;
    }
    size--;
    return value;
}
