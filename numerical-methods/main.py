from sympy import diff

print('Варіант 2')
print('Фіноегенов Н.М. ОПК-419')
print('Завдання:  x**3 + 6*x - 5 = 0')

def returnfunc(x):
     return x**3 + 6*x - 5

def reurndiff(differ, x):
    differ = str(differ)
    differ = differ.replace('x', str(x))
    result = eval(differ)
    return result
def toFixed(num, digits=0):
    return f'{num:.{digits}f}'

func = 'x**3 + 6*x -5'
differ = diff(func)
delta = 1
epsilon = 0.0001
x0 = 2
count = 0
print('---------------------')
print('Метод Ньютона')
print('---------------------')
while delta > epsilon:
    x = x0 - returnfunc(x0) / reurndiff(differ, x0)
    print(f'{count} | {toFixed(x, 10)} | {delta}')
    delta = abs(x - x0)
    x0 = x
    count += 1
    if count > 30:
        break
print(f'Відповідь: {x0}')

print('\n\n---------------------')
print('Метод Січних')
print('---------------------')

def f(x):
    return x ** 3 + 6 * x - 5

def secant(x0, x1, e, N):
    step = 1
    condition = True
    while condition:
        if f(x0) == f(x1):
            print('Divide by zero error')
            break

        x2 = x0 - (x1 - x0) * f(x0) / (f(x1) - f(x0))
        print(f'{step} | {x2} | {abs(f(x2))}')
        x0 = x1
        x1 = x2
        step = step + 1

        if step > N:
            break

        condition = abs(f(x2)) > e
    print(f'Відповідь: {x2}')


# x0 = 0
# x1 = 1
# e = 0.0001
# N = 3
#
# x0 = float(x0)
# x1 = float(x1)
# e = float(e)
#
# N = int(N)
# secant(x0, x1, e, N)

import numpy as np

def lagrange_interpolation(xn, fn, x):
    n = len(xn)
    result = np.zeros_like(x)

    for i in range(n):
        term = fn[i]
        for j in range(n):
            if j != i:
                term *= (x - xn[j]) / (xn[i] - xn[j])
        result += term

    return result

xn = np.array([0.02, 0.08, 0.12, 0.17, 0.23, 0.30])
fn = np.array([1.02316, 1.09590, 1.14725, 1.21483, 1.21483, 1.40976])
x = np.array([0.101, 0.124, 0.153, 0.113, 0.202, 0.300])

interpolated_values = lagrange_interpolation(xn, fn, x)

print("Табличне представлення результатів:")
print("x\t\tInterpolated Value")
print("----------------------------------")
for i in range(len(x)):
    print(f"{x[i]:.3f}\t\t{interpolated_values[i]:.5f}")

import matplotlib
matplotlib.use('TkAgg')
import matplotlib.pyplot as plt

def custom_sort(array, array2):
    length = len(array)
    for i in range(0, length):
        for j in range(0, length - i - 1):
            if array[j] > array[j + 1]:
                temp = array[j]
                temp2 = array2[j]
                array[j] = array[j + 1]
                array2[j] = array2[j + 1]
                array[j + 1] = temp
                array2[j + 1] = temp2

plt.figure(figsize=(10, 6))
plt.plot(xn, fn, 'bo', label='Дані точки')
plt.plot(x, interpolated_values, 'ro', label='Інтерпольовані точки')
all_x = np.concatenate([xn, x])
all_y = np.concatenate([fn, interpolated_values])
custom_sort(all_x, all_y)

plt.plot(all_x, all_y, 'g-', label='Всі точки')
# xnew = np.linspace(all_x.min(), all_x.max(), 50)
# ynew = np
# # ynew = np.linspace(all_y.min(), all_y.max(), 50)
# plt.plot(xnew, ynew)

plt.xlabel('x')
plt.ylabel('f(x)')
plt.title('Графік інтерполяції за допомогою формули Лагранжа')
plt.legend()
plt.grid(True)
plt.show()
