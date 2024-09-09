import numpy as np
import matplotlib.pyplot as plt
from scipy.optimize import newton
import matplotlib

matplotlib.use('TkAgg')

def bisection(f, a, b, tol=1e-5):
    fa, fb = f(a), f(b)
    if fa * fb >= 0:
        raise ValueError("Функция должна иметь разные знаки на концах интервала a и b.")
    while (b - a) / 2 > tol:
        c = (a + b) / 2
        fc = f(c)
        if fc == 0:
            return c
        if fc * fa < 0:
            b = c
        else:
            a = c
            fa = fc
    return (a + b) / 2

def secant_method(f, a, b, tol=1e-5):
    fa, fb = f(a), f(b)
    if fa * fb >= 0:
        raise ValueError("Функция должна иметь разные знаки на концах интервала a и b.")
    while abs(b - a) > tol:
        c = b - fb * (b - a) / (fb - fa)
        a, b = b, c
        fa, fb = fb, f(b)
    return b

def example_function(x):
    return np.exp(x) - 10 * x

def plot_function_and_root(f, root, a, b):
    x = np.linspace(a, b, 1000)
    y = f(x)
    """plt.figure(figsize=(8, 4))"""
    plt.plot(x, y, label='Функция')
    plt.plot(root, f(root), 'ro', label='Корень')
    plt.axhline(0, color='black', linewidth=0.5)
    plt.axvline(root, color='red', linestyle='--', linewidth=0.5)
    plt.title('Функция и ее корень')
    plt.legend()
    plt.xlabel('x')
    plt.ylabel('f(x)')
    plt.grid(True)
    plt.show()


a = 0.0
b = 1.0
root_bisection = bisection(example_function, a, b)
root_secant = secant_method(example_function, a, b)
root_newton = newton(example_function, (a + b) / 2)

roots = {'root_bisection': root_bisection, 'root_secant': root_secant, 'root_newton': root_newton}
print(roots)

plot_function_and_root(example_function, root_bisection, a, b)
plot_function_and_root(example_function, root_secant, a, b)
plot_function_and_root(example_function, root_newton, a, b)


