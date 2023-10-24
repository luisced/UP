#include <vector>
#include <queue>
#include <algorithm>
#include <iostream>
#include <thread>
#include <chrono>

using namespace std;

class Robot
{
private:
    static const vector<pair<int, int>> DIRECTIONS;

    static void clearScreen()
    {
#ifdef _WIN32
        system("cls");
#else
        system("clear");
#endif
    }

    void displayMaze(int **maze, int width, int height, int x, int y) const
    {
        clearScreen();
        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                if (i == x && j == y)
                {
                    cout << "\033[1;31m"
                         << "◍"
                         << "\033[0m"; // Red robot
                }
                else
                {
                    cout << (maze[i][j] == 0 ? "■" : " "); // Wall or space
                }
            }
            cout << '\n';
        }
        this_thread::sleep_for(chrono::milliseconds(25));
    }

public:
    vector<pair<int, int>> solve(int **maze, int width, int height, bool shouldDisplayMaze = false)
    {
        vector<vector<bool>> visited(width, vector<bool>(height, false));

        // visited: mantiene el track de que nodos ya fueron visitados

        vector<vector<pair<int, int>>> previous_position(width, vector<pair<int, int>>(height, {-1, -1}));

        // previous_position: mantiene el track de la posicion anterior de cada nodo

        queue<pair<int, int>> q;

        pair<int, int> start = {0, 0};
        pair<int, int> end = {width - 1, height - 1};

        q.push(start);
        visited[start.first][start.second] = true;

        // Se crea una pila con la posicion anterior de cada nodo
        // para poder reconstruir el camino al final
        // La posicion anterior del nodo inicial es -1, -1
        // Start: {0, 0}, desde donde empieza el robot
        // End: {width - 1, height - 1}, donde termina el robot

        while (!q.empty()) // Mientras la cola no este vacia
        {
            pair<int, int> current = q.front();
            int x = current.first;
            int y = current.second;
            q.pop();

            // Si la posicion actual no es igual a la posicion final, se saca un nodo del frente de la pila y se
            // obtienen las coordenadas de la posicion actual

            if (current == end)
                break;

            // Si la posicion en el nodo dentro de la pila es igual a la posicion final, se termina el ciclo

            for (size_t i = 0; i < DIRECTIONS.size(); i++) // Se recorren las direcciones posibles desde la posicion actual
            {
                int newX = x + DIRECTIONS[i].first;
                int newY = y + DIRECTIONS[i].second;
                if (newX >= 0 && newX < width && newY >= 0 && newY < height &&
                    !visited[newX][newY] && maze[newX][newY] == 1)
                {
                    q.push({newX, newY});
                    visited[newX][newY] = true;
                    previous_position[newX][newY] = current;
                }

                // Esta condicional dice lo siguiente:
                // Si la nueva posicion en x es mayor o igual a 0 y menor que el ancho del laberinto
                // y la nueva posicion en y es mayor o igual a 0 y menor que el alto del laberinto
                // y no se ha visitado la nueva posicion y la nueva posicion es un espacio (1) o sea no es una pared (0)
                // entonces se agrega la nueva posicion a la pila, se marca como visitada y se guarda la posicion anterior
            }
            // Uncomment the below line to display maze while solving
            // bool shouldDisplayMaze = true; // Set this to false if you don't want to display the maze

            if (shouldDisplayMaze)
                displayMaze(maze, width, height, x, y);
        }

        vector<pair<int, int>> path; // Almacena un vector de pares de enteros que representan el camino
        pair<int, int> current_position = end;
        while (current_position != make_pair(-1, -1)) // Mientras la posicion actual no sea igual a -1, -1, o sea, mientras no se llegue a la posicion inicial
        {
            // Se agrega la posicion actual al vector de camino y se actualiza la posicion actual a la posicion anterior
            path.push_back(current_position);
            current_position = previous_position[current_position.first][current_position.second];
        }
        // Se invierte el vector para que el camino vaya desde la posicion inicial hasta la posicion final
        reverse(path.begin(), path.end());

        // Si el primer elemento del vector es igual a la posicion inicial, se regresa el vector
        return (path[0] == start) ? path : vector<pair<int, int>>{};
    }
};
//                                                  UP      DOWN    LEFT    RIGHT
const vector<pair<int, int>> Robot::DIRECTIONS = {{-1, 0}, {1, 0}, {0, -1}, {0, 1}};
