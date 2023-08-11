// Crea un programa que genere una sopa de letras en pantalla, con 10 filas, 10 columnas,
// y 8 palabras ocultas de forma aleatoria. El usuario podrá seleccionar entre 3 temas
// distintos de palabras ocultas. La sopa de letras resultante, se guardará en un archivo txt
// Las palabras ocultas pueden ir de izquierda a derecha, derecha a izquierda, arriba a
// abajo, y de abajo a arriba.
using System;
using System.IO;
using System.Text;
SopaDeLetras();
static void SopaDeLetras()
{
    int filas = 10;
    int columnas = 10;
    string[] palabras = new string[8];
    // Seleccionar tema
    Console.WriteLine("Selecciona un tema de palabras ocultas:");
    Console.WriteLine("1. Animales\n2. Frutas\n3. Paises");
    int tema = int.Parse(Console.ReadLine());
    switch (tema)
    {
        case 1:
            palabras = new string[] { "perro", "gato", "conejo", "tortuga", "pato", "vaca", "caballo", "oveja" };
            break;
        case 2:
            palabras = new string[] { "manzana", "pera", "uva", "sandia", "melon", "platano", "naranja", "kiwi" };
            break;
        case 3:
            palabras = new string[] { "mexico", "españa", "francia", "italia", "alemania", "portugal", "japon", "china" };
            break;
        default:
            Console.WriteLine("Opcion no valida");
            break;
    }
    // Generar sopa de letras

    Console.WriteLine(" ");
    string[,] sopa = new string[filas, columnas]; // Este es el arreglo bidimensional que contendrá la sopa de letras con 10 filas y 10 columnas
    Random rnd = new Random(); // Se crea un objeto de la clase Random para generar números aleatorios
    for (int i = 0; i < filas; i++) // Se recorre cada fila
    {
        for (int j = 0; j < columnas; j++) // Después se recorre cada columna
        {
            sopa[i, j] = ((char)rnd.Next(65, 91)).ToString(); // Al arreglo bidimensional se le asigna un valor aleatorio entre A y Z (ASCII 65 y 91)
        }
    }
    for (int i = 0; i < 8; i++) // Este for recorre cada palabra del arreglo de palabras
    {
        int fila = rnd.Next(0, filas); // Se genera un número aleatorio entre 0 y 10 para la fila
        int columna = rnd.Next(0, columnas); // Se genera un número aleatorio entre 0 y 10 para la columna
        int direccion = rnd.Next(0, 4); // Se genera un número aleatorio entre 0 y 4 para la dirección, 0 = izquierda a derecha, 1 = derecha a izquierda, 2 = arriba a abajo, 3 = abajo a arriba
        switch (direccion)
        {

            case 0: // Izquierda a derecha
                if (columna + palabras[i].Length < columnas) // si la palabra cabe en la sopa de letras
                {
                    for (int j = 0; j < palabras[i].Length; j++) // Se recorre cada caracter de la palabra
                    {
                        sopa[fila, columna + j] = palabras[i][j].ToString(); // Se asigna el caracter de la palabra a la sopa de letras
                    }
                }
                else // Si la palabra no cabe en la sopa de letras
                {
                    i--; // Se decrementa i para que se vuelva a generar una palabra
                }
                break;
            case 1: // Derecha a izquierda
                if (columna - palabras[i].Length >= 0) // si la palabra cabe en la sopa de letras
                {
                    for (int j = 0; j < palabras[i].Length; j++) // Se recorre cada caracter de la palabra
                    {
                        sopa[fila, columna - j] = palabras[i][j].ToString(); // Se asigna el caracter de la palabra a la sopa de letras
                    }
                }
                else // Si la palabra no cabe en la sopa de letras
                {
                    i--; // Se decrementa i para que se vuelva a generar una palabra
                }
                break;
            case 2: // Arriba a abajo
                if (fila + palabras[i].Length < filas)
                {
                    for (int j = 0; j < palabras[i].Length; j++)
                    {
                        sopa[fila + j, columna] = palabras[i][j].ToString(); // Se asigna el caracter de la palabra a la sopa de letras, en esta caso es + j en la fila para que vaya de arriba a abajo
                    }
                }
                else
                {
                    i--;
                }
                break;
            case 3: // Abajo a arriba
                if (fila - palabras[i].Length >= 0) // Se verifica que la palabra que se va a generar no se salga de la sopa de letras
                {
                    for (int j = 0; j < palabras[i].Length; j++) // Se recorre cada caracter de la palabra
                    {
                        sopa[fila - j, columna] = palabras[i][j].ToString();
                    }
                }
                else
                {
                    i--;
                }
                break;
        }
    }
    for (int i = 0; i < filas; i++) // Finalmente se imprime cada fila de la sopa de letras
    {
        for (int j = 0; j < columnas; j++) // Se imprime cada columna de la sopa de letras
        {
            Console.Write(sopa[i, j] + " ");
        }
        Console.WriteLine(" ");
    }
    Console.WriteLine(" ");
    Console.WriteLine("¿Desea guardar la sopa de letras en un archivo txt? (S/N)");
    string respuesta = Console.ReadLine();
    if (respuesta.ToLower() == "s")
    {
        // Guardar sopa de letras
        string filename = "SopaDeLetras.txt";
        using (FileStream fs = File.Create(filename))
        {
            for (int i = 0; i < filas; i++) // Finalmente se imprime cada fila de la sopa de letras
            {
                for (int j = 0; j < columnas; j++) // Se imprime cada columna de la sopa de letras
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(sopa[i, j] + " ");
                    fs.Write(info, 0, info.Length);
                }
                byte[] info2 = new UTF8Encoding(true).GetBytes(Environment.NewLine);
                fs.Write(info2, 0, info2.Length);
            }
        }
        Console.WriteLine(" ");
        Console.WriteLine("Sopa de letras guardada en el archivo SopaDeLetras.txt");

    }
    else
    {
        Console.WriteLine("Sopa de letras no guardada");
    }
    Console.WriteLine("Presione cualquier tecla para salir");
    Console.ReadKey();
}