import numpy as np
import matplotlib.pyplot as plt
import matplotlib

matplotlib.use('TkAgg')


def approximate_derivative(f, x0, h, M):
    x_values = x0 + np.arange(M) * h

    derivatives = np.zeros(M)
    for i in range(M):
        if i == 0:
            derivatives[i] = (f(x_values[i + 1]) - f(x_values[i])) / h
        elif i == M - 1:
            derivatives[i] = (f(x_values[i]) - f(x_values[i - 1])) / h
        else:
            derivatives[i] = (f(x_values[i + 1]) - f(x_values[i - 1])) / (2 * h)
    return x_values, derivatives


def parse_input_function(function_str):
    code = compile(function_str, '<string>', 'eval')
    return lambda x: eval(code, {"x": x, "np": np, "exp": np.exp})


x0 = 0.0
h = 0.1
M = 41
f_str = "np.exp(-x)"

func = parse_input_function(f_str)

x_values, derivatives = approximate_derivative(func, x0, h, M)

for x, derivative in zip(x_values, derivatives):
    print(f"x: {x:.2f}, производная: {derivative:.4f}")

plt.plot(x_values, derivatives, label="Производные для выбранных значений")
plt.scatter(x_values, derivatives, color='red')
plt.xlabel('x')
plt.ylabel('Производная')
plt.title("Аппроксимированные производные")
plt.legend()
plt.grid(True)
plt.show()
