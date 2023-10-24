#include <iostream>
#include "../node.h"
template <typename T>
class List
{
public:
    List() : head(nullptr), tail(nullptr), size(0) {}
    ~List();

    void insert(const T &val);
    void insert(const T &val, int index);
    void set_at(const T &val, int index);
    T &getAt(int index);
    T remove_at(int index);
    int size_of_list() const { return size; }
    bool isEmpty() const { return size == 0; }

private:
    Node<T> *head;
    Node<T> *tail;
    int size;
};
