// Cifrado Cesar
string abc = "abcdefghijklmnopqrstuvwxyz0123456789";
int llave;
string mensaje;
string mensajeCIF = "";

// Pedir info al usuario
Console.WriteLine("Hello, introduce tu mensaje de texto");
mensaje = Console.ReadLine().ToLower();
Console.WriteLine("Ahora introduce tu llave con un valor de 0 a 26");

// Hacer que el usuario introduzca un valor adecuado
while (int.TryParse(Console.ReadLine(), out llave) == false)
{

    Console.WriteLine("Por favor ingresa un valor adecuado...");
    Console.WriteLine("introduce tu llave con un valor de 0 a 26: ");

}
Console.WriteLine();

for (int i = 0; i < mensaje.Length; i++)
{
    int posicion = abc.IndexOf(mensaje[i]);
    int posicionEncriptada = (llave + posicion) % abc.Length; //Hace un ciclo para repetir el abecedario
    mensajeCIF += abc[posicionEncriptada];
}


Console.WriteLine("Este es tu mensaje cifrado: " + mensajeCIF);