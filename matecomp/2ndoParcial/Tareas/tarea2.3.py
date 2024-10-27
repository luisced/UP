def division_algoritmo(a, b):
    # Verificar que b no sea 0
    if b == 0:
        raise ValueError("El divisor no puede ser 0.")

    # Caso especial: si a es 0
    if a == 0:
        return (0, 0)

    q = abs(a) // b  # Cociente usando division entera
    r = abs(a) % b   # Residuo usando modulo

    # Si 'a' es positivo
    if a > 0:
        return (q, r)  # Regresa cociente y residuo

    # Si 'a' es negativo
    elif r == 0:
        return (-q, 0)  # Cociente negativo y residuo 0
    else:
        return (-q - 1, b - r)  # Cociente y residuo ajustados


def mcd(a, b):
    # Asegurarse de que ambos numeros sean positivos
    c = abs(a)
    d = abs(b)

    iteracion = 1

    # Mientras el divisor d no sea 0
    while d != 0:
        # Usar la funcion de division para obtener el residuo
        _, r = division_algoritmo(c, d)

        print(f"Iteracion {iteracion}: c = {c}, d = {d}, residuo = {r}")

        # Actualizar c y d para la siguiente iteracion
        c = d
        d = r

        iteracion += 1

    # Cuando d es 0, c es el MCD
    return c

def main():
    print("Bienvenido al Algoritmo del Maximo Comun Divisor (MCD).")

    try:
        a = int(input("Ingresa el primer numero (a): "))
        b = int(input("Ingresa el segundo numero (b): "))

        print("\nCalculando iteraciones:")
        resultado_mcd = mcd(a, b)

        print(f"\nEl Maximo Comun Divisor (MCD) de {a} y {b} es: {resultado_mcd}")

    except ValueError as e:
        print(f"Error: {e}. Asegurate de ingresar numeros enteros validos.")

if __name__ == "__main__":
    main()
