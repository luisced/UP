import math

def es_primo(numero: int) -> bool:
    if numero <= 1:
        return False
    if numero <= 3:
        return True
    if numero % 2 == 0 or numero % 3 == 0:
        return False

    i = 5
    while i * i <= numero:
        if numero % i == 0 or numero % (i + 2) == 0:
            return False
        i += 6

    return True

def contar_primos(n: int) -> int:
    # Crear un arreglo booleano para marcar si un número es primo
    es_primo_lista = [True] * (n + 1)
    contador = 0

    # Inicializar todos los números como primos
    for i in range(2, n + 1):
        es_primo_lista[i] = True

    # Identificación de números primos (Criba de Eratóstenes)
    for p in range(2, int(math.sqrt(n)) + 1):
        if es_primo_lista[p]:
            # Marcar todos los múltiplos de p como compuestos
            for i in range(p * p, n + 1, p):
                es_primo_lista[i] = False

    # Contar los primos
    for i in range(2, n + 1):
        if es_primo_lista[i]:
            contador += 1

    return contador

# Ejemplo de uso
def procedimiento_principal():
    numero = int(input("Ingresa un número: "))
    
    # Verificar si el número es primo
    if es_primo(numero):
        print(f"{numero} es un número primo.")
    else:
        print(f"{numero} no es un número primo.")
    
    # Contar los primos menores o iguales al número ingresado
    cantidad_primos = contar_primos(numero)
    print(f"El número de primos menores o iguales a {numero} es {cantidad_primos}.")

# Llamar al procedimiento principal
procedimiento_principal()

