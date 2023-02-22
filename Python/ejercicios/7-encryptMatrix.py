# decypher this

matrix = [
    [47, 146, 163, 46],
    [-21, 66, 74, 76],
    [19, 71, 85, 23],
    [-21, 63, 69, 75],
    [11, 212, 220, 118],
    [40, 163, 185, 41],
    [46, 184, 236, 44],
    [33, 251, 314, 77]
]


keymatrix = [
    [0, 3, 5, 1],
    [-1, 4, 4, 2],
    [-1, 1, 0, 3],
    [3, 4, 5, 4]
]

# 1. create a function that takes a matrix and a keymatrix and returns the decrypted matrix


def decryptMatrix(matrix, keymatrix):
    # 2. create a new matrix that will hold the decrypted matrix
    decryptedMatrix = []
    # 3. loop through the matrix
    for row in matrix:
        # 4. create a new list that will hold the decrypted row
        decryptedRow = []
        # 5. loop through the row
        for i in range(len(row)):
            # 6. get the value of the keymatrix at the same position
            key = keymatrix[i][i]
            # 7. get the value of the row at the same position
            value = row[i]
            # 8. add the value of the row minus the value of the keymatrix to the decrypted row
            decryptedRow.append(value - key)
        # 9. add the decrypted row to the decrypted matrix
        decryptedMatrix.append(decryptedRow)
    # 10. return the decrypted matrix
    return decryptedMatrix


print(decryptMatrix(
    matrix, keymatrix
))
