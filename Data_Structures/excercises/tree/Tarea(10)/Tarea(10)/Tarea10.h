#include <iostream>
#include <string>
using namespace std;

/* Construye una aplicación con C++ que genere una lista circular de nombres y:

a)   Inserte tantos nombres como el usuario quiera
b)   Informe cuantos nodos tiene
c)   Extraiga e informe los nodos impares, reiteradamente, hasta que quede vacía
d)   Opción para mostrar la lista completa en cualquier momento */

struct Nombre {
    string dato;
    Nombre* sig;
};

class ListaCircular 
{
public:
    ListaCircular();
    void InsertarInicio(string nombre);
    bool InsertarInter(string nuevo, string despuesDe);
    void InsertarFinal(string nombre);
    int ContarNodos();
    void ExtraerNodosImpares();
    void Mostrar();
    
private:
    Nombre* cabecera;
    int contador;
};