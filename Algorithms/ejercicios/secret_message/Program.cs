// Se crean las variables para almacenar el texto dentro de cada archivo, el nombre del archivo y el resultado de la concatencación de cada caracter dentro de los archivos
string texto = "", archivo_nombre = "", mensaje = "";
// Se crea un arreglo de tipo string para almacenar los archivos que se encuentran dentro de la carpeta mostrada en la ruta
string[] archivos = Directory.GetFiles("/home/luisced/Code/Escuela/UP/C#/ejercicios/secret_message/Mensaje_secreto_1");
// Se itera sobre cada archivo dentro del arreglo de archivos y se ordena de forma ascendente 1,2,3... obteniendo el substring del nombre del archivo para obtener el nombre del archivo empezando desde atrás
Array.Sort(archivos, (x, y) => x.Substring(x.Length - 6, 2).CompareTo(y.Substring(y.Length - 6, 2)));

// 
foreach (string archivo in archivos)
{
    // Se lee el archivo y se almacena en la variable texto y se elimina el guión bajo del nombre del archivo
    archivo_nombre = archivo.Substring(archivo.Length - 6).Replace("_", " ");
    // Se almacena el texto del archivo en la variable texto
    texto = File.ReadAllText(archivo);



    // Se itera sobre cada caracter dentro del texto del archivo
    foreach (char letra in texto)
    {
        // Se verifica si el caracter se encuentra una sola vez dentro del texto del archivo
        if (texto.IndexOf(letra) == texto.LastIndexOf(letra))
        {
            // si es así se concatena el caracter a la variable mensaje
            mensaje += letra;
        }
    }
    // mensaje += texto.Where((letra, index) => texto.IndexOf(letra) == texto.LastIndexOf(letra)).Select(letra => letra.ToString()).Aggregate((a, b) => a + b);
    // --> hace lo mismo que el foreach pero en una sola linea
}
// Se imprime el mensaje
Console.WriteLine(mensaje);

// string texto = "", archivo_nombre = "", mensaje = ""; string[] archivos = Directory.GetFiles("/home/luisced/Code/Escuela/UP/C#/ejercicios/secret_message/Mensaje_secreto_1"); Array.Sort(archivos, (x, y) => x.Substring(x.Length - 6, 2).CompareTo(y.Substring(y.Length - 6, 2))); foreach (string archivo in archivos) { archivo_nombre = archivo.Substring(archivo.Length - 6).Replace("_", " "); texto = File.ReadAllText(archivo); mensaje += texto.Where((letra, index) => texto.IndexOf(letra) == texto.LastIndexOf(letra)).Select(letra => letra.ToString()).Aggregate((a, b) => a + b); }; Console.WriteLine(mensaje);
// --> hace lo mismo que todo el código anterior pero en una sola linea