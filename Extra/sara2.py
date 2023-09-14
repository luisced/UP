# Función para calcular la expresión de conjuntos
def calculate_expression(U, A, B, C, D):
    def xor_sets(set1, set2):
        return (set1 | set2) - (set1 & set2)
    
    part1 = C.intersection(B)
    part2 = B - D.intersection(C)
    part3 = C - A
    part4 = A.intersection(B)
    part5 = U
    part6 = A - B.intersection(C)
    
    return (xor_sets(part1, part2).union(part3).union(part4)) - xor_sets(part5, part6)

# Definir los conjuntos U, A, B, C, y D
U = set(range(-10, 16))
A = {-10, -7, -4, -1, 2, 5, 8, 11, 14}
B = {-10, -3, 4, 1}
C = {-4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}
D = {-5, -3, 6, 7}

# Calcular y mostrar el resultado de la expresión
result = calculate_expression(U, A, B, C, D)

print(result)
