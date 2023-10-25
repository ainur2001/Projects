import numpy as np
from PIL import Image
import matplotlib.pyplot as plt
import math


def get_grayscale_image(image_np):
    red_channel = image_np[:, :, 0]
    green_channel = image_np[:, :, 1]
    blue_channel = image_np[:, :, 2]
    grayscale_image = (red_channel // 3) + (green_channel // 3) + (blue_channel // 3)
    return grayscale_image


def get_blurred_image(grayscale_image):
    kernel_size = 7
    sigma = 1.3
    kernel = np.fromfunction(
        lambda x, y: (1 / (2 * np.pi * sigma**2)) * np.exp(-((x - (kernel_size - 1) / 2)**2 + (y - (kernel_size - 1) / 2)**2) / (2 * sigma**2)), (kernel_size, kernel_size))
    kernel /= np.sum(kernel)

    height, width = grayscale_image.shape
    extended_image = np.pad(grayscale_image, ((kernel_size // 2, kernel_size // 2), (kernel_size // 2, kernel_size // 2)), mode='reflect')
    blurred_image = np.zeros_like(grayscale_image, dtype=float)

    for i in range(height):
        for j in range(width):
            square = extended_image[i:i + kernel_size, j:j + kernel_size]
            blurred_image[i, j] = np.sum(square * kernel)

    return blurred_image.astype(np.uint8)


def sobel_filter(blurred_image):
    sobel_x = np.array([[-1, 0, 1], 
                        [-2, 0, 2], 
                        [-1, 0, 1]], 
                        dtype=float)
    
    sobel_y = np.array([[-1, -2, -1], 
                        [0, 0, 0], 
                        [1, 2, 1]], 
                        dtype=float)

    height, width = blurred_image.shape
    gradient_x = np.zeros((height, width), dtype=float)
    gradient_y = np.zeros((height, width), dtype=float)
    gradient_magnitude = np.zeros((height, width), dtype=float)
    gradient_direction = np.zeros((height, width), dtype=float)

    for y in range(1, height - 1):
        for x in range(1, width - 1):
            window = blurred_image[y-1:y+2, x-1:x+2]
            gradient_x[y, x] = np.sum(sobel_x * window)
            gradient_y[y, x] = np.sum(sobel_y * window)
            gradient_magnitude[y, x] = np.sqrt(gradient_x[y, x]**2 + gradient_y[y, x]**2)
            gradient_direction[y, x] = np.arctan2(gradient_y[y, x], gradient_x[y, x])

    gradient_direction = (gradient_direction * 180 / np.pi + 360) % 360

    return gradient_magnitude, gradient_direction


def round_direction_to_8_angles(direction):
    angles = [0, 45, 90, 135, 180, 225, 270, 315]
    quantized_direction = np.zeros_like(direction, dtype=int)
    for i, angle in enumerate(angles):
        mask = np.logical_and(direction >= angle - 22.5, direction < angle + 22.5)
        quantized_direction[mask] = angles[i]
    return quantized_direction


def non_maximum_suppression(magnitude, direction):
    height, width = magnitude.shape
    suppressed = np.zeros_like(magnitude)
    for i in range(1, height - 1):
        for j in range(1, width - 1):
            if direction[i, j] == 0:
                if magnitude[i, j] >= max(magnitude[i, j - 1], magnitude[i, j + 1]):
                    suppressed[i, j] = magnitude[i, j]
            elif direction[i, j] == 45:
                if magnitude[i, j] >= max(magnitude[i - 1, j + 1], magnitude[i + 1, j - 1]):
                    suppressed[i, j] = magnitude[i, j]
            elif direction[i, j] == 90:
                if magnitude[i, j] >= max(magnitude[i - 1, j], magnitude[i + 1, j]):
                    suppressed[i, j] = magnitude[i, j]
            elif direction[i, j] == 135:
                if magnitude[i, j] >= max(magnitude[i - 1, j - 1], magnitude[i + 1, j + 1]):
                    suppressed[i, j] = magnitude[i, j]
            elif direction[i, j] == 180:
                if magnitude[i, j] >= max(magnitude[i, j - 1], magnitude[i, j + 1]):
                    suppressed[i, j] = magnitude[i, j]
            elif direction[i, j] == 225:
                if magnitude[i, j] >= max(magnitude[i - 1, j - 1], magnitude[i + 1, j + 1]):
                    suppressed[i, j] = magnitude[i, j]
            elif direction[i, j] == 270:
                if magnitude[i, j] >= max(magnitude[i - 1, j], magnitude[i + 1, j]):
                    suppressed[i, j] = magnitude[i, j]
            elif direction[i, j] == 315:
                if magnitude[i, j] >= max(magnitude[i - 1, j + 1], magnitude[i + 1, j - 1]):
                    suppressed[i, j] = magnitude[i, j]
    return suppressed


def hysteresis_thresholding(image, T_low, T_high):
    height, width = image.shape
    visited = np.zeros((height, width), dtype=bool)
    for i in range(height):
        for j in range(width):
            if image[i, j] >= T_high and not visited[i, j]:
                visited[i, j] = True
            elif image[i, j] >= T_low and not visited[i, j]:
                visited[i, j] = True
                stack = [(i, j)]
                while stack:
                    x, y = stack.pop()
                    for m in range(-1, 2):
                        for n in range(-1, 2):
                            if T_low <= image[x + m, y + n] and not visited[x + m, y + n]:
                                visited[x + m, y + n] = True
                                stack.append((x + m, y + n))
    return visited


def hough_transform(edges_image, rho_resolution=1, theta_resolution=np.deg2rad(1), threshold=100):
    # Вычисление максимальной длины ро (на основе размеров изображения)
    height, width = edges_image.shape
    max_rho = int(math.hypot(height, width))

    # Вычисление диапазонов для ро и тета
    rhos = np.arange(-max_rho, max_rho, rho_resolution)
    thetas = np.arange(-np.pi/2, np.pi/2, theta_resolution)

    # Инициализация кумулятивного массива
    accumulator = np.zeros((len(rhos), len(thetas)), dtype=int)

    # Нахождение ненулевых пикселей на изображении и обработка каждого пикселя
    for y in range(height):
        for x in range(width):
            if edges_image[y, x] > 0:
                for t_idx, theta in enumerate(thetas):
                    rho = int(x * np.cos(theta) + y * np.sin(theta))
                    rho_idx = np.argmin(np.abs(rhos - rho))
                    accumulator[rho_idx, t_idx] += 1

    # Применение порога для определения значимых линий
    significant_pixels = np.where(accumulator > threshold)

    return accumulator, rhos, thetas, significant_pixels

def plot_hough_lines(image, significant_pixels, rhos, thetas):
    output_image = image.copy()

    for rho_idx, theta_idx in zip(significant_pixels[0], significant_pixels[1]):
        rho = rhos[rho_idx]
        theta = thetas[theta_idx]
        a = np.cos(theta)
        b = np.sin(theta)
        x0 = a * rho
        y0 = b * rho
        x1 = int(x0 + 1000 * (-b))
        y1 = int(y0 + 1000 * (a))
        x2 = int(x0 - 1000 * (-b))
        y2 = int(y0 - 1000 * (a))

        # Рисуем линию на изображении
        plt.plot([x1, x2], [y1, y2], color=(1, 0, 0), linewidth=2)

    plt.imshow(output_image, cmap='gray')
    plt.title("Исходное изображение с найденными линиями")
    plt.show()

def plot_hough_steps(image_np, edges_image, accumulator, rhos, thetas):
    plt.subplot(131)
    plt.imshow(image_np, cmap='gray')
    plt.title("Исходное изображение")

    # Отображение бинарного изображения с границами
    plt.subplot(132)
    plt.imshow(edges_image, cmap='gray')
    plt.title("Бинарное изображение с границами")

    # Отображение кумулятивного массива
    plt.subplot(133)
    plt.imshow(accumulator, cmap='gray', extent=[np.rad2deg(thetas[0]), np.rad2deg(thetas[-1]), rhos[-1], rhos[0]], aspect='auto')
    plt.title("Кумулятивный массив")

    plt.show()



if __name__ == "__main__":
    image = Image.open('0.jpg')
    image_np = np.array(image)
    grayscale_image = get_grayscale_image(image_np)
    blurred_image = get_blurred_image(grayscale_image)
    gradient_magnitude, gradient_direction = sobel_filter(blurred_image)
    quantized_direction = round_direction_to_8_angles(gradient_direction)
    suppressed = non_maximum_suppression(gradient_magnitude, quantized_direction)
    edges = hysteresis_thresholding(suppressed, T_low=40, T_high=100)

    canny_image = edges
    accumulator, rhos, thetas, significant_pixels = hough_transform(canny_image)
    plot_hough_steps(image_np, canny_image, accumulator, rhos, thetas)
    plot_hough_lines(canny_image, significant_pixels, rhos, thetas)
