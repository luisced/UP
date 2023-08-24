#include "robot.h"
#include "laberynth.h"
#include "string"

string asciiArt =
    "\x1B[36m   _____                           _________      .__                     \n"
    "  /     \\ _____  ________ ____    /   _____/ ____ |  |___  __ ___________ \n"
    " /  \\ /  \\\\__  \\ \\___   _/ __ \\   \\_____  \\ /  _ \\|  |\\  \\/ _/ __ \\_  __ \\\n"
    "/    Y    \\/ __ \\_/    /\\  ___/   /        (  <_> |  |_\\   /\\  ___/|  | \\/\n"
    "\\____|__  (____  /_____ \\\\___  > /_______  /\\____/|____/\\_/  \\___  |__|   \n"
    "        \\/     \\/      \\/    \\/          \\/                      \\/        \x1B[0m\n";

// Main menu of the program
string ascii_menu =
    "\x1B[36m╔════════════════╗\n"
    "║ O P T I O N S  ║\n"
    "╠════════════════╣\n"
    "║ 1. E A S Y     ║\n"
    "║ 2. M E D I U M ║\n"
    "║ 3. H A R D     ║\n"
    "║ 4. C U S T O M ║\n"
    "║ 5 E X I T      ║\n"
    "╚════════════════╝\x1B[0m\n";

void menu()
{
    cout << asciiArt << endl;
    cout << ascii_menu << endl;

    int option;
    cin >> option;

    //
}