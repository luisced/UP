# Data Structures and Examples in C++

- [Table of Contents](#table-of-contents)
- [Array](#array)
- [Linked List](#linked-list)
- [Stack](#stack)
- [Queue](#queue)
- [Hash Table](#hash-table)
- [Binary Tree](#binary-tree)
- [Graph](#graph)
- [Big O Notation](#big-o-notation)

## Table of Contents

## Array

Store a fixed-size sequence of elements.

Example:

```cpp
int arr[5] = {1, 2, 3, 4, 5};
```

Linked List
Dynamically store a sequence of elements.

Example:

```cpp
Copy code
#include <iostream>

struct Node {
    int data;
    Node* next;
};

int main() {
    // ...
}
```

## Stack

Store elements in a Last-In-First-Out (LIFO) order.

Example:

```cpp
#include <iostream>
#include <stack>

int main() {
    // ...
}
```

## Queue

Store elements in a First-In-First-Out (FIFO) order.

Example:

```cpp
#include <iostream>
#include <queue>

int main() {
    // ...
}
```

## Hash Table

Map keys to values for efficient retrieval.

Example:

````cpp
#include <iostream>
#include <unordered_map>

int main() {
    // ...
}

Binary Tree
Organize elements in a hierarchical structure.

Example:

```cpp
#include <iostream>

struct Node {
    int data;
    Node* left;
    Node* right;
};

int main() {
    // ...
}
````

## Graph

Represent a collection of interconnected nodes.

Example:

```cpp
#include <iostream>
#include <vector>

void addEdge(std::vector<int> adj[], int u, int v) {
    adj[u].push_back(v);
    adj[v].push_back(u);
}

void printGraph(std::vector<int> adj[], int V) {
    for (int v = 0; v < V; ++v) {
        std::cout << "Adjacency list of vertex " << v << ": ";
        for (const auto& u : adj[v]) {
            std::cout << u << " ";
        }
        std::cout << std::endl;
    }
}

int main() {
    int V = 5; // Number of vertices
    std::vector<int> adj[V];

    addEdge(adj, 0, 1);
    addEdge(adj, 0, 4);
    addEdge(adj, 1, 2);
    addEdge(adj, 1, 3);
    addEdge(adj, 1, 4);
    addEdge(adj, 2, 3);
    addEdge(adj, 3, 4);

    printGraph(adj, V);

    return 0;
}
```

## Big O Notation

In computer science, **Big O notation** is used to describe the **performance** or **complexity** of an algorithm. It provides an upper bound on the growth rate of the algorithm's time or space requirements as the input size increases.

The notation is expressed as `O(f(n))`, where `f(n)` represents the **worst-case behavior** of the algorithm in terms of the input size `n`. The `O` denotes the **order of growth**.

## Key Concepts

- **Upper Bound**: Big O notation represents an **upper bound** on the algorithm's performance. It characterizes how the algorithm's execution time or space usage scales as the input size grows.

- **Asymptotic Analysis**: Big O notation focuses on the **asymptotic behavior** of an algorithm, which means it considers the algorithm's performance for **large input sizes**. It helps us understand the long-term trends rather than the precise execution time for specific inputs.

- **Worst-Case Scenario**: Big O notation describes the algorithm's behavior in the **worst-case scenario**. It considers the input that causes the algorithm to perform the most work, providing a **guarantee** on the algorithm's performance.

- **Simplified Representation**: Big O notation simplifies the analysis by ignoring constant factors and lower-order terms. It focuses on the dominant factor that influences the growth rate of the algorithm.

## Common Notations

Here are some commonly used Big O notations and their corresponding growth rates:

- **O(1)**: Constant time complexity. The algorithm's performance remains constant, regardless of the input size.

- **O(log n)**: Logarithmic time complexity. The algorithm's performance grows logarithmically with the input size.

- **O(n)**: Linear time complexity. The algorithm's performance scales linearly with the input size.

- **O(n log n)**: Log-linear time complexity. The algorithm's performance grows in proportion to the input size multiplied by its logarithm.

- **O(n^2)**: Quadratic time complexity. The algorithm's performance grows quadratically with the input size.

- **O(2^n)**: Exponential time complexity. The algorithm's performance doubles with each increase in the input size.

## Examples

Let's consider a couple of examples to illustrate Big O notation:

1. **Constant Time Complexity**

```cpp
void printFirstElement(int arr[], int size) {
    std::cout << arr[0];
}

In this example, regardless of the input size size, the algorithm always performs a single operation (arr[0]). Hence, the time complexity is O(1).

Linear Time Complexity
cpp
Copy code
void printElements(int arr[], int size) {
    for (int i = 0; i < size; ++i) {
        std::cout << arr[i] << " ";
    }
}

In this example, the algorithm traverses through each element of the array once. As the input size size increases, the number of iterations also increases proportionally. Thus, the time complexity is O(n).

Conclusion
Big O notation provides a concise way to analyze and compare the performance of algorithms. By focusing on the growth rate of time or space requirements, it helps us understand how an algorithm will scale for different input sizes. It is a powerful tool for algorithmic analysis and aids in designing efficient solutions to computational problems.

```
