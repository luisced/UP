

using System;

class Program {
    

    static int FetchMovie(string[] peliculas, string nombre) {
        for (int i = 0; i < peliculas.Length; i++) {
            if (peliculas[i] == nombre) {
                return i;
            }
        }
        return -1;
    }

// Función para contar el número de consonantes en una cadena
static int noConsonantes(string cadena)
{
    int numConsonantes = 0;

    for (int i = 0; i < cadena.Length; i++)
    {
        char letra = char.ToLower(cadena[i]);

        if (letra >= 'b' && letra <= 'z' && letra != 'e' && letra != 'i' && letra != 'o' && letra != 'u')
        {
            numConsonantes++;
        }
    }

    return numConsonantes;
}

// Función para buscar las películas con el mayor número de consonantes
static void MaxConsonantes(string[] peliculas)
{
    int maxConsonantes = 0;

    // Primero encontramos el número máximo de consonantes en una película
    for (int i = 0; i < peliculas.Length; i++)
    {
        int numConsonantes = noConsonantes(peliculas[i]);

        if (numConsonantes > maxConsonantes)
        {
            maxConsonantes = numConsonantes;
        }
    }

    // Después imprimimos todas las películas que tienen el número máximo de consonantes
    Console.WriteLine("Las películas con un mayor número de constantes son:");

    for (int i = 0; i < peliculas.Length; i++)
    {
        int numConsonantes = noConsonantes(peliculas[i]);

        if (numConsonantes == maxConsonantes)
        {
            Console.WriteLine("{0} con {1} ocurrencias de consonantes.", peliculas[i], maxConsonantes);
        }
    }

}

string InvertirTresPrimeras(string cadena)
{
    if (cadena.Length < 3)
    {
        return cadena;
    }

    char[] caracteres = cadena.ToCharArray();

    char temp = caracteres[0];
    caracteres[0] = caracteres[2];
    caracteres[2] = temp;

    return new string(caracteres);
}



static void PeliculaInvertida(string[] peliculas)
{
    bool encontrado = false;
    string resultado = "No existe una película con esta condición";

    for (int i = 0; i < peliculas.Length; i++)
    {
        if (peliculas[i].Length < 4) continue;

        char[] letras = peliculas[i].ToCharArray();
        char temp = letras[0];
        letras[0] = letras[2];
        letras[2] = temp;

        string peliculaInvertida = new string(letras);

        if (peliculaInvertida.Equals(peliculas[i]))
        {
            resultado = peliculas[i];
            encontrado = true;
            break;
        }
    }

    Console.WriteLine("La primera película que si invertimos sus tres primeras letras no afecta el nombre es: " + resultado);
}

static void Main(string[] args) {
        Console.Write("Digite el número de películas a ingresar: ");
        int numPel = int.Parse(Console.ReadLine());
        
        string[] peliculas = new string[numPel];
        for (int i = 0; i < numPel; i++) {
            Console.Write("Siguiente película: ");
            peliculas[i] = Console.ReadLine().ToLower();
        }

        Console.Write("Elige una opción (1, 2, 3): ");
        int opcion = int.Parse(Console.ReadLine());

        switch(opcion){
            case 1:
                Console.Write("Ingresa el nombre de la película a buscar: ");
                string nombre = Console.ReadLine();
                int posicion = FetchMovie(peliculas, nombre);
                if (posicion == -1) {
                    Console.WriteLine("La película no fue encontrada.");
                } else {
                    Console.WriteLine($"La película {nombre} se encuentra en la posición {posicion + 1}.");
                }
                break;

            case 2:
                MaxConsonantes(peliculas);
                break;

            case 3:
                PeliculaInvertida(peliculas);
                break;
            default:
                Console.WriteLine("Opción inválida.");
                    break;
            
            
        }

       
    }

}

