#include <iostream>
#include <string>
using namespace std;

struct Bodega
{
	string Articulo;
	Bodega *anterior;
	Bodega *siguiente;
};

struct Empresa
{
	string Empleado;
	Empresa *anterior;
	Empresa *siguiente;
};

struct Asignacion
{
	string Empleado;
	string Articulo;
	Asignacion *siguiente;
};

class PilaArticulos
{
public:
	PilaArticulos() : tope(nullptr) {}
	void InsertarArt(string nuevo);
	string ExtraerArt();
	void MostrarArt();

private:
	Bodega *tope;
};

class PilaEmpleados
{
public:
	PilaEmpleados() : tope(nullptr) {}
	void InsertarEmp(string nuevo);
	string ExtraerEmp();
	void MostrarEmp();

private:
	Empresa *tope;
};

class ListaAsignaciones
{
public:
	ListaAsignaciones() : inicio(nullptr) {}
	void InsertarAsignacion(string empleado, string articulo);
	void MostrarAsignaciones();
	void MostrarArticulosPorEmpleado(string empleado);

private:
	Asignacion *inicio;
};

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

void ListaAsignaciones::MostrarArticulosPorEmpleado(string empleadoBuscado)
{
	Asignacion *temp = inicio;
	bool empleadoEncontrado = false;

	while (temp)
	{
		if (temp->Empleado == empleadoBuscado)
		{
			cout << "Empleado: " << temp->Empleado << " - Articulo: " << temp->Articulo << endl;
			empleadoEncontrado = true;
		}
		temp = temp->siguiente;
	}

	if (!empleadoEncontrado)
	{
		cout << "El empleado " << empleadoBuscado << " no tiene asignaciones." << endl;
	}
}
