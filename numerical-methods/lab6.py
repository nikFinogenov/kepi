import numpy as np
import matplotlib.pyplot as plt
import matplotlib

matplotlib.use('TkAgg')

def numerical_integration(method, f, y0, x0, xn, steps):
    """
    Performs numerical integration of an ODE using either Euler's method or the Runge-Kutta method.

    Parameters:
    method (str): 'euler' or 'rk' for Euler's method or Runge-Kutta method, respectively.
    f (callable): The function f(x, y) on the right side of the differential equation y' = f(x, y).
    y0 (float): Initial condition y(x0) = y0.
    x0 (float): The start of the interval for x.
    xn (float): The end of the interval for x.
    steps (int): Number of steps for tabulating the function y(x) on the interval [x0, xn].

    Returns:
    list: A list of tuples with x and y values representing the solution.
    """
    h = (xn - x0) / steps
    x = np.linspace(x0, xn, steps+1)
    y = np.zeros(steps+1)
    y[0] = y0

    if method == 'euler':
        for i in range(steps):
            y[i+1] = y[i] + h * f(x[i], y[i])
    elif method == 'rk':
        for i in range(steps):
            k1 = f(x[i], y[i])
            k2 = f(x[i] + h/2, y[i] + h/2 * k1)
            k3 = f(x[i] + h/2, y[i] + h/2 * k2)
            k4 = f(x[i] + h, y[i] + h * k3)
            y[i+1] = y[i] + (h/6) * (k1 + 2*k2 + 2*k3 + k4)
    else:
        raise ValueError("Method must be 'euler' or 'rk'.")

    return list(zip(x, y))

# Define the function for the given differential equation
def f(x, y):
    return (4*x - 12*x**2) * y

# Parameters
a = 1.0
b = 2.0
M = 40
y0 = 2.5

# Perform the numerical integration using Euler's method and Runge-Kutta method
euler_solution = numerical_integration('euler', f, y0, a, b, M)
rk_solution = numerical_integration('rk', f, y0, a, b, M)

# Plot the results
plt.figure(figsize=(12, 6))
plt.plot(*zip(*euler_solution), label='Euler Method', marker='o')
plt.plot(*zip(*rk_solution), label='Runge-Kutta Method', linestyle='--', marker='x')
plt.title("Numerical Integration of y' = (4x - 12x^2)y")
plt.xlabel('x')
plt.ylabel('y')
plt.legend()
plt.grid(True)
plt.show()

# Output the results
print("Euler's Method:")
print(euler_solution)

print("\nRunge-Kutta Method:")
print(rk_solution)
