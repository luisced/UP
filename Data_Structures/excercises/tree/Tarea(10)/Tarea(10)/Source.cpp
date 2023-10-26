#include "Tarea10.h"

int main() 
{
    ListaCircular lista;
    int opc;
    string nombre, nuevo, despuesDe;

    do 
    {
        cout << "\n 1 Insertar Inicio   2 Insertar en Medio   3 Insertar Final   4 Contar Nodos   5 Extraer Nodos Impares   6 Mostrar   7 Salir: ";
        cin >> opc;

        switch(opc)
        {
        case 1:
            cout << "Ingrese un nombre: ";
            cin >> nombre;
            lista.InsertarInicio(nombre);
            cout << "Nombre insertado con éxito." << endl;
            break;
        case 2:
            cout << "Ingrese un nombre: ";
            cin >> nuevo;
            cout << "Después de qué nombre desea insertarlo: ";
            cin >> despuesDe;
            if (lista.InsertarInter(nuevo, despuesDe)) 
            {
                cout << "Nombre insertado en medio con éxito." << endl;
            }
            break;
        case 3:
            cout << "Ingrese un nombre: ";
            cin >> nombre;
            lista.InsertarFinal(nombre);
            cout << "Nombre insertado al final con éxito." << endl;
            break;
        case 4:
            cout << "La lista tiene " << lista.ContarNodos() << " nombres." << endl;
            break;
        case 5:
            lista.ExtraerNodosImpares();
            break;
        case 6:
            lista.Mostrar();
            break;
        case 7:
            break;
        default:
            cout << "Opción inválida. Intente de nuevo." << endl;
            break;
        }
    } while (opc != 5);

    return 0;
}