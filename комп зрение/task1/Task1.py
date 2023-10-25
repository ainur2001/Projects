import numpy as np
from PIL import Image
import matplotlib.pyplot as plt

image = Image.open('1234.png')
image_np = np.array(image)
plt.imshow(image_np)
plt.title('Исходное изображение')
plt.show()

# инвертирование изображения
inverted_image_np = 255 - image_np
plt.imshow(inverted_image_np)
plt.title('Инвертированное изображение')
plt.show()


# получение полутонового изображение
red_channel = image_np[:, :, 0]
green_channel = image_np[:, :, 1]
blue_channel = image_np[:, :, 2]
grayscale_image = (red_channel // 3) + (green_channel // 3) + (blue_channel // 3)

plt.imshow(grayscale_image, cmap="gray")
plt.title('Полутоновое изображение')
plt.show()


# параметры для шума
mean = 5  # среднее значение шума
dev = 10  # стандартное отклонение шума

# массив случайного шума с нормальным распределением
noise = np.random.normal(mean, dev, grayscale_image.shape)

# добавление шума
noisy_image = grayscale_image + noise
plt.imshow(noisy_image, cmap="gray")
plt.title('Изображение с шумом')
plt.show()


# гистограмма
histogram = np.histogram(noisy_image, bins=256, range=(0, 256))[0]
plt.bar(range(256), histogram)
plt.xlabel('Значение пикселя')
plt.ylabel('Частота')
plt.title('Гистограмма изображения с шумом')
plt.show()


# размытие Гаусса
height, width, color = image_np.shape

# параметры для размытия
kernel_size = 5
sigma = 2.0

kernel = np.fromfunction(
    lambda x, y: (1/ (2 * np.pi * sigma**2)) * np.exp(-((x - (kernel_size-1)/2)**2 + (y - (kernel_size-1)/2)**2) / (2 * sigma**2)), (kernel_size, kernel_size))

# нормализация 
kernel /= np.sum(kernel)

# применение размытия
blurred_image = np.zeros_like(image_np, dtype=float)
for c in range(color):
    for i in range(height - kernel_size + 1):
        for j in range(width - kernel_size + 1):
            square = image_np[i:i+kernel_size, j:j+kernel_size, c]
            blurred_image[i, j, c] = np.sum(square * kernel)

blurred_image = blurred_image.astype(np.uint8)

plt.imshow(blurred_image)
plt.title('Размытое изображение с использованием формулы Гаусса')
plt.show()


# разница между исходным и размытым изображением
sharp_mask = image_np - blurred_image
plt.imshow(sharp_mask)
plt.title('Разница между исходным и размытым изображением')
plt.show()


# эквализация
hist, bins = np.histogram(grayscale_image, bins=256, range=(0, 256))
cdf = hist.cumsum()
cdf_normalized = (cdf - cdf.min()) * 255 / (cdf.max() - cdf.min())
image_equalized = cdf_normalized[grayscale_image]


# показатели до эквализации
plt.subplot(221)
plt.imshow(grayscale_image, cmap="gray")
plt.title('Исходное изображение')

histogram = np.histogram(grayscale_image, bins=256, range=(0, 256))[0]
plt.subplot(222)
plt.bar(range(256), histogram)
plt.xlabel('Значение пикселя')
plt.ylabel('Частота')
plt.title('Гистограмма исходного изображения')


# показатели после эквализации
plt.subplot(223)
plt.imshow(image_equalized, cmap="gray")
plt.title('Эквализированное изображение')

histogram = np.histogram(image_equalized, bins=256, range=(0, 256))[0]
plt.subplot(224)
plt.bar(range(256), histogram)
plt.xlabel('Значение пикселя')
plt.ylabel('Частота')
plt.title('Гистограмма эквализированного изображения')

plt.tight_layout()
plt.show()