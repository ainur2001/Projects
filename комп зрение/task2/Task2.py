import numpy as np
from PIL import Image
import matplotlib.pyplot as plt

def get_grayscale_image(image_np):
    red_channel = image_np[:, :, 0]
    green_channel = image_np[:, :, 1]
    blue_channel = image_np[:, :, 2]
    grayscale_image = (red_channel // 3) + (green_channel // 3) + (blue_channel // 3)
    return grayscale_image


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


def remove_salt_and_pepper_noise_1(binary_image, kernel_size):
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


def remove_salt_and_pepper_noise_2(binary_image, kernel_size):
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
            if all(neighborhood):
                filtered_image_np[i, j] = 1
            elif not any(neighborhood):
                filtered_image_np[i, j] = 0
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


def histogram_binarization(image_np):
    gray_image = get_grayscale_image(image_np)
    histogram = np.histogram(gray_image, bins=256, range=(0, 256))[0]
    local_minima = []
    for i in range(1, 255):
        if histogram[i - 1] > histogram[i] and histogram[i] < histogram[i + 1]:
            local_minima.append(i)
    threshold = int(np.mean(local_minima))
    binary_image = (gray_image > threshold).astype(np.uint8) * 255
    return binary_image


if __name__ == "__main__":
    image = Image.open('photo.tif')
    image_np = np.array(image)

    binary_image_np1 = otsu_threshold(image_np)
    filtered_image_np1 = remove_salt_and_pepper_noise_2(binary_image_np1, 5)
    segmentated_image_np1 = segmentation(filtered_image_np1)
    colored_image_np1 = color_segments(segmentated_image_np1)
    
    
    binary_image_np2 = histogram_binarization(image_np)
    filtered_image_np2 = remove_salt_and_pepper_noise_2(binary_image_np2, 5)
    segmentated_image_np2 = segmentation(filtered_image_np2)
    colored_image_np2 = color_segments(segmentated_image_np2)


    plt.subplot(2, 5, 1)
    plt.imshow(image_np)
    plt.title('Исходное изображения')

    plt.subplot(2, 5, 2)
    plt.imshow(binary_image_np1, cmap="gray")
    plt.title('Бинарное изображения')

    plt.subplot(2, 5, 3)
    plt.imshow(filtered_image_np1, cmap="gray")
    plt.title('Соль и перец')

    plt.subplot(2, 5, 4)
    plt.imshow(segmentated_image_np1)
    plt.title('Выращивание семян')

    plt.subplot(2, 5, 5)
    plt.imshow(colored_image_np1)
    plt.title('Результат перовго метода')



    plt.subplot(2, 5, 6)
    plt.imshow(image_np)
    plt.title('Исходное изображения')

    plt.subplot(2, 5, 7)
    plt.imshow(binary_image_np2, cmap="gray")
    plt.title('Бинарное изображения')

    plt.subplot(2, 5, 8)
    plt.imshow(filtered_image_np2, cmap="gray")
    plt.title('Соль и перец')

    plt.subplot(2, 5, 9)
    plt.imshow(segmentated_image_np2)
    plt.title('Выращивание семян')

    plt.subplot(2, 5, 10)
    plt.imshow(colored_image_np2)
    plt.title('Результат второго метода')

    plt.show()