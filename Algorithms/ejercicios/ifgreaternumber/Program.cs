//       -> b -> c
//     /
// a--
//     \
//       -> c -> b

//       -> a -> c
//     /
// b-- 
//     \
//       -> c -> a

//       -> a -> b
//     /
// c--
//     \
//       -> b -> a

namespace thegreaternumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int A, B, C;
            Console.Write("Hola, me podrías proporcionar el primer número: ");
            A = int.Parse(Console.ReadLine());
            Console.Write("Hola, me podrías proporcionar el segundo número: ");
            B = int.Parse(Console.ReadLine());
            Console.Write("Hola, me podrías proporcionar el tercer número: ");
            C = int.Parse(Console.ReadLine());
            if (A > C && C > B)
            {
                Console.WriteLine($"Los valores ordenados de mayor a menor son: {A}, {C}, {B}");
            }
            else if (A > B && B > C)
            {
                Console.WriteLine($"Los valores ordenados de mayor a menor son: {A}, {B}, {C}");
            }
            else if (B > A && A > C)
            {
                Console.WriteLine($"Los valores ordenados de mayor a menor son: {B}, {A}, {C}");
            }
            else if (B > C && C > A)
            {
                Console.WriteLine($"Los valores ordenados de mayor a menor son: {B}, {C}, {A}");
            }
            else if (C > A && A > B)
            {
                Console.WriteLine($"Los valores ordenados de mayor a menor son: {C}, {A}, {B}");
            }
            else if (C > B && B > A)
            {
                Console.WriteLine($"Los valores ordenados de mayor a menor son: {C}, {B}, {A}");
            }
            else
            {
                Console.WriteLine("Los valores son iguales");
            }
        }
    }
}