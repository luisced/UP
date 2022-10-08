string texto = "", archivo_nombre = "", mensaje = "";
string[] archivos = Directory.GetFiles("/home/luisced/Code/Escuela/UP/C#/ejercicios/secret_message/Mensaje_secreto_1");
Array.Sort(archivos, (x, y) => x.Substring(x.Length - 6, 2).CompareTo(y.Substring(y.Length - 6, 2)));

foreach (string archivo in archivos)
{
    archivo_nombre = archivo.Substring(archivo.Length - 6).Replace("_", " ");
    texto = File.ReadAllText(archivo);


    // foreach (char letra in texto)
    // {
    //     mensaje += texto.IndexOf(letra) == texto.LastIndexOf(letra) ? letra.ToString() : "";
    // }
    // one line solution
    mensaje += texto.Where((letra, index) => texto.IndexOf(letra) == texto.LastIndexOf(letra)).Select(letra => letra.ToString()).Aggregate((a, b) => a + b);
}
Console.WriteLine(mensaje);
