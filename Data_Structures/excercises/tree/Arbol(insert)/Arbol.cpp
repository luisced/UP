#include "Arbol.h"

void Arbol::insert(int val)
{
	nodoArbol* nodo;
	nodo = new nodoArbol();
	nodo->valor = val;
	int cont_lv = 0;

	if (padre == NULL)
	{
		padre = nodo;
		nodo->padre = NULL;
		std::cout << " Valor insertado Padre" << val << std::endl;

		return;
	}

	nodoArbol* aux = padre;
	while (aux != NULL)
	{
		if (val == aux->valor)
		{
			std::cout << " Valor repetido " << val << std::endl;
			return;
		}
		if (aux->hijos == NULL)
		{
			aux->hijos = (nodoArbol*)malloc(2 * sizeof(nodoArbol));
			for (int i = 0; i < 2; i++)
			{
				//no usamos el new debido a que es instancia
				aux->hijos[i] = nodoArbol();
			}
		}
		cont_lv++;
		//el valor va del izquierdo
		if (val < aux->valor)
		{

			if (aux->hijos[0].padre == NULL)
			{
				aux->hijos[0].valor = val;
				aux->hijos[0].padre = aux;
				aux->hijos[0].nivel = cont_lv;
				std::cout << " Valor insertado " << val << ", izquierda nivel " << cont_lv << std::endl;
				return;
			}
			else
			{
				aux = &aux->hijos[0];
			}

		}
		//valor a la derecha
		else
		{

			if (aux->hijos[1].padre == NULL)
			{
				aux->hijos[1].valor = val;
				aux->hijos[1].padre = aux;
				aux->hijos[1].nivel = cont_lv;
				std::cout << " Valor insertado " << val << ", derecha nivel " << cont_lv << std::endl;
				return;
			}
			else
			{
				aux = &aux->hijos[1];
			}
		}
	}


}
