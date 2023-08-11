// Los viernes saliendo de clases, ya es una costumbre ir a las hamburguesas con tus amigos, sin embargo siempre se dificulta calcular cuanto tienen que pagar. Es curioso porque solo existe un tipo de hamburguesas con un precio de $50.45 cada una, las papas cuestan $32.51 y las bebidas $25.00
// Requerimos un programa que le pida al usuario la cantidad de hamburguesas, la cantidad de papas y la
// cantidad de bebidas que se consumieron y te escriba la trasos canticada par
// :seguido de la
// cantidad correcta.
// Suponemos que todas las cantidades de hamburguesas, papas y bebidas son numeros enteros menores a 1000. El resultado lo requerimos con todo y centavos cuando estos sean significativos.
// Utiliza constantes para almacenar los precios v así poder cambiarios en forma facil cuando estos cambien en el futuro
// Cantidad de hamburguesas:
// Cantidad a pagar 892.05
// Realiza:
// 1. El planteamiento del problema especificando datos de entrada y de salida
// 2, Pseudocódigo de la solución propuesta (si te sientes más cómodo puede ser diagrama de flujo)
// 3. Codificación de la solución en Visual Studio


// 1. Planteamientdo del problema:
// Datos de entrada: cantidad de hamburguesas, cantidad de papas, cantidad de bebidas
// Datos de salida: total a pagar

// 2. Pseudocódigo de la solución propuesta:
// 1. Definir constantes para los precios de las hamburguesas, papas y bebidas
// 2. Pedir al usuario la cantidad de hamburguesas, papas y bebidas
// 3. Calcular el total a pagar multiplicando la cantidad de hamburguesas, papas y bebidas por su precio
// 4. Mostrar en Consola el total a pagar al usuario





// using System;

// namespace Hamburguesas
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             const double precioHamburguesa = 50.45;
//             const double precioPapas = 32.51;
//             const double precioBebidas = 25.00;

//             Console.WriteLine("Cantidad de hamburguesas:");
//             int cantidadHamburguesas = int.Parse(Console.ReadLine());

//             Console.WriteLine("Cantidad de papas:");
//             int cantidadPapas = int.Parse(Console.ReadLine());

//             Console.WriteLine("Cantidad de bebidas:");
//             int cantidadBebidas = int.Parse(Console.ReadLine());

//             double total = (cantidadHamburguesas * precioHamburguesa) + (cantidadPapas * precioPapas) + (cantidadBebidas * precioBebidas);

//             Console.WriteLine("Total a pagar: " + total);
//         }
//     }
// }

// La empresa "El Esfuerzo" tiene la política de otorgar un bono a sus empleados con hijos menores de 18

// años.

// Si un empleado tiene uno o dos hijos menores de 18 años, la empresa le otorga un 10% del sueldo

// mensual por cada uno de sus hijos.

// Si un empledo tiene 3 o 4 hijos menores de 18 años, la empresa le otorga un 8% del sueldo mensual

// por cada uno de sus hijos.

// Si un empleado tiene más de 4 hijos menores de 18 años, la empresa le otorga un 40% del sueldo

// mensual, como bono total no importando el número de hijos.

// Escribe un programa que reciba el número de hijos y el sueldo mensual de un empleado y escriba el

// monto del bono que recibirá mensualmente el empleado.

// Ejemplo 1:

// Número de hijos menores de 18 años: 3

// Sueldo mensual: 40000

// Bono: 9600

// Ejemplo 2:

// Número de hijos menores de 18 años: 6

// Sueldo mensual: 40000

// Bono: 16000

// Realiza:

// 1. El planteamiento del problema especificando datos de entrada y de salida

// 2. Pseudocódigo de la solución propuesta (si te sientes más cómodo puede ser diagrama de flujo)

// 3. Codificación de la solución en Visual Studio.


// 1. Planteamiento del problema:
// Datos de entrada: número de hijos menores de 18 años, sueldo mensual
// Datos de salida: bono mensual

// 2. Pseudocódigo de la solución propuesta:
// 1. Definir constantes para los porcentajes de bono
// 1. Pedir al usuario el número de hijos menores de 18 años y el sueldo mensual
// 2. Si el número de hijos es 1 o 2, el bono es el 10% del sueldo mensual
// 3. O Si el número de hijos es 3 o 4, el bono es el 8% del sueldo mensual
// 4. O Si el número de hijos es mayor a 4, el bono es el 40% del sueldo mensual
// 5. Mostrar en Consola el bono mensual al usuario





// using System;

using System;

