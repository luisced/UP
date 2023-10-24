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

    // You can add other binary tree operations as needed

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
