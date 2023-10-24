template <class T>
class Node
{
public:
    T value; // The value stored in the node

    // For doubly-linked list
    Node<T> *next; // Pointer to the next node
    Node<T> *prev; // Pointer to the previous node

    // For binary tree
    Node<T> *left;  // Pointer to the left child
    Node<T> *right; // Pointer to the right child

    // Constructor initializes the value and sets all pointers to nullptr
    Node(T val) : value(val), next(nullptr), prev(nullptr), left(nullptr), right(nullptr) {}
};
