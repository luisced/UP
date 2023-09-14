# Función para verificar si un número es primo
def is_prime(n):
    if n <= 1:
        return False
    for i in range(2, int(n ** 0.5) + 1):
        if n % i == 0:
            return False
    return True

# Función para generar números primos de Fermat
def fermat_prime(n):
    return 2**(2**n) + 1

# Función para generar números primos de Mersenne
def mersenne_prime(p):
    return 2**p - 1

# Verificar qué números en el intervalo (0, 27] son primos de Fermat
fermat_primes_in_interval = []
for n in range(5):
    fermat_number = fermat_prime(n)
    if fermat_number > 27:
        break
    if is_prime(fermat_number):
        fermat_primes_in_interval.append(fermat_number)

# Generar los primeros 7 números primos de Mersenne
mersenne_primes = []
p = 2

while len(mersenne_primes) < 7:
    mersenne_number = mersenne_prime(p)
    if is_prime(mersenne_number):
        mersenne_primes.append(mersenne_number)
    p += 1  # Incrementamos p para buscar el siguiente número primo

# Calcular las diferencias absolutas entre cada número primo de Mersenne y cada número primo de Fermat
differences = [abs(mersenne - fermat) for mersenne in mersenne_primes for fermat in fermat_primes_in_interval]

# Calcular la media de estas diferencias
mean_difference = sum(differences) / len(differences)

print("Números primos de Fermat en el intervalo (0, 27]:", fermat_primes_in_interval)
print("Primeros 7 números primos de Mersenne:", mersenne_primes)
print("Diferencia media entre los números:", mean_difference)
