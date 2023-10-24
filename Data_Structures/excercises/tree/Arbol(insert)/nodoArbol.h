#pragma once
#include <cstddef>
class nodoArbol
{
public:
	nodoArbol();
	int valor;
	nodoArbol* padre = NULL;
	nodoArbol* hijos = NULL;
	int nivel = -1;


};


