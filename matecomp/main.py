
import numpy as np
import pandas as pd

# Se Definen conjutnos A = B = C = D = {1, 2, 3, 4}
A = {1, 2, 3, 4}

# Se definen las relaciones
R = {(1, 1), (1, 3), (1, 4), (2, 1), (2, 2), (2, 4), (3, 2), (3, 3), (4, 1), (4, 3), (4, 4)}
S = {(1, 2), (1, 3), (2, 3), (2, 4), (3, 1), (3, 2), (3, 3), (4, 2), (4, 3)}
T = {(1, 3), (1, 4), (2, 1), (2, 3), (2, 4), (3, 1), (3, 2), (4, 2)}

# Step 1: inversa de S
S_inverse = {(b, a) for (a, b) in S}

# Step 2: Complemento de R
R_complement = {(a, b) for a in A for b in A} - R

# Step 3: La intersección de S^-1 y R
intersection_S_inv_R = S_inverse & R

# Step 4: La unión de T y R'
union_T_R_complement = T | R_complement

# Step 5: El complemento de la intersección de S^-1 y R
complement_S_inv_intersection_R = {(a, b) for a in A for b in A} - intersection_S_inv_R

# Función para componer relaciones
def compose_relations(rel1, rel2):
    result = set()
    for (a, b) in rel1:
        for (c, d) in rel2:
            if b == c:
                result.add((a, d))
    return result

# Step 6: Composición de las relaciones
composition_result = compose_relations(complement_S_inv_intersection_R, union_T_R_complement)

# Results
print("S inversa", R)
print("Complemento de R", R_complement)
print("Intersección de S^-1 y R", intersection_S_inv_R)
print("Unión de T y R'", union_T_R_complement)
print("Complemento de la intersección de S^-1 y R", complement_S_inv_intersection_R)
print("Composición de las relaciones", composition_result)
