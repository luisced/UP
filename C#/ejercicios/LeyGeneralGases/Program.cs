// Crea un programa que calcule la ley general de los gases, para cualquiera de las 3
// variables. El programa deberá ser capaz de identificar si se está calculando la presión,
// volumen, o temperatura.
double P1, P2, V1, V2, T1, T2;
Console.WriteLine("Ingrese los valores de la ley de los gases general, en caso de tener icognita, ingrese 0");
// comprobar que solo se ingrese un 0
Console.WriteLine("Ingrese el valor de la ecuacion separado por espacios");
double[] valores = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
P1 = valores[0];
V1 = valores[1];
T1 = valores[2];
P2 = valores[3];
V2 = valores[4];
T2 = valores[5];

foreach (double valor in valores)
{
    if (valor == 0)
    {
        Console.WriteLine($"El resultado para la iconita es: {LeyGeneralGases(P1, V1, T1, P2, V2, T2)}");
    }
}

static double LeyGeneralGases(double P1, double P2, double V1, double V2, double T1, double T2)
{
    // if one of the values is Null, then it is the value to calculate
    if (P1 == 0)
    {
        return (P2 * V2 * T1) / (V1 * T2);
    }
    else if (P2 == 0)
    {
        return (P1 * V1 * T2) / (V2 * T1);
    }
    else if (V1 == 0)
    {
        return (P2 * V2 * T1) / (P1 * T2);
    }
    else if (V2 == 0)
    {
        return (P1 * V1 * T2) / (P2 * T1);
    }
    else if (T1 == 0)
    {
        return (P1 * V1 * T2) / (P2 * V2);
    }
    else if (T2 == 0)
    {
        return (P2 * V2 * T1) / (P1 * V1);
    }

    else
    {
        return 0;
    }


}