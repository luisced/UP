namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 5, 3, 2, 4, 1 };
            Console.WriteLine("Before sorting:");
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            SelectionSort(array);
            Console.WriteLine("\nAfter sorting:");
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
        }
        static void SelectionSort(int[] arr)
        {
            int n = arr.Length; // n es el número de elementos del arreglo
            for (int i = 0; i < n - 1; i++)  // El primer ciclo recorre el arreglo de izquierda a derecha
            {
                int min_idx = i; // El índice del elemento más pequeño se inicializa con el índice del primer elemento
                for (int j = i + 1; j < n; j++) // El segundo ciclo recorre el arreglo de izquierda a derecha desde el segundo elemento 
                    if (arr[j] < arr[min_idx]) // Si el elemento actual es menor que el elemento más pequeño 
                        min_idx = j; // Actualiza el índice del elemento más pequeño al índice del elemento actual
                int temp = arr[min_idx];
                arr[min_idx] = arr[i]; // Intercambia el primer elemento con el elemento más pequeño
                arr[i] = temp; // Intercambia el elemento más pequeño con el primer elemento
            }
        }
    }
}