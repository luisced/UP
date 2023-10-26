#include "Clases.h"
int main()
{
	setlocale(LC_ALL, "");
	PilaArticulos art;
	PilaEmpleados emp;
	ListaAsignaciones asignaciones;

	int opc;
	string articulo, empleado;

	do
	{
		cout << "\n1. Insertar Articulo \n2. Insertar Empleado \n3. Asignar Regalo \n4. Mostrar Empleados \n5. Mostrar Artículos \n6. Mostrar Asignaciones \n7. Mostrar Asignaciones de un Empleado \n8. Salir \nElija una opción: ";
		cin >> opc;
		switch (opc)
		{
		case 1:
			cout << "\nIngrese nombre de artículo: ";
			cin >> articulo;
			art.InsertarArt(articulo);
			cout << "Se insertó correctamente en la bodega" << endl;
			break;

		case 2:
			cout << "\nIngrese nombre de empleado: ";
			cin >> empleado;
			emp.InsertarEmp(empleado);
			cout << "Se insertó correctamente en la empresa" << endl;
			break;

		case 3:
			empleado = emp.ExtraerEmp();
			articulo = art.ExtraerArt();
			if (!empleado.empty() && !articulo.empty())
			{
				asignaciones.InsertarAsignacion(empleado, articulo);
				cout << "Se asignó el artículo " << articulo << " al empleado " << empleado << endl;
			}
			else
			{
				cout << "No hay empleados o artículos disponibles" << endl;
			}
			break;

		case 4:
			emp.MostrarEmp();
			break;

		case 5:
			art.MostrarArt();
			break;

		case 6:
			asignaciones.MostrarAsignaciones();
			break;

		case 7:
			cout << "Ingrese el nombre del empleado para ver sus asignaciones: ";
			cin >> empleado;
			cout << "Asignaciones para el empleado " << empleado << ":" << endl;
			asignaciones.MostrarArticulosPorEmpleado(empleado);
			break;

		case 8:
			cout << "--- FIN DE LA APLICACIÓN ---";
			break;

		default:
			cout << "Inserte una opción válida";
			break;
		}
	} while (opc != 8);

	return 0;
}
