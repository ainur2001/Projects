using System;
using System.Diagnostics;

namespace ComparisonOfSorts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TypeSort_ComboBox.SelectedIndex = 0;
            TypeData_ComboBox.SelectedIndex = 0;
        }

        private void Sort_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (CountData_TextBox.Text == "") throw new ArgumentException("Необходимо заполнить поля!");
                string TypeSort = TypeSort_ComboBox.Text;
                int countData = int.Parse(CountData_TextBox.Text);
                string typeData = TypeData_ComboBox.Text;
                Stopwatch stopwatch = new();

                switch (TypeSort)
                {
                    case "Сортировка вставкой":

                        if (typeData == "массив чисел(double)")
                        {
                            double[] array = GenerateRandomArray<double>(countData);
                            stopwatch.Start();
                            InsertionSort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив чисел(int)")
                        {
                            int[] array = GenerateRandomArray<int>(countData);
                            stopwatch.Start();
                            InsertionSort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив строк(string)")
                        {
                            string[] array = GenerateRandomArray<string>(countData);
                            stopwatch.Start();
                            InsertionSort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив дат(DateTime)")
                        {
                            DateTime[] array = GenerateRandomArray<DateTime>(countData);
                            stopwatch.Start();
                            InsertionSort(array);
                            stopwatch.Stop();
                        }
                        break;

                    case "Сортировка пузырьком":
                        if (typeData == "массив чисел(double)")
                        {
                            double[] array = GenerateRandomArray<double>(countData);
                            stopwatch.Start();
                            BubbleSort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив чисел(int)")
                        {
                            int[] array = GenerateRandomArray<int>(countData);
                            stopwatch.Start();
                            BubbleSort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив строк(string)")
                        {
                            string[] array = GenerateRandomArray<string>(countData);
                            stopwatch.Start();
                            BubbleSort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив дат(DateTime)")
                        {
                            DateTime[] array = GenerateRandomArray<DateTime>(countData);
                            stopwatch.Start();
                            BubbleSort(array);
                            stopwatch.Stop();
                        }
                        break;

                    case "Сортировка выбором":
                        if (typeData == "массив чисел(double)")
                        {
                            double[] array = GenerateRandomArray<double>(countData);
                            stopwatch.Start();
                            SelectionSort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив чисел(int)")
                        {
                            int[] array = GenerateRandomArray<int>(countData);
                            stopwatch.Start();
                            SelectionSort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив строк(string)")
                        {
                            string[] array = GenerateRandomArray<string>(countData);
                            stopwatch.Start();
                            SelectionSort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив дат(DateTime)")
                        {
                            DateTime[] array = GenerateRandomArray<DateTime>(countData);
                            stopwatch.Start();
                            SelectionSort(array);
                            stopwatch.Stop();
                        }
                        break;

                    case "Сортировка Шелла":
                        if (typeData == "массив чисел(double)")
                        {
                            double[] array = GenerateRandomArray<double>(countData);
                            stopwatch.Start();
                            ShellSort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив чисел(int)")
                        {
                            int[] array = GenerateRandomArray<int>(countData);
                            stopwatch.Start();
                            ShellSort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив строк(string)")
                        {
                            string[] array = GenerateRandomArray<string>(countData);
                            stopwatch.Start();
                            ShellSort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив дат(DateTime)")
                        {
                            DateTime[] array = GenerateRandomArray<DateTime>(countData);
                            stopwatch.Start();
                            ShellSort(array);
                            stopwatch.Stop();
                        }
                        break;

                    case "Быстрая сортировка":
                        if (typeData == "массив чисел(double)")
                        {
                            double[] array = GenerateRandomArray<double>(countData);
                            stopwatch.Start();
                            QuickSort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив чисел(int)")
                        {
                            int[] array = GenerateRandomArray<int>(countData);
                            stopwatch.Start();
                            QuickSort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив строк(string)")
                        {
                            string[] array = GenerateRandomArray<string>(countData);
                            stopwatch.Start();
                            QuickSort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив дат(DateTime)")
                        {
                            DateTime[] array = GenerateRandomArray<DateTime>(countData);
                            stopwatch.Start();
                            QuickSort(array);
                            stopwatch.Stop();
                        }
                        break;

                    case "Сортировка слиянием":
                        if (typeData == "массив чисел(double)")
                        {
                            double[] array = GenerateRandomArray<double>(countData);
                            stopwatch.Start();
                            MergeSort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив чисел(int)")
                        {
                            int[] array = GenerateRandomArray<int>(countData);
                            stopwatch.Start();
                            MergeSort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив строк(string)")
                        {
                            string[] array = GenerateRandomArray<string>(countData);
                            stopwatch.Start();
                            MergeSort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив дат(DateTime)")
                        {
                            DateTime[] array = GenerateRandomArray<DateTime>(countData);
                            stopwatch.Start();
                            MergeSort(array);
                            stopwatch.Stop();
                        }
                        break;

                    case "Сортировка кучей":
                        if (typeData == "массив чисел(double)")
                        {
                            double[] array = GenerateRandomArray<double>(countData);
                            stopwatch.Start();
                            HeapSort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив чисел(int)")
                        {
                            int[] array = GenerateRandomArray<int>(countData);
                            stopwatch.Start();
                            HeapSort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив строк(string)")
                        {
                            string[] array = GenerateRandomArray<string>(countData);
                            stopwatch.Start();
                            HeapSort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив дат(DateTime)")
                        {
                            DateTime[] array = GenerateRandomArray<DateTime>(countData);
                            stopwatch.Start();
                            HeapSort(array);
                            stopwatch.Stop();
                        }
                        break;

                    case "Встроенная сортировка":
                        if (typeData == "массив чисел(double)")
                        {
                            double[] array = GenerateRandomArray<double>(countData);
                            stopwatch.Start();
                            Array.Sort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив чисел(int)")
                        {
                            int[] array = GenerateRandomArray<int>(countData);
                            stopwatch.Start();
                            Array.Sort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив строк(string)")
                        {
                            string[] array = GenerateRandomArray<string>(countData);
                            stopwatch.Start();
                            Array.Sort(array);
                            stopwatch.Stop();
                        }
                        else if (typeData == "массив дат(DateTime)")
                        {
                            DateTime[] array = GenerateRandomArray<DateTime>(countData);
                            stopwatch.Start();
                            Array.Sort(array);
                            stopwatch.Stop();
                        }
                        break;

                }
                TimeSort_TextBox.Text = stopwatch.ElapsedMilliseconds.ToString() + "ms.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void InsertionSort<T>(T[] arr) where T : IComparable<T>
        {
            for (int i = 1; i < arr.Length; i++)
            {
                T key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j].CompareTo(key) > 0)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }
        private static void BubbleSort<T>(T[] array) where T : IComparable
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
        private static void SelectionSort<T>(T[] array) where T : IComparable
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (array[j].CompareTo(array[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    T temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                }
            }
        }
        private static void ShellSort<T>(T[] array) where T : IComparable<T>
        {
            int n = array.Length;
            int h = 1;
            while (h < n / 3)
                h = 3 * h + 1;
            while (h >= 1)
            {
                for (int i = h; i < n; i++)
                {
                    for (int j = i; j >= h && array[j].CompareTo(array[j - h]) < 0; j -= h)
                    {
                        T temp = array[j];
                        array[j] = array[j - h];
                        array[j - h] = temp;
                    }
                }
                h /= 3;
            }
        }
        private static void QuickSort<T>(T[] arr) where T : IComparable<T>
        {
            if (arr == null || arr.Length == 0)
                return;

            int left = 0, right = arr.Length - 1;
            QuickSortRecursive(arr, left, right);
        }
        private static void QuickSortRecursive<T>(T[] arr, int left, int right) where T : IComparable<T>
        {
            if (left >= right)
                return;

            T pivot = arr[left + (right - left) / 2];
            int partitionIndex = Partition(arr, left, right, pivot);

            QuickSortRecursive(arr, left, partitionIndex - 1);
            QuickSortRecursive(arr, partitionIndex, right);
        }
        private static int Partition<T>(T[] arr, int left, int right, T pivot) where T : IComparable<T>
        {
            while (left <= right)
            {
                while (arr[left].CompareTo(pivot) < 0)
                    left++;

                while (arr[right].CompareTo(pivot) > 0)
                    right--;

                if (left <= right)
                {
                    T temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;

                    left++;
                    right--;
                }
            }

            return left;
        }
        private static void MergeSort<T>(T[] array) where T : IComparable<T>
        {
            if (array == null || array.Length <= 1)
                return;

            int n = array.Length;
            int mid = n / 2;
            T[] left = new T[mid];
            T[] right = new T[n - mid];

            for (int i = 0; i < mid; i++)
                left[i] = array[i];
            for (int i = mid; i < n; i++)
                right[i - mid] = array[i];

            MergeSort(left);
            MergeSort(right);

            int j = 0, k = 0;
            for (int i = 0; i < n; i++)
            {
                if (j >= left.Length)
                    array[i] = right[k++];
                else if (k >= right.Length)
                    array[i] = left[j++];
                else if (left[j].CompareTo(right[k]) <= 0)
                    array[i] = left[j++];
                else
                    array[i] = right[k++];
            }
        }
        public static void HeapSort<T>(T[] array) where T : IComparable<T>
        {
            int heapSize = array.Length;

            // Build the heap
            for (int i = (heapSize / 2) - 1; i >= 0; i--)
            {
                Heapify(array, heapSize, i);
            }

            // Extract elements from the heap in sorted order
            for (int i = heapSize - 1; i >= 1; i--)
            {
                Swap(array, i, 0);
                heapSize--;
                Heapify(array, heapSize, 0);
            }
        }
        private static void Heapify<T>(T[] array, int heapSize, int index) where T : IComparable<T>
        {
            int largest = index;
            int leftChild = (index * 2) + 1;
            int rightChild = (index * 2) + 2;

            if (leftChild < heapSize && array[leftChild].CompareTo(array[largest]) > 0)
            {
                largest = leftChild;
            }

            if (rightChild < heapSize && array[rightChild].CompareTo(array[largest]) > 0)
            {
                largest = rightChild;
            }

            if (largest != index)
            {
                Swap(array, index, largest);
                Heapify(array, heapSize, largest);
            }
        }
        private static void Swap<T>(T[] array, int index1, int index2)
        {
            T temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
        private static T[] GenerateRandomArray<T>(int length)
        {
            Random random = new Random();
            T[] arr = new T[length];
            if (typeof(T) == typeof(int))
            {
                for (int i = 0; i < length; i++)
                {
                    arr[i] = (T)(object)random.Next();
                }
            }
            else if (typeof(T) == typeof(double))
            {
                for (int i = 0; i < length; i++)
                {
                    arr[i] = (T)(object)random.NextDouble();
                }
            }
            else if (typeof(T) == typeof(string))
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                for (int i = 0; i < length; i++)
                {
                    arr[i] = (T)(object)new string(Enumerable.Repeat(chars, 10)
                      .Select(s => s[random.Next(s.Length)]).ToArray());
                }
            }
            else if (typeof(T) == typeof(DateTime))
            {
                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Today - start).Days;
                for (int i = 0; i < length; i++)
                {
                    arr[i] = (T)(object)start.AddDays(random.Next(range));
                }
            }
            return arr;
        }
    }
}