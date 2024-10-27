import math

def contar_primos(n: int) -> int:
    # Crear un arreglo booleano para marcar si un número es primo
    es_primo = [True] * (n + 1)
    contador = 0

    # Inicializar todos los números como primos
    for i in range(2, n + 1):
        es_primo[i] = True

    # Identificación de números primos (Criba de Eratóstenes)
    for p in range(2, int(math.sqrt(n)) + 1):
        if es_primo[p]:
            # Marcar todos los múltiplos de p como compuestos
            for i in range(p * p, n + 1, p):
                es_primo[i] = False

    # Contar los primos
    for i in range(2, n + 1):
        if es_primo[i]:
            contador += 1

    return contador

# Calcular cuántos números primos hay menores que 214
n = 225
cantidad_primos = contar_primos(n)
print(cantidad_primos)