namespace BonoEmpleado
{
class Program
{
static void Main(string[] args)
{
int numHijos;
double sueldo, bono;
Console.WriteLine("Ingrese el número de hijos menores de 18 años:");
        numHijos = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el sueldo mensual del empleado:");
        sueldo = double.Parse(Console.ReadLine());

        if (numHijos <= 2)
        {
            bono = sueldo * numHijos * 0.1;
        }
        else if (numHijos <= 4)
        {
            bono = sueldo * numHijos * 0.08;
        }
        else
        {
            bono = sueldo * 0.4;
        }

        Console.WriteLine($"El monto del bono mensual es: {bono:C}");
    }
}
}

// Tienes una canica totalmente esférica y la vas a poner en una repisa, dentro de un cubo transparente y lleno de agua.
// La canica cabe exacta dentro del cubo, es decir que hace contacto con las cuatro paredes del cubo, con la parte inferior y con la tapa del cubo.
// Te preguntas cuanta agua necesitas para llenar los espacios del cubo que no ocupa la esfera.
// Requerimos un programa que le pida al usuario el radio de la canica en cm y nos escriba la frase:
// Requieros agua por: XXX.X centimetros cúbicos.
// El radio de la circunferencia que nos proporcionan está en cm y es un número menor o igual a 10
// con un decimala
// El volumen requerido de agua lo tenemos que representar también con un decimal en centrimetros cúbicos.
// Ejemplot:
// Radio de la canica (cm): 10.0
// Requerimos agua por: 3811.2 centramet
// Ejemplo2:
// Radio de la canica (cm): 3.5
// Requerimos agua por 163,4 centrimetros cubicos

// 1: Planteamiento del problema
// Datos de entrada: radio de la canica
// Datos de salida: volumen de agua requerido

// 2: Pseudocódigo de la solución propuesta
// 1. Definir constantes para el volumen de la canica y el volumen del cubo
// 2. Pedir al usuario el radio de la canica
// 3. Calcular el volumen de la canica multiplicando el radio al cubo por el volumen de la canica   
// 4. Calcular el volumen del cubo multiplicando el radio al cubo por el volumen del cubo
// 5. Calcular el volumen de agua requerido restando el volumen del cubo menos el volumen de la canica
// 6. Mostrar en consola el volumen de agua requerido


// using System;

// namespace Canica
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             const double volumenCanica = 4.0 / 3.0 * Math.PI;
//             const double volumenCubo = Math.Pow(10, 3);

//             Console.WriteLine("Radio de la canica (cm):");
//             double radioCanica = double.Parse(Console.ReadLine());

//             double volumenCanicaTotal = Math.Pow(radioCanica, 3) * volumenCanica;
//             double volumenCuboTotal = Math.Pow(radioCanica, 3) * volumenCubo;
//             double volumenAguaRequerido = volumenCuboTotal - volumenCanicaTotal;

//             Console.WriteLine("Requerimos agua por: " + volumenAguaRequerido + " centrimetros cubicos");
//         }
//     }
// }

// Estás jugando monopolio con tus amigos y resulta que vas ganando por lo que tienes gran cantidad de billetes de 100, 50, 20, 10, 5 y 1.

// Decides que a partir de este momento siempre que te toque pagar por algo, lo harás buscando utilizar el menor número de billetes necesario; te das cuenta que para ello debes pagar con el mayor número de billetes de 100, luego el mayor número de billetes de 50 y así hasta llegar a 1. Sacas tu celular donde te es fácil programar en C# con una versión especial de visual studio y realizas el programa que te pida una cantidad entera menor a 104, y como resultado te arroje el número de billetes que necesitas de cada denominación disponible. Asuminos que siempre vas a introducir una cantidad válida.

// Ejemplo:

// Digite una cantidad a pagar: 8789

// Billetes de 100: 87

// Billetes de 50: 1

// Billetes de 20: 1

// Billetes de 10: 1

// Billetes de 5: 1

// Billetes de 1: 4


// 1. Planteamiento del problema
// Datos de entrada: cantidad a pagar
// Datos de salida: número de billetes de cada denominación

// using System;

// namespace Billetes
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             int[] billetes = { 100, 50, 20, 10, 5, 1 };


//             Console.WriteLine("Digite una cantidad a pagar:");
//             int cantidadPagar = int.Parse(Console.ReadLine());

//             for (int i = 0; i < billetes.Length; i++)
//             {
//                 int numeroBilletes = cantidadPagar / billetes[i];
//                 cantidadPagar = cantidadPagar % billetes[i];
//                 Console.WriteLine("Billetes de " + billetes[i] + ": " + numeroBilletes);
//             }



//         }
//     }
// }

// 1. Definir un arreglo con los billetes disponibles
// 2. Pedir al usuario la cantidad a pagar
// 3. Recorrer el arreglo de billetes
// 4. Calcular el número de billetes de cada denominación: cantidad a pagar / billete
// 5. Calcular el resto de la división: cantidad a pagar % billete
// 6. Mostrar en consola el número de billetes de cada denominación

