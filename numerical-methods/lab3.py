import numpy as np

def gauss_elimination(A, b):
    n = len(b)
    A = np.array(A, float)
    b = np.array(b, float)

    for k in range(n):
        if np.fabs(A[k, k]) < 1.0e-12:
            for i in range(k + 1, n):
                if np.fabs(A[i, k]) > np.fabs(A[k, k]):
                    A[[k, i]] = A[[i, k]]
                    b[[k, i]] = b[[i, k]]
                    break

        pivot = A[k, k]
        if pivot == 0:
            raise ValueError("Матриця сингулярна або майже сингулярна")
        A[k] = A[k] / pivot
        b[k] = b[k] / pivot

        for i in range(k + 1, n):
            factor = A[i][k]
            A[i] = A[i] - factor * A[k]
            b[i] = b[i] - factor * b[k]

    x = np.zeros(n, float)
    for k in range(n - 1, -1, -1):
        x[k] = (b[k] - np.dot(A[k, k + 1:], x[k + 1:]))
    return x

def cramer_rule(A, b):
    det_A = np.linalg.det(A)
    if det_A == 0:
        raise ValueError("Матриця A сингулярна")
    n = len(b)
    x = np.zeros(n)
    for i in range(n):
        Ai = np.copy(A)
        Ai[:, i] = b
        x[i] = np.linalg.det(Ai) / det_A
    return x

def verify_solution(A, x, b):
    b_calculated = np.dot(A, x)
    return np.allclose(b, b_calculated)

A = [[0.61, 0.71, -0.05],
     [-1.03, -2.05, 0.87],
     [2.50, -3.12, 5.03]]
b = [-0.16, 0.50, 0.95]

x_gauss = gauss_elimination(A, b)
x_cramer = cramer_rule(A, b)

gauss_verification = verify_solution(A, x_gauss, b)
cramer_verification = verify_solution(A, x_cramer, b)

print("Метод Гаусса:")
print("Решение:", x_gauss)
print("Проверка:", "Верно" if gauss_verification else "Неверно")
print()
print("Правило Крамера:")
print("Решение:", x_cramer)
print("Проверка:", "Верно" if cramer_verification else "Неверно")
