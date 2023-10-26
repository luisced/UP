#include "Tarea10.h"

ListaCircular::ListaCircular() 
{
    cabecera = nullptr;
    contador = 0;
}

void ListaCircular::InsertarInicio(string nombre) 
{
    Nombre* nuevo = new Nombre;
    nuevo->dato = nombre;

    if (!cabecera) 
    {
        cabecera = nuevo;
        nuevo->sig = cabecera;
    } 
    else 
    {
        Nombre* temp = cabecera;
        while (temp->sig != cabecera) 
        {
            temp = temp->sig;
        }
        temp->sig = nuevo;
        nuevo->sig = cabecera;
        cabecera = nuevo;
    }

    contador++;
}

bool ListaCircular::InsertarInter(string nuevo, string despuesDe) 
{
    if (!cabecera) 
    {
        cout << "La lista está vacía." << endl;
        return false;
    }

    Nombre* actual = cabecera;
    do 
    {
        if (actual->dato == despuesDe) 
        {
            Nombre* nuevoNodo = new Nombre;
            nuevoNodo->dato = nuevo;
            nuevoNodo->sig = actual->sig;
            actual->sig = nuevoNodo;
            contador++;
            return true;
        }
        actual = actual->sig;
    } while (actual != cabecera);

    cout << "No se encontró '" << despuesDe << "'. No se insertó." << endl;
    return false;
}

void ListaCircular::InsertarFinal(string nombre) 
{
    Nombre* nuevo = new Nombre;
    nuevo->dato = nombre;

    if (!cabecera) 
    {
        cabecera = nuevo;
        nuevo->sig = cabecera;
    } 
    else 
    {
        Nombre* temp = cabecera;
        while (temp->sig != cabecera) 
        {
            temp = temp->sig;
        }
        temp->sig = nuevo;
        nuevo->sig = cabecera;
    }

    contador++;
}

int ListaCircular::ContarNodos() 
{
    return contador;
}

void ListaCircular::ExtraerNodosImpares() 
{
    if (!cabecera) 
    {
        cout << "La lista está vacía." << endl;
        return;
    }

    Nombre* actual = cabecera;
    int eliminados = 0;
    bool eliminar = true;

    cout << "Nodos impares extraídos:" << endl;

    while (contador > 0) 
    {
        if (eliminar) 
        {
            Nombre* temp = actual->sig;
            cout << actual->dato << endl;
            actual->sig = temp->sig;
            delete temp;
            eliminados++;
            contador--;
        } 
        else 
        {
            actual = actual->sig;
        }
        if (contador == 1) 
        {
            cabecera = actual;
            break;
        }
        eliminar = !eliminar;
    }

    cabecera = actual;
}

void ListaCircular::Mostrar() 
{
    if (!cabecera) 
    {
        cout << "La lista está vacía." << endl;
        return;
    }

    Nombre* temp = cabecera;
    cout << "Lista de nombres:" << endl;
    do 
    {
        cout << temp->dato << endl;
        temp = temp->sig;
    } while (temp != cabecera);
}
