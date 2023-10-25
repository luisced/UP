#pragma once
#include <iostream>
#include <string>
using namespace std;

struct Bodega
{
	string Articulo;
	Bodega *anterior;
};

struct Empresa
{
	string Empleado;
	Empresa *anterior;
};

class PilaArticulos
{
public:
	PilaArticulos();
	void InsertarArt(string);
	void MostrarArt();

private:
	Bodega *tope, *nodo, *extraido;
};

class PilaEmpleados
{
public:
	PilaEmpleados();
	void InsertarEmp(string);
	void MostrarEmp();

private:
	Empresa *tope, *nodo, *extraido;
};

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
	cout << "\nPILA ARTICULOS: \n"
		 << endl;
	nodo = tope;

	if (tope == NULL)
		cout << "\t"
			 << "Pila vac�a" << endl;

	while (nodo != NULL)
	{
		cout << nodo->Articulo << "\t" << endl;
		if (nodo == tope)
			cout << "\t"
				 << "Tope" << endl;
		nodo = nodo->anterior;
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