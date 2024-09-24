#include <iostream>
#include <cmath>

class DivisionAlgorithm {
public:
    void divide(int a, int b) {
        // Verificar si el divisor es cero
        if (b == 0) {
            std::cout << "Error: La división por cero no está definida." << std::endl;
            return;
        }

        std::cout << "Iniciando la división de " << a << " entre " << b << "." << std::endl;

        int quotient, remainder;

        // Caso cuando el dividendo es cero
        if (a == 0) {
            quotient = 0;
            remainder = 0;
            std::cout << "Como el dividendo es cero, el cociente y el residuo son cero." << std::endl;
        } else {
            int r = std::abs(a);  // Valor absoluto del dividendo
            int q = 0;
            int abs_b = std::abs(b);  // Valor absoluto del divisor

            std::cout << "Valor absoluto del dividendo (r): " << r << std::endl;
            std::cout << "Cociente inicial (q): " << q << std::endl;

            std::cout << "\nIniciando el bucle de resta para encontrar el cociente y el residuo:" << std::endl;

            // Bucle mientras r ≥ |b|
            while (r >= abs_b) {
                r -= abs_b;
                q +=  1;
                std::cout << "Restando |b| de r: nuevo r = " << r << ", incrementando q: nuevo q = " << q << std::endl;
            }

            std::cout << "\nBucle terminado. Valor final de r: " << r << ", valor final de q: " << q << std::endl;

            // Ajuste del cociente y residuo según el signo de a
            if (a > 0) {
                quotient = q;
                remainder = r;
                std::cout << "Como a > 0, el cociente es q = " << quotient << ", y el residuo es r = " << remainder << std::endl;
            } else {
                if (r == 0) {
                    quotient = -q;
                    remainder = 0;
                    std::cout << "Como a < 0 y r = 0, el cociente es -q = " << quotient << ", y el residuo es 0." << std::endl;
                } else {
                    quotient = -q - 1;
                    remainder = abs_b - r;
                    std::cout << "Como a < 0 y r ≠ 0, ajustamos el cociente y el residuo:" << std::endl;
                    std::cout << "Cociente = -q - 1 = " << quotient << std::endl;
                    std::cout << "Residuo = |b| - r = " << remainder << std::endl;
                }
            }
        }

        std::cout << "\nResultado final: " << a << " = " << b << " * " << quotient << " + " << remainder << std::endl;
        std::cout << "Cociente: " << quotient << ", Residuo: " << remainder << std::endl;
    }
};

int main() {
    int a, b;
    std::cout << "Ingrese el dividendo (a): ";
    std::cin >> a;
    std::cout << "Ingrese el divisor (b, distinto de cero): ";
    std::cin >> b;

    DivisionAlgorithm division;
    division.divide(a, b);

    return 0;
}
