#include "lista.h"

void lista::insert(nodoArbol* val)
{

	nodoLista* temp;
	temp = new nodoLista();
	temp->arbol_ptr = val;
	if (sizeL() == 0)
	{
		bottom = temp;
		heap = temp;
		sizeCont++;
		return;
	}
	bottom->prev = temp;
	temp->next = bottom;
	bottom = temp;
	sizeCont++;
}

void lista::insertEnd(int val)
{

	sizeCont++;
	nodo* temp;
	temp = new nodo();
	temp->set(val);
	if (sizeL() == 0)
	{
		bottom = temp;
		heap = temp;
		return;
	}
	heap->next = temp;
	temp->prev = heap;
	heap = temp;
}

void lista::insert(int val, int index)
{


	if (index > sizeL())
	{
		std::cout << "La posicion a insertar no es valida" << std::endl;
		return;
	}

	nodo* temp_c;

	if (index == 0)
	{
		insert(val);
		return;
	}
	sizeCont++;
	if (index < sizeL() / 2)
	{
		temp_c = bottom;
		for (int i = 1; i <= index; i++)
		{

			if (i == index)
			{
				nodo* auxNode = new nodo();
				auxNode->set(val);
				auxNode->next = temp_c->next;
				temp_c->next = auxNode;
				return;
			}
			temp_c = temp_c->next;
		}
	}
	else
	{
		temp_c = heap;
		if (sizeL() == index)
		{
			sizeCont--;
			insertEnd(val);
			return;
		}
		for (int i = sizeL(); index <= i; i--)
		{

			if (i == index + 1)
			{
				nodo* auxNode = new nodo();
				auxNode->set(val);
				auxNode->next = temp_c;
				auxNode->prev = temp_c->prev;
				auxNode->prev->next = auxNode;
				temp_c->prev = auxNode;
				return;
			}
			temp_c = temp_c->prev;
		}
	}




}

int lista::getAt(int index)
{
	if (sizeL() == 0 || sizeL() < index)
		return ' ';

	nodo* temp_c = bottom;
	if (index < sizeL() / 2)
	{
		temp_c = bottom;
		for (int i = 0; i <= index; i++)
		{

			if (i == index)
			{
				return temp_c->get_i();
			}
			temp_c = temp_c->next;
		}
	}
	else
	{
		temp_c = heap;

		for (int i = sizeL() - 1; index <= i; i--)
		{

			if (i == index)
			{
				return temp_c->get_i();

			}
			temp_c = temp_c->prev;
		}
	}

	return 0;
}

int lista::removeAt(int index)
{
	if (index > sizeL())
	{
		std::cout << "La posicion a remover no es valida" << std::endl;
		return 0;
	}
	nodo* temp_c;
	temp_c = bottom;
	if (index == 0)
	{
		bottom = bottom->next;
		char val = temp_c->get_i();
		free(temp_c);
		return val;
	}
	for (int i = 1; i <= index; i++)
	{

		if (i == index)
		{
			char val = temp_c->next->get_i();
			nodo* aux = temp_c->next;
			temp_c->next = temp_c->next->next;

			free(aux);
			return val;
		}
		temp_c = temp_c->next;
	}

	return 0;
}

void lista::setAt(int val, int index)
{
	if (sizeL() == 0 || sizeL() < index)
		return;

	nodo* temp_c = bottom;
	if (index < sizeL() / 2)
	{
		temp_c = bottom;
		for (int i = 0; i <= index; i++)
		{

			if (i == index)
			{
				temp_c->set(val);
				return;
			}
			temp_c = temp_c->next;
		}
	}
	else
	{
		temp_c = heap;

		for (int i = sizeL() - 1; index <= i; i--)
		{

			if (i == index)
			{
				temp_c->set(val);
				return;
			}
			temp_c = temp_c->prev;
		}
	}
}

int lista::sizeL()
{
	return sizeCont;
}


