#include "Clases.h"

int main()
{
	setlocale(LC_ALL, "");
	PilaArticulos art;
	PilaEmpleados emp;

	int opc;
	string retorno, extraida, articulo, empleado;

	do
	{
		cout << "\n1. Insertar Articulo \n2. Insertar Empleado \n3. Extraer \n4. Mostrar Empleados \n5. Mostrar Art�culos \n6. Salir \nElija una opci�n: ";
		cin >> opc;
		switch (opc)
		{
		case 1:
			cout << "\nIngrese nombre de art�culo: ";
			cin >> articulo;
			art.InsertarArt(articulo);
			cout << "Se insert� correctamente en la bodega" << endl;
			break;

		case 2:
			cout << "\nIngrese nombre de empleado: ";
			cin >> empleado;
			emp.InsertarEmp(empleado);
			cout << "Se insert� correctamente en la empresa" << endl;
			break;

		case 3:

			break;
		case 4:
			break;
		case 5:
			art.MostrarArt();
			break;
		case 6:
			break;
		case 7:
			cout << "--- FIN DE LA APLICACI�N ---";
			break;
		default:
			cout << "Inserte una opci�n v�lida";
			break;
		}
	} while (opc != 7);
}