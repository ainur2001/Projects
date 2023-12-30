import torch
import torch.nn as nn
import torch.optim as optim
from torch.utils.data import DataLoader
from sklearn.datasets import load_digits
from sklearn.preprocessing import StandardScaler
from sklearn.model_selection import train_test_split
from sklearn.metrics import accuracy_score, confusion_matrix

digits = load_digits()
X = digits.data
y = digits.target

# Нормализация
scaler = StandardScaler()
X_normalized = scaler.fit_transform(X)

# Разделение на обучающую, валидационную и тестовую выборки
X_train, X_temp, y_train, y_temp = train_test_split(X_normalized, y, test_size=0.4, random_state=42) 
X_val, X_test, y_val, y_test = train_test_split(X_temp, y_temp, test_size=0.5, random_state=42) 

# Преобразование данных в тензоры PyTorch
X_train = torch.tensor(X_train, dtype=torch.float32).view(-1, 1, 8, 8)
y_train = torch.tensor(y_train, dtype=torch.long)
X_val = torch.tensor(X_val, dtype=torch.float32).view(-1, 1, 8, 8)
y_val = torch.tensor(y_val, dtype=torch.long)
X_test = torch.tensor(X_test, dtype=torch.float32).view(-1, 1, 8, 8)
y_test = torch.tensor(y_test, dtype=torch.long)

class SimpleVGG(nn.Module):
    def __init__(self):
        super(SimpleVGG, self).__init__()
        self.conv1 = nn.Conv2d(1, 8, kernel_size=3, padding=1)
        self.conv2 = nn.Conv2d(8, 8, kernel_size=3, padding=1)
        self.pool1 = nn.MaxPool2d(kernel_size=2, stride=2) # Пулинг, уменьшение размера до 2x2
        self.conv3 = nn.Conv2d(8, 10, kernel_size=3, padding=1)
        self.conv4 = nn.Conv2d(10, 16, kernel_size=3, padding=1)
        self.pool2 = nn.MaxPool2d(kernel_size=2, stride=2) # Пулинг, уменьшение размера до 2x2
        self.fc1 = nn.Linear(16 * 2 * 2, 100)
        self.fc2 = nn.Linear(100, 10)

    def forward(self, x):
        x = self.pool1(nn.functional.relu(self.conv2(nn.functional.relu(self.conv1(x)))))
        x = self.pool2(nn.functional.relu(self.conv4(nn.functional.relu(self.conv3(x)))))
        x = x.view(-1, 16 * 2 * 2)
        x = nn.functional.relu(self.fc1(x))
        x = self.fc2(x)
        return x

# Создание DataLoader
train_dataset = torch.utils.data.TensorDataset(X_train, y_train)
val_dataset = torch.utils.data.TensorDataset(X_val, y_val)
test_dataset = torch.utils.data.TensorDataset(X_test, y_test)

train_loader = DataLoader(train_dataset, batch_size=64, shuffle=True)
val_loader = DataLoader(val_dataset, batch_size=64)
test_loader = DataLoader(test_dataset, batch_size=64)

# Инициализация модели, функции потерь и оптимизатора
model = SimpleVGG()
criterion = nn.CrossEntropyLoss()
optimizer = optim.Adam(model.parameters(), lr=0.001)

# Обучение модели
num_epochs = 20

for epoch in range(num_epochs):
    model.train()
    for inputs, labels in train_loader:
        optimizer.zero_grad()
        outputs = model(inputs)
        loss = criterion(outputs, labels)
        loss.backward()
        optimizer.step()


model.eval()
with torch.no_grad():
    test_outputs = model(X_test)
    test_accuracy = accuracy_score(y_test.numpy(), torch.argmax(test_outputs, axis=1).numpy())
    conf_matrix = confusion_matrix(y_test.numpy(), torch.argmax(test_outputs, axis=1).numpy())

print(f'Точность по тестовой выборке: {test_accuracy:.4f}')
print('Матрица ошибок:')
print(conf_matrix)
