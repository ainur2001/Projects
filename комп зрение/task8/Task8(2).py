from sklearn.datasets import load_digits
import matplotlib.pyplot as plt
from sklearn.cluster import KMeans
from sklearn import metrics
from sklearn.preprocessing import scale

# Загрузка данных
digits = load_digits()

images=digits.images
plt.figure(figsize=(10,5))
plt.suptitle('Изображения цифр')
for i in range(10):
    plt.subplot(2,5,i+1), plt.title('image%i'%(i+1))
    plt.imshow(images[i], cmap="gray"), plt.axis('off')
plt.show()


# Стандартизация
data = scale(digits.data)


kmeans_vector = KMeans(n_clusters=10, random_state=0, n_init=10)
predicted_labels_vector = kmeans_vector.fit_predict(data)


confusion_matrix_vector = metrics.confusion_matrix(digits.target, predicted_labels_vector)
accuracy_vector = metrics.accuracy_score(digits.target, predicted_labels_vector)

print("Матрица ошибок:")
print(confusion_matrix_vector)
print("Точность: " + str(accuracy_vector * 100) + "%")