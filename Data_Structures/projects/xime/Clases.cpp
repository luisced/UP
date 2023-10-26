#include "Clases.h"
void PilaArticulos::InsertarArt(string nuevo)
{
	Bodega *nodo = new Bodega;
	nodo->Articulo = nuevo;
	nodo->anterior = tope;
	nodo->siguiente = nullptr;
	if (tope)
	{
		tope->siguiente = nodo;
	}
	tope = nodo;
}

string PilaArticulos::ExtraerArt()
{
	if (!tope)
		return "";
	string articulo = tope->Articulo;
	Bodega *temp = tope;
	tope = tope->anterior;
	if (tope)
	{
		tope->siguiente = nullptr;
	}
	delete temp;
	return articulo;
}

void PilaArticulos::MostrarArt()
{
	Bodega *temp = tope;
	while (temp)
	{
		cout << temp->Articulo << endl;
		temp = temp->anterior;
	}
}

void PilaEmpleados::InsertarEmp(string nuevo)
{
	Empresa *nodo = new Empresa;
	nodo->Empleado = nuevo;
	nodo->anterior = tope;
	nodo->siguiente = nullptr;
	if (tope)
	{
		tope->siguiente = nodo;
	}
	tope = nodo;
}

string PilaEmpleados::ExtraerEmp()
{
	if (!tope)
		return "";
	string empleado = tope->Empleado;
	Empresa *temp = tope;
	tope = tope->anterior;
	if (tope)
	{
		tope->siguiente = nullptr;
	}
	delete temp;
	return empleado;
}

void PilaEmpleados::MostrarEmp()
{
	Empresa *temp = tope;
	while (temp)
	{
		cout << temp->Empleado << endl;
		temp = temp->anterior;
	}
}

void ListaAsignaciones::InsertarAsignacion(string empleado, string articulo)
{
	Asignacion *nodo = new Asignacion;
	nodo->Empleado = empleado;
	nodo->Articulo = articulo;
	nodo->siguiente = inicio;
	inicio = nodo;
}

void ListaAsignaciones::MostrarAsignaciones()
{
	Asignacion *temp = inicio;
	while (temp)
	{
		cout << "Empleado: " << temp->Empleado << " - Articulo: " << temp->Articulo << endl;
		temp = temp->siguiente;
	}
}