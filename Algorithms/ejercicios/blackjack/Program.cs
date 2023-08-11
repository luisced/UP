// BLACJACK

// Función para mostrar el nombre del juego
static void Mensaje()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("*************");
    Console.WriteLine("*           *");
    Console.WriteLine("* BLACKJACK *");
    Console.WriteLine("*           *");
    Console.WriteLine("*************");
    Console.ResetColor();
    Console.ReadKey();
    Console.Clear();
}

// Función para mostrar las instrucciones del juego
static void Mensaje2()
{
    Console.WriteLine("Bienvenido a este juego de Blacjack, se juega de la siguiente manera:");
    Console.WriteLine("\n1.- Aparecerán 2 cartas en tu pantalla.");
    Console.WriteLine("\n2.- Una estará oculta y la otra estará visible.");
    Console.WriteLine("\n3.- Deberás presionar enter para revelar la carta oculta y se sumarán los números de ambas cartas.");
    Console.WriteLine("\n4.- Deberás indicar cuánto quieres apostar.");
    Console.WriteLine("\n5.- El objetivo es que los números sumen 21.");
    Console.WriteLine("\n6.- En el caso de que tus cartas sumen 21, se duplicará tu apuesta como premio.");
    Console.WriteLine("\n7.- En el caso de que tus cartas sumen menos de 21 puedes elegir que te den otra y sumar esa nueva carta.");
    Console.WriteLine("\n8.- Si sigues sin sumar 21 puedes pedir otra carta. Sólo se te darán tres cartas extras.");
    Console.WriteLine("\n9.- Si las cartas suman más de 21, perderás de manera inmediata.");
    Console.WriteLine("\n10.- Si deseas no agregar más cartas y la suma aún no es de 21, se te dará la mitad del dinero que apostaste como premio.");
    Console.WriteLine("\n11.- Al final de cada ronda se te dirá cuánto dinero tienes y si quieres retirarte del juego.");
    Console.WriteLine("\n12.- Puedes seguir jugando el tiempo que quieras, pero si ya no tienes dinero, no puedes seguir apostando.");
    Console.WriteLine("\nPresiona Enter para iniciar");
    Console.ResetColor();
    Console.ReadKey();
    Console.Clear();
}

// Función para crear un número aleatorio para las cartas
static int Num_aleatorio(int min, int max)
{
    // Se crea un número aleatorio con el generador random
    Random Generador = new Random();
    // El número estará dentro del rango mínimo y máximo
    return Generador.Next(min, max);
}

// Función para mostrar las cartas
static void Carta(int numero, int coord_x, int coord_y, bool visible)
{
    for (int i = 0; i < 5; i++)
    {
        if (visible == true)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.SetCursorPosition(coord_x, coord_y);
        coord_y++;
        if (i == 0)
        {
            Console.WriteLine("╔═══╗");
        }
        else if (i == 1)
        {
            if (visible == true)
            {
                Console.WriteLine("║♦  ║");

            }
            else
            {
                Console.WriteLine("║   ║");
            }
        }
        else if (i == 2)
        {
            if (visible == true)
            {
                Console.WriteLine("║ " + numero + " ║");
            }
            else
            {
                Console.WriteLine("║   ║");
            }
        }
        else if (i == 3)
        {
            if (visible == true)
            {
                Console.WriteLine("║  ♦║");
            }
            else
            {
                Console.WriteLine("║   ║");
            }
        }
        else if (i == 4)
        {
            Console.WriteLine("╚═══╝");
        }
    }
    Console.ResetColor();
}

// Función para castear números sin que arroje error por si el usuario se equivoca
static int Casteo_entero(string Mensaje)
{
    int resultado = 0;
    Console.WriteLine(Mensaje);
    while (int.TryParse(Console.ReadLine(), out resultado) == false || resultado  <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error, el valor ingresado no es un número entero. Vuelva a intentarlo.");
        Console.ResetColor();
        Console.WriteLine(Mensaje);
    }
    return resultado;
}

// Variables
// Variable para llevar cuenta del dinero apostado
int dinero;
// Variables para las cartas iniciales
int carta_oculta;
int carta_inicial;
int baraja;
// Variables para las cartas extras
int carta_uno; 
int carta_dos;
int carta_tres;
// Variable para hacer la suma de las cartas
int sumatoria;
// Variable para que el usuario escoga si le dan más cartas o deja el juego así
string resp_usuario;

// Programa
// Se muestran los mensajes iniciales del juego
Mensaje();
Mensaje2();
Console.Clear();

// Se le pregunta al usuario cuánto dinero quiere apostar
dinero = Casteo_entero("¿Cuánto dinero deseas apostar?");
Console.Clear();

// Se generan los números aleatorios de las cartas
carta_oculta = Num_aleatorio(1, 13);
carta_inicial = Num_aleatorio(1, 13);
baraja = Num_aleatorio(1, 13);
carta_uno = Num_aleatorio(1, 13);
carta_dos = Num_aleatorio(1, 13);
carta_tres = Num_aleatorio(1, 13);

// Se muestran las cartas
Carta(carta_oculta, 4, 2, true); // Carta inicial visible
Carta(carta_inicial, 12, 2, false); // Carta inicial oculta
Carta(baraja, 52, 2, false); // Baraja de cartas

// Para revelar la carta oculta
Console.WriteLine("Para ver la carta oculta presione enter: ");
Console.ReadKey();
Console.Clear();

// Mostrar las cartas dadas al jugador
Carta(carta_oculta, 4, 2, true);
Carta(carta_inicial, 12, 2, true);

// Se suma el valor de las cartas
sumatoria = carta_oculta + carta_inicial;
Console.WriteLine("\nLa sumatoria de sus cartas es de: " + sumatoria);

// Revisión de condiciones para la sumatoria de las cartas
if(sumatoria == 21) // Si la suma da 21, se duplica el dinero apostado
{
    Console.WriteLine("¡Felicidades, usted ha ganado: $" + (dinero*2) + "!");
}
else if (sumatoria >= 21) // Si la suma da más de 21, pierde su dinero
{
    Console.WriteLine("\nLo lamento, la suma de sus cartas supera 21. Ha perdido.");
    Console.WriteLine("Usted tiene ahora: $" + (dinero - dinero));
}
else if (sumatoria <= 21) // Si la suma da menos de 21, se dan dos opciones
{
    Console.WriteLine("\n\nEscriba 'sí' si desea que le den otra carta, de lo contrario presione Enter para reclamar su dinero: ");
    resp_usuario = Console.ReadLine();
    
    if (resp_usuario.ToLower() == "si") // Condición por si el usuario escoge que le den más cartas
    {
        Carta(carta_uno, 20, 2, true);
        sumatoria = sumatoria + carta_uno;
        Console.WriteLine("\nLa sumatoria de sus cartas es de: " + sumatoria);
    }
    else // Si escoge dejar el juego, se le da la mitad de lo que apostó
    {
        Console.Clear();
        Console.WriteLine("¡Usted ha ganado: $" + (dinero / 2) + "!");
    }
}

Console.ReadKey();
Console.Clear();