#include "Clases.h"

PilaArticulos::PilaArticulos()
{
	tope = NULL;
}

void PilaArticulos::InsertarArt(string nuevo)
{
	nodo = new Bodega;
	nodo->Articulo = nuevo;
	nodo->anterior = tope;
	tope = nodo;
}


void PilaArticulos::MostrarArt()
{
	cout << "\nPILA ARTICULOS: \n" << endl;
	nodo = tope;

	if (tope == NULL) cout << "\t" << "Pila vacía" << endl;



	while (nodo != NULL)
	{
		if (tope == NULL) cout << "\t" << "Pila vacía" << endl;
		cout << "\t" << nodo->Articulo << "\t" << nodo->anterior;
	}

}

PilaEmpleados::PilaEmpleados()
{
	tope = NULL;
}

void PilaEmpleados::InsertarEmp(string nuevo)
{
	nodo = new Empresa;
	nodo->Empleado = nuevo;
	nodo->anterior = tope;
	tope = nodo;
}

void PilaEmpleados::MostrarEmp()
{
}
