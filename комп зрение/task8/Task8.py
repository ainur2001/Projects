from sklearn.datasets import load_digits
from sklearn.metrics import accuracy_score, confusion_matrix
from sklearn.cluster import KMeans
from sklearn.preprocessing import MinMaxScaler
import matplotlib.pyplot as plt
import numpy as np


# Загрузка данных
digits = load_digits()
images=digits.images


# Нормализация
scaler = MinMaxScaler()
data_normalized = scaler.fit_transform(digits.data)


# Инициализация KMeans
kmeans = KMeans(n_clusters=10, random_state=0, n_init=10)


# Прогноз кластеров
clusters = kmeans.fit_predict(data_normalized)


# Поиск доминирующих меток в каждом кластере
labels = np.zeros_like(clusters)
for i in range(10):
    mask = (clusters == i)
    labels[mask] = np.bincount(digits.target[mask]).argmax()


# Подсчет матрицы ошибок и точности
accuracy = accuracy_score(digits.target, labels)
confusion_mat = confusion_matrix(digits.target, labels)


# Вывод результатов
print("Матрица ошибок:")
print(confusion_mat)

print("Точность:")
print(round(accuracy * 100, 2), end="%")