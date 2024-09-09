import numpy as np
import matplotlib.pyplot as plt
import matplotlib

matplotlib.use('TkAgg')


def f(x):
    return np.exp(x) - 10.2 * x


def df(x):
    return np.exp(x) - 10.2


def bisection_method(a, b, tol=1e-6, max_iter=100):
    approximations = []
    for _ in range(max_iter):
        c = (a + b) / 2
        approximations.append((c, f(c)))
        if f(c) == 0 or (b - a) / 2 < tol:
            return approximations
        if np.sign(f(c)) == np.sign(f(a)):
            a = c
        else:
            b = c
    return approximations


def secant_method(a, b, tol=1e-6, max_iter=100):
    approximations = []
    for _ in range(max_iter):
        fa, fb = f(a), f(b)
        c = b - fb * (b - a) / (fb - fa)
        approximations.append((c, f(c)))
        if abs(f(c)) < tol:
            return approximations
        a, b = b, c
    return approximations


def newton_method(x0, tol=1e-6, max_iter=100):
    approximations = []
    x = x0
    for _ in range(max_iter):
        fx = f(x)
        dfx = df(x)
        x_new = x - fx / dfx
        approximations.append((x_new, f(x_new)))
        if abs(f(x_new)) < tol:
            return approximations
        x = x_new
    return approximations


def combined_method(a, b, tol=1e-6, max_iter=100):
    approximations = []
    for _ in range(max_iter):
        fa, fb = f(a), f(b)
        c = (a * fb - b * fa) / (fb - fa)
        approximations.append((c, f(c)))
        if abs(f(c)) < tol:
            return approximations
        if np.sign(f(c)) == np.sign(f(a)):
            a = c
        else:
            b = c
    return approximations


def plot_approximations(approximations, title):
    xs, ys = zip(*approximations)
    plt.plot(xs, ys, 'o-', label=title)
    plt.xlabel('x')
    plt.ylabel('f(x)')
    plt.legend()
    root = xs[-1]
    plt.plot(root, 0, 'ro')
    plt.axvline(root, color='red', linestyle='--', linewidth=0.5)
    plt.text(root, plt.ylim()[0], f'{root:.6f}', color='red', ha='center', va='bottom')


def print_approximations(method_name, approximations):
    print(f"{method_name}:")
    print("Ітерація\t x\t\t f(x)")
    for i, (x, fx) in enumerate(approximations):
        print(f"{i + 1}\t\t {x:.6f}\t {fx:.6e}")


# if __name__ == "__main__":
#     a = 0.0
#     b = 1.0
#     x0 = 0.5
#
#     bisection_approximations = bisection_method(a, b)
#     secant_approximations = secant_method(a, b)
#     newton_approximations = newton_method(x0)
#     combined_approximations = combined_method(a, b)
#     print_approximations("Метод половинного ділення", bisection_approximations)
#     print_approximations("Метод хорд", secant_approximations)
#     print_approximations("Метод Ньютона", newton_approximations)
#     print_approximations("Комбінований метод", combined_approximations)
#
#     x = np.linspace(a, b, 400)
#     y = f(x)
#
#     plt.figure(figsize=(14, 8))
#     plt.grid(True)
#
#     plt.plot(x, y, label='f(x) = exp(x) - 10.2x')
#     plt.axhline(0, color='gray', lw=0.5)
#
#     plot_approximations(bisection_approximations, 'Половинного ділення')
#     plot_approximations(secant_approximations, 'Хорд')
#     plot_approximations(newton_approximations, 'Ньютона')
#     plot_approximations(combined_approximations, 'Комбінований')
#
#     plt.title('Пошук нулів функції')
#     plt.show()
#     plt.figure(figsize=(14, 10))

# 4 разных графика, ну по факту же так красивее
if __name__ == "__main__":
    a = 0.0
    b = 1.0
    x0 = 0.5

    bisection_approximations = bisection_method(a, b)
    secant_approximations = secant_method(a, b)
    newton_approximations = newton_method(x0)
    combined_approximations = combined_method(a, b)

    print_approximations("Метод половинного ділення", bisection_approximations)
    print_approximations("Метод хорд", secant_approximations)
    print_approximations("Метод Ньютона", newton_approximations)
    print_approximations("Комбінований метод", combined_approximations)

    x = np.linspace(a, b, 400)
    y = f(x)

    plt.figure(figsize=(14, 8))
    plt.grid(True)
    plt.subplot(2, 2, 1)
    plt.plot(x, y, label='f(x) = exp(x) - 10.2x')
    plt.axhline(0, color='gray', lw=0.5)
    plot_approximations(bisection_approximations, 'Метод половинного ділення')
    plt.title('Метод половинного ділення')

    plt.subplot(2, 2, 2)
    plt.plot(x, y, label='f(x) = exp(x) - 10.2x')
    plt.axhline(0, color='gray', lw=0.5)
    plot_approximations(secant_approximations, 'Метод хорд')
    plt.title('Метод хорд')

    plt.subplot(2, 2, 3)
    plt.plot(x, y, label='f(x) = exp(x) - 10.2x')
    plt.axhline(0, color='gray', lw=0.5)
    plot_approximations(newton_approximations, 'Метод Ньютона')
    plt.title('Метод Ньютона')

    plt.subplot(2, 2, 4)
    plt.plot(x, y, label='f(x) = exp(x) - 10.2x')
    plt.axhline(0, color='gray', lw=0.5)
    plot_approximations(combined_approximations, 'Комбінований метод')
    plt.title('Комбінований метод')

    plt.tight_layout()
    plt.show()
