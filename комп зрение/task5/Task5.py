from scipy.ndimage import sobel
import numpy as np
import matplotlib.pyplot as plt
from PIL import Image


def get_grayscale_image(image_np):
    red_channel = image_np[:, :, 0]
    green_channel = image_np[:, :, 1]
    blue_channel = image_np[:, :, 2]
    grayscale_image = (red_channel // 3) + (green_channel // 3) + (blue_channel // 3)
    return grayscale_image


def gauss_filter(grayscale_image, sigma):
    kernel_size = 7
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


def fast_detector(image, t):
    h, w = image.shape
    keypoints = []

    for i in range(3, h - 3):
        for j in range(3, w - 3):
            center_pixel_value = image[i, j]

            # Проверяем сначала пиксели 1, 9 и 5, 13
            if (
                image[i - 1, j] > center_pixel_value + t and
                image[i + 1, j] > center_pixel_value + t and
                image[i - 1, j + 2] > center_pixel_value + t and
                image[i + 1, j - 2] > center_pixel_value + t
            ) or (
                image[i - 1, j] < center_pixel_value - t and
                image[i + 1, j] < center_pixel_value - t and
                image[i - 1, j + 2] < center_pixel_value - t and
                image[i + 1, j - 2] < center_pixel_value - t
            ):
                continue

            circle_points = [
                (i - 3, j), (i - 3, j + 1), (i - 2, j + 2), (i - 1, j + 3),
                (i, j + 3), (i + 1, j + 3), (i + 2, j + 2), (i + 3, j + 1),
                (i + 3, j), (i + 3, j - 1), (i + 2, j - 2), (i + 1, j - 3),
                (i, j - 3), (i - 1, j - 3), (i - 2, j - 2), (i - 3, j - 1)
            ]

            brighter = 0
            darker = 0

            for point in circle_points:
                value = image[point]
                if value > center_pixel_value + t:
                    brighter += 1
                    if brighter == 12:
                        keypoints.append((i, j))
                        break
                    darker = 0
                elif value < center_pixel_value - t:
                    darker += 1
                    if darker == 12:
                        keypoints.append((i, j))
                        break
                    brighter = 0 
                else:
                    brighter = 0
                    darker = 0

    return np.array(keypoints)


def harris_corner_detector(image, keypoints, threshold):
    k=0.04
    I_x = sobel(image, axis=1)
    I_y = sobel(image, axis=0)

    I_x_squared = gauss_filter(I_x**2, sigma=1)
    I_y_squared = gauss_filter(I_y**2, sigma=1)
    I_xy = gauss_filter(I_x * I_y, sigma=1)

    det_M = I_x_squared * I_y_squared - I_xy**2
    trace_M = I_x_squared + I_y_squared

    harris_values = det_M - k * (trace_M**2)
    selected_keypoints = keypoints[harris_values[keypoints[:, 0], keypoints[:, 1]] > threshold]
    return selected_keypoints


def compute_orientation(image, keypoints):
    orientations = np.arctan2(sobel(image, axis=0)[keypoints[:, 0], keypoints[:, 1]],
                              sobel(image, axis=1)[keypoints[:, 0], keypoints[:, 1]])
    return orientations


def brief_descriptor(image, keypoints, orientations, patch_size=31, n=256):
    descriptors = np.zeros((len(keypoints), n), dtype=np.uint8)

    for i, (x, y) in enumerate(keypoints):
        angle = orientations[i]

        pairs = np.random.randn(n, 2) * (patch_size**2 / 25)
        pairs = np.clip(pairs, -patch_size, patch_size)

        orientation_set = int((angle + np.pi) / (2 * np.pi / 30)) % 30
        pairs += np.array([[x, y]])
        pairs = np.clip(pairs, 0, image.shape[0] - 1)
        pairs = pairs.astype(int)

        for j in range(n):
            x1, y1 = pairs[j]
            x2, y2 = pairs[(j + 1) % n]

            if image[x1, y1] < image[x2, y2]:
                descriptors[i, j] = 1

    return descriptors


def visualize_orientations(image, keypoints, orientations):
    _, ax = plt.subplots(figsize=(10, 10))
    ax.imshow(image, cmap='gray')

    for i, j, angle in zip(keypoints[:, 0], keypoints[:, 1], orientations):
        dx = 8 * np.cos(angle)
        dy = 8 * np.sin(angle)
        ax.arrow(j, i, dx, dy, color='r', head_width=5, head_length=5)

    ax.set_title('Визуализация ориентаций')
    plt.show()


if __name__ == "__main__":
    image = np.array(Image.open('photo.png'))
    image = get_grayscale_image(image)
    threshold = 100
    t = 20

    keypoints = fast_detector(image, t)
    plt.imshow(image, cmap='gray')
    plt.scatter(keypoints[:, 1], keypoints[:, 0], c='r', marker='o', s=5)
    plt.title(f'FAST (t={t})')
    plt.show()

    harris_values = harris_corner_detector(image, keypoints, threshold)
    plt.imshow(image, cmap='gray')
    plt.scatter(harris_values[:, 1], harris_values[:, 0], c='r', marker='o', s=5)
    plt.title(f'Harris (threshold={threshold})')
    plt.show()

    orientations = compute_orientation(image, harris_values)
    # visualize_orientations(image, harris_values, orientations)

    descriptors = brief_descriptor(image, harris_values, orientations)
    np.savetxt('descriptors.txt', descriptors, fmt='%d')



