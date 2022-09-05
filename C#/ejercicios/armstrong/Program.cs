public class armstrongnumber
{
    static void Main(string[] args)
    {
        // obtain the numbers between an armostrong number
        int num, temp, temp1, sum = 0, digitos = 0;
        Console.Write("Enter the number: ");
        num = Convert.ToInt32(Console.ReadLine());
        temp = num;
        Console.WriteLine($"Los suma de los números de {num} son: ");

        // Se obtiene la cantidad de digitos del número dividido entre 10 hasta que sea menor a 1
        for (temp1 = num; temp1 > 0; temp1 /= 10, digitos++) ;

        // Se obtiene la suma de los números elevados a la cantidad de digitos del número mientras sea mayor a 0
        while (temp > 0)
        {
            // Se obtiene el residuo de la división entre 10
            temp1 = temp % 10;
            // Se eleva el residuo a la cantidad de digitos del número, se suma a la variable sum y se castea a entero 
            sum += (int)Math.Pow(temp1, digitos);
            // Se divide el número entre 10
            temp /= 10;
            // Se imprime el resultado de la suma
            Console.WriteLine($"+ {temp1}^{digitos}");

        }
        // Si el número es igual a la suma de los números elevados a la cantidad de digitos del número entonces es un número de Armstrong
        Console.WriteLine((sum == num) ? $"\n{num} es un número armstrong y están elevados a la {digitos} potencia" : $"\n{num} no es un número armstrong");


    }
}