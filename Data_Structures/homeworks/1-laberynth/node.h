#include <cmath>

class Node
{
public:
    int x, y;     // Coordenadas del nodo
    float g;      // Costo para moverse desde el inicio hasta este nodo
    float h;      // Heurística: Estimación del costo desde este nodo hasta el final
    float f;      // f = g + h
    Node *parent; // Nodo anterior en la ruta óptima desde el inicio hasta este nodo

    Node(int x, int y) : x(x), y(y), g(INFINITY), h(0), f(INFINITY), parent(nullptr) {}
};
