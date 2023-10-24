#include <iostream>

// Define a Node class for the binary tree
template <typename T>
struct Node
{
    T data;
    Node<T> *left;
    Node<T> *right;

    Node(const T &value) : data(value), left(nullptr), right(nullptr) {}
};

// Define a BinaryTree class to manage the binary tree
template <typename T>
class BinaryTree
{
private:
    Node<T> *root;

    // Private function to insert a value into the binary tree recursively
    Node<T> *insertRecursive(Node<T> *node, const T &value)
    {
        if (!node)
        {
            return new Node<T>(value);
        }

        if (value < node->data)
        {
            node->left = insertRecursive(node->left, value);
        }
        else if (value > node->data)
        {
            node->right = insertRecursive(node->right, value);
        }

        return node;
    }

public:
    BinaryTree() : root(nullptr) {}

    // Public function to insert a value into the binary tree
    void insert(const T &value)
    {
        root = insertRecursive(root, value);
    }

    // Merge the current binary tree with another binary tree
    void merge(const BinaryTree<T> &otherTree)
    {
        mergeRecursive(otherTree.root);
    }

    // Helper function to recursively merge nodes from another tree
    void mergeRecursive(Node<T> *node)
    {
        if (!node)
        {
            return;
        }

        insert(node->data); // Insert the node's data into the current tree

        mergeRecursive(node->left);  // Recursively merge the left subtree
        mergeRecursive(node->right); // Recursively merge the right subtree
    }

    // Inorder traversal to display the tree
    void inorder(Node<T> *node) const
    {
        if (node)
        {
            inorder(node->left);
            std::cout << node->data << " ";
            inorder(node->right);
        }
    }

    // Display the tree in inorder traversal
    void display() const
    {
        inorder(root);
        std::cout << std::endl;
    }

    // Make sure to add destructor to release memory when the tree is no longer needed
    ~BinaryTree()
    {
        clear(root);
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