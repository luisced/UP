namespace Secretmessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string ruta = "/home/luisced/Code/Escuela/UP/C#/ejercicios/secret_message/Mensaje_secreto_1", texto, archivo_nombre = "", margen1 = "╔═══════════════════════════════════════╗", margen2 = "╚═══════════════════════════════════════╝", margen3 = "║═══════════════════════════════════════║", abc = "abcdefghijklmnopqrstuvwxyz", mensaje = "";
            string[] archivos = Directory.GetFiles(ruta);
            string[] archivos_name = Directory.GetFiles(ruta, "*.txt");

            Array.Sort(archivos_name);
            archivos_name.ToList().ForEach(i => Console.WriteLine(i));
            foreach (string archivo in archivos)
            {
                archivo_nombre = Path.GetFileName(archivo);

                texto = File.ReadAllText(archivo);
                // encuentra una letra en cada archivo
                for (int i = 0; i < texto.Length; i++)
                {
                    if (abc.Contains(texto[i]))
                    {
                        mensaje += texto[i];
                        // Console.WriteLine($"El archivo {archivo_nombre} contiene la letra {texto[i]}");
                        break;
                    }
                    // ordenar la lista de archivos por nombre
                }
            }
            Console.WriteLine($"{margen1}\n║  Bienvenido al programa de mensajes   ║ \n{margen3}\n║  1. Enviar mensaje                    ║\n║  2. Leer mensaje                      ║\n║  3. Salir                             ║\n{margen2}");

        }
    }
}