import numpy as np
from PIL import Image
import matplotlib.pyplot as plt
import cv2


def get_grayscale_image(image_np):
    red_channel = image_np[:, :, 0]
    green_channel = image_np[:, :, 1]
    blue_channel = image_np[:, :, 2]
    grayscale_image = (red_channel // 3) + (green_channel // 3) + (blue_channel // 3)
    return grayscale_image


def plot_histogram(image):
    r, g, b = image.split()

    hist_r = r.histogram()
    hist_g = g.histogram()
    hist_b = b.histogram()
    plt.figure(figsize=(10, 5))

    plt.title('Гистограмма RGB')
    plt.plot(hist_r, color='red', label='Красный')
    plt.plot(hist_g, color='green', label='Зеленый')
    plt.plot(hist_b, color='blue', label='Синий')

    plt.xlabel('Значение пикселя')
    plt.ylabel('Частота')
    plt.show()


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


def otsu_threshold(image_np):
    gray_image_np = get_grayscale_image(image_np)
    hist = np.histogram(gray_image_np, bins=256, range=(0, 256))[0]
    hist = hist / hist.sum()
    variances = []

    for threshold in range(1, 256):
        # сумма вероятностей
        w0 = hist[:threshold].sum() # класс фона
        w1 = hist[threshold:].sum() # класс объекта
        # среднее значение оттенков пикселей
        mu0 = np.average(np.arange(threshold), weights=np.arange(threshold, dtype=float) + 1)
        mu1 = np.average(np.arange(threshold, 256), weights=np.arange(threshold, 256, dtype=float) + 1)
        variances.append(w0 * w1 * (mu0 - mu1) ** 2)

    optimal_threshold = np.argmax(variances)
    binary_image_np = gray_image_np > optimal_threshold
    return binary_image_np


def remove_salt_and_pepper_noise(binary_image, kernel_size):
    h, w = binary_image.shape
    filtered_image_np = np.zeros((h, w), dtype=np.uint8)
    half_kernel = kernel_size // 2
    for i in range(h):
        for j in range(w):
            neighborhood = []
            for ni in range(i - half_kernel, i + half_kernel + 1):
                for nj in range(j - half_kernel, j + half_kernel + 1):
                    if 0 <= ni < h and 0 <= nj < w:
                        neighborhood.append(binary_image[ni, nj])
            filtered_image_np[i, j] = np.median(neighborhood)
    return filtered_image_np


def segmentation(image):
    Image.fromarray(image.astype(np.uint8) * 255)
    segm_im = np.zeros((image.shape[0], image.shape[1]), dtype=int)
    for i in range(segm_im.shape[0]):
        for j in range(segm_im.shape[1]):
            segm_im[i, j] = -1

    k = 0
    stack = []
    while True:
        point = None
        for i in range(segm_im.shape[0]):
            for j in range(segm_im.shape[1]):
                if segm_im[i, j] == -1:
                    point = [i, j]
        if point is None:
            return segm_im
        stack.append(point)
        while len(stack) > 0:
            point = stack.pop()
            segm_im[point[0], point[1]] = k
            if point[1] - 1 >= 0 and image[point[0], point[1] - 1] == image[point[0], point[1]]:
                if segm_im[point[0], point[1] - 1] == -1:
                    stack.append([point[0], point[1] - 1])
            if point[0] - 1 >= 0 and image[point[0] - 1, point[1]] == image[point[0], point[1]]:
                if segm_im[point[0] - 1, point[1]] == -1:
                    stack.append([point[0] - 1, point[1]])
            if point[1] + 1 < segm_im.shape[1] and image[point[0], point[1] + 1] == image[point[0], point[1]]:
                if segm_im[point[0], point[1] + 1] == -1:
                    stack.append([point[0], point[1] + 1])
            if point[0] + 1 < segm_im.shape[0] and image[point[0] + 1, point[1]] == image[point[0], point[1]]:
                if segm_im[point[0] + 1, point[1]] == -1:
                    stack.append([point[0] + 1, point[1]])
        k += 1


def color_segments(segmented_image):
    unique_labels = np.unique(segmented_image)
    colored_image = np.zeros((segmented_image.shape[0], segmented_image.shape[1], 3), dtype=np.uint8)

    for label in unique_labels:
        color = tuple(np.random.randint(0, 256, 3))
        segment_mask = segmented_image == label
        colored_image[segment_mask] = color

    return colored_image


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


def hough_transform(edges_image, threshold):
    height, width = edges_image.shape
    theta_resolution = np.deg2rad(1)
    max_rho = int(np.sqrt(height**2 + width**2))
    hafa_array = np.zeros((max_rho, len(np.arange(-np.pi/2, np.pi, theta_resolution))), dtype=int)
    rhos = np.arange(0, max_rho)
    thetas = np.arange(-np.pi/2, np.pi, theta_resolution)
    for y in range(height):
        for x in range(width):
            if edges_image[y, x] > 0:
                for theta_index, theta in enumerate(thetas):
                    rho = int(x * np.cos(theta) + y * np.sin(theta))
                    rho_index = rho
                    hafa_array[rho_index, theta_index] += 1

    significant_pixels = np.where(hafa_array > threshold)

    return hafa_array, rhos, thetas, significant_pixels


def draw_lines(image, significant_pixels, rhos, thetas):
    for rho_index, theta_index in zip(significant_pixels[0], significant_pixels[1]):
        rho = rhos[rho_index]
        theta = thetas[theta_index]
        a = np.cos(theta)
        b = np.sin(theta)
        x0 = a * rho
        y0 = b * rho
        x1 = int(x0 + 1000 * (-b))
        y1 = int(y0 + 1000 * (a))
        x2 = int(x0 - 1000 * (-b))
        y2 = int(y0 - 1000 * (a))

        plt.plot([x1, x2], [y1, y2], color="lime", linewidth=2)

    plt.imshow(image)
    plt.title("Исходное изображение с найденными линиями")
    plt.show()


def analyze_brightness_contrast(image_path):
    # Загрузка изображения
    image = cv2.imread(image_path, cv2.IMREAD_GRAYSCALE)

    # Вычисление яркости и контраста
    mean_brightness = np.mean(image)
    contrast = np.std(image)

    return mean_brightness, contrast

if __name__ == "__main__":
    image = Image.open('photo.jpg')
    image_np = np.array(image)

    
    # plt.imshow(image_np)
    # plt.title('Исходное изображение')
    # plt.show()


    # Получание гистограммы каналов RGB исходного изображения
    # plot_histogram(image)


    # Получение полутонового изображения и его гистограммы
    # grayscale_image = get_grayscale_image(image_np)
    # plt.imshow(grayscale_image, cmap="gray")
    # plt.title('Полутоновое изображение')
    # plt.show()
    # histogram = np.histogram(grayscale_image, bins=256, range=(0, 256))[0]
    # plt.bar(range(256), histogram)
    # plt.xlabel('Значение пикселя')
    # plt.ylabel('Частота')
    # plt.title('Гистограмма полутонового изображения')
    # plt.show()



    # Получение границ объектов на изображении
    # blurred_image = get_blurred_image(grayscale_image)
    # gradient_magnitude, gradient_direction = sobel_filter(blurred_image)
    # quantized_direction = round_direction_to_8_angles(gradient_direction)
    # suppressed = non_maximum_suppression(gradient_magnitude, quantized_direction)
    # canny_image = hysteresis_thresholding(suppressed, T_low=70, T_high=120)
    # plt.imshow(canny_image, cmap="gray")
    # plt.title('Изображение с границами объектов')
    # plt.show()


    # Сегментация изображения
    # binary_image = otsu_threshold(image_np)
    # filtered_image = remove_salt_and_pepper_noise(binary_image, 5)
    # segmentated_image = segmentation(filtered_image)
    # colored_image = color_segments(segmentated_image)
    # plt.imshow(binary_image, cmap="gray")
    # plt.title('Бинарное изображение')
    # plt.show()
    # plt.imshow(filtered_image, cmap="gray")
    # plt.title('Соль и перец')
    # plt.show()
    # plt.imshow(segmentated_image)
    # plt.title('Выращивание семян')
    # plt.show()
    # plt.imshow(colored_image)
    # plt.title('Сегментированное изображение')
    # plt.show()