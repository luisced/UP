using System;

public class Program {
    public static void Main(string[] args) {
        // Lee el numero de conjuntos de datos
        int datasetCount = int.Parse(Console.ReadLine());

        // Itera sobre cada conjunto de datos
        for (int i = 1; i <= datasetCount; i++) {
            // Lee el numero de datos y el numero N
            string[] datasetInput = Console.ReadLine().Split(); // Split() divide la cadena en un array de cadenas
            int datasetNumber = int.Parse(datasetInput[0]); // Parse() convierte una cadena en un entero
            int n = int.Parse(datasetInput[1]); // Parse() convierte el segundo elemento del array en un entero

            // Calcula la suma de los primeros N enteros
            int sum1 = n * (n + 1) / 2;

            // Calcula la suma de los primeros N cuadrados
            int sum2 = n * n;

            // Calcula la suma de los primeros N cubos
            // el cual es igual a la suma de los primeros N enteros
            int sum3 = n * (n + 1);

            // Imprime el resultado
            Console.WriteLine($"{datasetNumber} {sum1} {sum2} {sum3}");
        }
    }
}

/*
Inicio del programa
Leer el número de conjuntos de datos
Para cada conjunto de datos
Leer el número de datos y el número N
Calcular la suma de los primeros N enteros
Calcular la suma de los primeros N cuadrados
Calcular la suma de los primeros N cubos
Imprimir el resultado
Fin del bucle Para
Fin del programa
*/