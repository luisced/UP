#include "nodoArbol.h"
#include <cstddef>
#pragma once
class nodoLista
{

public:
	nodoArbol* arbol_ptr = NULL;
	nodoLista* next = NULL;
	nodoLista* prev = NULL;
};

