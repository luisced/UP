def eucl_ext(a, b):
    c = abs(a)
    d = abs(b)

    c1, d1 = 1, 0
    c2, d2 = 0, 1

    while d != 0:
        q = c // d
        r = c - q * d  
        r1 = c1 - q * d1
        r2 = c2 - q * d2

        # Actualización de valores
        c, d = d, r
        c1, d1 = d1, r1
        c2, d2 = d2, r2

    # Regresar resultados
    mcd = c
    s = c1 * (1 if a >= 0 else -1)
    t = c2 * (1 if b >= 0 else -1)

    return mcd, s, t

a = int(input("Introduce el primer número (a): "))
b = int(input("Introduce el segundo número (b): "))

mcd, s, t = eucl_ext(a, b)

print(f"\nEl MCD de {a} y {b} es: {mcd}")
print(f"Coeficiente s: {s}")
print(f"Coeficiente t: {t}")
