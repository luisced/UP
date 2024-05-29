#include <iostream>
#include <vector>
#include <string>
#include <fstream>

class Jugador
{
public:
    std::string nombre;
    int numero_playera;
    std::string posicion;

    Jugador(std::string n, int num, std::string pos) : nombre(n), numero_playera(num), posicion(pos) {}
};

class Equipo
{
public:
    std::string nombre;
    std::vector<Jugador> jugadores;

    Equipo(std::string n) : nombre(n) {}

    void agregar_jugador(Jugador jugador)
    {
        for (auto &j : jugadores)
        {
            if (j.numero_playera == jugador.numero_playera)
            {
                std::cout << "Error: El número de playera ya está en uso. Por favor, elija otro número.\n";
                return;
            }
        }
        jugadores.push_back(jugador);
        std::cout << "Jugador Guardado.\n";
    }

    void mostrar_jugadores()
    {
        std::cout << "Jugadores del equipo " << nombre << ":\n";
        for (auto &j : jugadores)
        {
            std::cout << j.nombre << " - " << j.numero_playera << " - " << j.posicion << "\n";
        }
    }

    void descargar_lista_jugadores()
    {
        std::ofstream file(nombre + "_jugadores.csv");
        for (auto &j : jugadores)
        {
            file << j.nombre << "," << j.numero_playera << "," << j.posicion << "\n";
        }
        file.close();
        std::cout << "Lista de jugadores descargada.\n";
    }
};

int main()
{
    std::vector<Equipo> equipos;
    int opcion_principal = 0;

    while (opcion_principal != 5)
    {
        std::cout << "Menu principal:\n";
        std::cout << "1. Mostrar equipos\n";
        std::cout << "2. Crear equipo\n";
        std::cout << "3. Agregar jugador a equipo\n";
        std::cout << "4. Descargar lista de jugadores\n";
        std::cout << "5. Salir\n";
        std::cout << "Seleccione una opción: ";
        std::cin >> opcion_principal;

        if (opcion_principal == 1)
        {
            std::cout << "Equipos disponibles:\n";
            for (int i = 0; i < equipos.size(); ++i)
            {
                std::cout << i + 1 << ". " << equipos[i].nombre << ":\n";
                equipos[i].mostrar_jugadores();
            }
        }
        else if (opcion_principal == 2)
        {
            std::string nombre_equipo;
            std::cout << "Ingrese el nombre del nuevo equipo: ";
            std::cin >> nombre_equipo;
            equipos.push_back(Equipo(nombre_equipo));
            std::cout << "Equipo creado.\n";
        }
        else if (opcion_principal == 3)
        {
            int equipo_seleccionado;
            std::cout << "Seleccione el número del equipo: ";
            std::cin >> equipo_seleccionado;
            equipo_seleccionado -= 1;

            if (equipo_seleccionado >= 0 && equipo_seleccionado < equipos.size())
            {
                std::string nombre_jugador, posicion_jugador;
                int numero_playera;

                std::cout << "Ingrese el nombre del jugador: ";
                std::cin >> nombre_jugador;
                std::cout << "Ingrese el número de playera: ";
                std::cin >> numero_playera;
                std::cout << "Ingrese la posición del jugador: ";
                std::cin >> posicion_jugador;

                Jugador nuevo_jugador(nombre_jugador, numero_playera, posicion_jugador);
                equipos[equipo_seleccionado].agregar_jugador(nuevo_jugador);
            }
            else
            {
                std::cout << "Equipo no válido.\n";
            }
        }
        else if (opcion_principal == 4)
        {
            int equipo_seleccionado;
            std::cout << "Seleccione el número del equipo: ";
            std::cin >> equipo_seleccionado;
            equipo_seleccionado -= 1;

            if (equipo_seleccionado >= 0 && equipo_seleccionado < equipos.size())
            {
                equipos[equipo_seleccionado].descargar_lista_jugadores();
            }
            else
            {
                std::cout << "Equipo no válido.\n";
            }
        }
        else if (opcion_principal == 5)
        {
            std::cout << "Saliendo del programa...\n";
        }
        else
        {
            std::cout << "Opción no válida.\n";
        }
    }

    return 0;
}
