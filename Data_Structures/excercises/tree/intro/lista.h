#pragma once
#include "nodoLista.h" 
#include <iostream>
class lista
{
private:
	nodoLista* bottom = NULL;
	nodoLista* heap = NULL;
	int sizeCont = 0;
public:
	void insert(nodoArbol* val);
	void insertEnd(nodoArbol* val);
	void insert(nodoArbol* val, int index);
	nodoArbol* getAt(int index);
	nodoArbol* removeAt(int index);
	void setAt(nodoArbol* val, int index);
	int sizeL();

};

