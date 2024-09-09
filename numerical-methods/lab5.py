import numpy as np

def parse_function(function_str):
    code = compile(function_str, '<string>', 'eval')
    return lambda x: eval(code, {"x": x, "np": np, "exp": np.exp})

def left_rectangle_integration(f, a, b, N):
    h = (b - a) / N
    return sum(f(a + i * h) for i in range(N)) * h

def right_rectangle_integration(f, a, b, N):
    h = (b - a) / N
    return sum(f(a + (i + 1) * h) for i in range(N)) * h

def midpoint_rectangle_integration(f, a, b, N):
    h = (b - a) / N
    return sum(f(a + (i + 0.5) * h) for i in range(N)) * h

def trapezoidal_integration(f, a, b, N):
    h = (b - a) / N
    return (f(a) + 2 * sum(f(a + i * h) for i in range(1, N)) + f(b)) * (h / 2)

def simpson_integration(f, a, b, N):
    if N % 2 != 0:
        N += 1
    h = (b - a) / N
    return (h / 3) * (f(a) + 4 * sum(f(a + (i * h)) for i in range(1, N, 2)) +
                      2 * sum(f(a + (i * h)) for i in range(2, N - 1, 2)) + f(b))

a = 0.0
b = 5.0
N = 42
f_str = "np.exp(-x**2)"

f = parse_function(f_str)

left_rectangle = left_rectangle_integration(f, a, b, N)
right_rectangle = right_rectangle_integration(f, a, b, N)
midpoint_rectangle = midpoint_rectangle_integration(f, a, b, N)
trapezoidal = trapezoidal_integration(f, a, b, N)
simpson = simpson_integration(f, a, b, N)

print("Інтеграли для вибраних значень:")
print(f"Метод лівих прямокутників: {left_rectangle}")
print(f"Метод правих прямокутників: {right_rectangle}")
print(f"Метод середніх прямокутників: {midpoint_rectangle}")
print(f"Метод трапецій: {trapezoidal}")
print(f"Метод Симпсона: {simpson}")
