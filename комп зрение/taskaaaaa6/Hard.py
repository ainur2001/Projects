import math
import numpy as np
from PIL import Image
import matplotlib.pyplot as plt
from scipy.ndimage import sobel
from scipy.ndimage import convolve


from skimage.feature import match_descriptors



def to_gray(image):
    return np.dot(image[...,:3], [0.299, 0.587, 0.114]).astype(np.uint8)

def gauss_filter(image, sigma):
    kernel_size = 7
    kernel = np.fromfunction(
        lambda x, y: (1 / (2 * np.pi * sigma**2)) * np.exp(-((x - (kernel_size - 1) / 2)**2 + (y - (kernel_size - 1) / 2)**2) / (2 * sigma**2)),
        (kernel_size, kernel_size)
    )
    kernel /= np.sum(kernel)

    return convolve(image, kernel)

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
    k = 0.04
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

def generate_brief_pairs(n, p, seed=0):
    np.random.seed(seed)
    pairs = np.random.normal(0, (p**2)/25, (n, 2, 2))
    return pairs

def brief_descriptor(image, keypoints, patch_size=31, n=256):
    descriptors = np.zeros((len(keypoints), n), dtype=np.uint8)
    orientations = np.zeros(len(keypoints), dtype=float)

    for i, (x, y) in enumerate(keypoints):
        pairs = generate_brief_pairs(n, patch_size)
        pairs += np.array([[x, y]])
        pairs = np.clip(pairs, 0, image.shape[0] - 1)
        pairs = pairs.astype(int)

        # Вычисление направления ключевой точки
        gradient_x = sobel(image, axis=1)[x, y]
        gradient_y = sobel(image, axis=0)[x, y]
        orientation = np.arctan2(gradient_y, gradient_x)

        for j in range(n):
            x1, y1 = pairs[j, 0]
            x2, y2 = pairs[j, 1]

            if image[x1, y1] < image[x2, y2]:
                descriptors[i, j] = 1

        orientations[i] = orientation

    return descriptors, orientations


def visualize_keypoints(image, keypoints, title):
    plt.figure(figsize=(8, 8))
    plt.imshow(image, cmap='gray')
    plt.scatter(keypoints[:, 1], keypoints[:, 0], s=30, c='r', marker='o', edgecolors='k')
    plt.title(title)
    plt.show()


def visualize_brief_descriptor_with_orientation(image, keypoints, descriptors, orientations, title):
    plt.figure(figsize=(8, 8))
    plt.imshow(image, cmap='gray')
    plt.scatter(keypoints[:, 1], keypoints[:, 0], s=30, c='r', marker='o', edgecolors='k')
    plt.title(title)

    for i, (x, y) in enumerate(keypoints):
        for j in range(descriptors.shape[1]):
            if descriptors[i, j] == 1:
                angle = orientations[i] 
                plt.arrow(y, x, 10 * np.cos(angle), 10 * np.sin(angle), color='g')

    plt.show()


def ORB(image, threshold, t, patch_size, n_pairs):
    keypoints = fast_detector(image, t)
    #visualize_keypoints(image, keypoints, 'Fast Keypoints')

    harris_keypoints = harris_corner_detector(image, keypoints, threshold)
    #visualize_keypoints(image, harris_keypoints, 'Harris Keypoints')

    descriptors, orientations = brief_descriptor(image, harris_keypoints, patch_size, n_pairs)

    return descriptors, orientations, harris_keypoints



def match_keypoints(descriptors1, descriptors2):
    matches = match_descriptors(descriptors1, descriptors2, cross_check=True)

    return matches

def get_good_matches(keypoints1, keypoints2, matches):
    good_matches = []
    for match in matches:
        query_idx, train_idx = match
        good_matches.append((keypoints1[query_idx], keypoints2[train_idx]))

    return good_matches


def visualize_matches(image1, image2, keypoints1, keypoints2, matches, orientations1, title):
    offset = image1.shape[1]

    max_height = max(image1.shape[0], image2.shape[0])
    combined_image = np.zeros((max_height, image1.shape[1] + image2.shape[1]), dtype=np.uint8)

    combined_image[:image1.shape[0], :image1.shape[1]] = image1
    combined_image[:image2.shape[0], image1.shape[1]:] = image2

    fig, ax = plt.subplots(nrows=1, ncols=1, figsize=(12, 6))
    ax.imshow(combined_image, cmap='gray')

    good_matches_color = plt.cm.get_cmap('hsv', len(matches))

    for i, match in enumerate(matches):
        keypoint1, keypoint2 = match
        color = good_matches_color(i)

        # Проверяем, что у нас есть угол для этой точки
        index1 = np.where((keypoints1[:, 0] == keypoint1[0]) & (keypoints1[:, 1] == keypoint1[1]))[0][0]
        angle1 = orientations1[index1]
        x1_rot = keypoint1[1] + 10 * np.cos(angle1)
        y1_rot = keypoint1[0] + 10 * np.sin(angle1)

        ax.plot([x1_rot, keypoint2[1] + offset], [y1_rot, keypoint2[0]], color=color, linestyle='-', linewidth=1)

    ax.scatter(keypoints1[:, 1], keypoints1[:, 0], s=30, c='r', marker='o', edgecolors='k')
    ax.scatter(keypoints2[:, 1] + offset, keypoints2[:, 0], s=30, c='r', marker='o', edgecolors='k')

    plt.title(title)
    plt.show()




if __name__ == "__main__":
    image1 = np.array(Image.open('box.png'))
    image2 = np.array(Image.open('box_in_scene.png'))
    threshold = 200 
    t=40
    patch_size=31
    n_pairs=256

    descriptors1, orientations1, keypoints1 = ORB(image1, threshold, t, patch_size, n_pairs)
    descriptors2, orientations2, keypoints2 = ORB(image2, threshold, t, patch_size, n_pairs)
    #visualize_brief_descriptor_with_orientation(image1, keypoints1, descriptors1, orientations1, "Ключевые точки и их направление")
    #visualize_brief_descriptor_with_orientation(image2, keypoints2, descriptors2, orientations2, "Ключевые точки и их направление")

    matches = match_keypoints(descriptors1, descriptors2)
    good_matches = get_good_matches(keypoints1, keypoints2, matches)

    visualize_matches(image1, image2, keypoints1, keypoints2, good_matches, orientations1, "Сопоставление ORB")