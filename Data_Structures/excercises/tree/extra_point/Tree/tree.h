#include <iostream>
#include "./node.h"
template <typename T>
class BinaryTree
{
public:
    BinaryTree() : root(nullptr) {}

    // Destructor to clean up memory
    ~BinaryTree()
    {
        clear(root);
    }

    // Insert a value into the binary tree
    void insert(const T &value)
    {
        root = insertRecursive(root, value);
    }

    // Search for a value in the binary tree
    bool search(const T &value) const
    {
        return searchRecursive(root, value);
    }

    // Print the binary tree in-order
    void print() const
    {
        printRecursive(root);
    }

private:
    // Node structure for the binary tree
    Node<T> *root;

    // Helper function to insert a value recursively
    Node<T> *insertRecursive(Node<T> *node, const T &value)
    {
        if (!node)
        {
            return new Node<T>(value);
        }

        if (value < node->value)
        {
            node->left = insertRecursive(node->left, value);
        }
        else if (value > node->value)
        {
            node->right = insertRecursive(node->right, value);
        }

        return node;
    }

    // Helper function to search for a value recursively
    bool searchRecursive(const Node<T> *node, const T &value) const
    {
        if (!node)
        {
            return false;
        }

        if (value == node->value)
        {
            return true;
        }
        else if (value < node->value)
        {
            return searchRecursive(node->left, value);
        }
        else
        {
            return searchRecursive(node->right, value);
        }
    }

    // Helper function to print the tree in-order
    void printRecursive(const Node<T> *node) const
    {
        if (!node)
        {
            return;
        }

        printRecursive(node->left);
        std::cout << node->value << " ";
        printRecursive(node->right);
    }

    // Helper function to clear the tree and release memory
    void clear(Node<T> *node)
    {
        if (node)
        {
            clear(node->left);
            clear(node->right);
            delete node;
        }
    }
};
