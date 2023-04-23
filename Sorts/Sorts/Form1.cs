using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sorts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Begin_TextBox.Text = "1000";
            End_TextBox.Text = "10000";
            Step_TextBox.Text = "1000";
            TypeData_ComboBox.SelectedIndex = 0;
        }

        private void Sort_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (CountData_TextBox.Text == "") throw new ArgumentException("Необходимо заполнить поля!");
                string typeSort = TypeSort_ComboBox.Text;
                int countData = int.Parse(CountData_TextBox.Text);
                string typeData = TypeData_ComboBox.Text;
                Stopwatch stopwatch = new Stopwatch();
                dynamic array = 0;

                if (typeData == "массив чисел(double)") array = GenerateRandomArray<double>(countData);
                else if (typeData == "массив чисел(int)") array = GenerateRandomArray<int>(countData);
                else if (typeData == "массив строк(string)") array = GenerateRandomArray<string>(countData);
                else if (typeData == "массив дат(DateTime)") array = GenerateRandomArray<DateTime>(countData);

                stopwatch.Start();

                if (typeSort == "Сортировка вставкой") InsertionSort(array);
                else if (typeSort == "Сортировка пузырьком") BubbleSort(array);
                else if (typeSort == "Сортировка выбором") SelectionSort(array);
                else if (typeSort == "Сортировка Шелла") ShellSort(array);
                else if (typeSort == "Быстрая сортировка") QuickSort(array);
                else if (typeSort == "Сортировка слиянием") MergeSort(array);
                else if (typeSort == "Сортировка кучей") HeapSort(array);
                else if (typeSort == "Встроенная сортировка") Array.Sort(array);
                else if (typeSort == "Пирамидальная сортировка") PyramidSort(array);

                stopwatch.Stop();
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

            for (int i = (heapSize / 2) - 1; i >= 0; i--)
            {
                Heapify(array, heapSize, i);
            }


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
        private static void PyramidSort<T>(T[] arr) where T : IComparable<T>
        {
            int n = arr.Length;

            // Build max heap
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            // Extract elements from heap in sorted order
            for (int i = n - 1; i >= 0; i--)
            {
                // Swap root and last element
                T temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // Heapify reduced heap
                Heapify(arr, i, 0);
            }
        }
        private static void HeapifyForPyramid<T>(T[] arr, int n, int i) where T : IComparable<T>
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[left].CompareTo(arr[largest]) > 0)
            {
                largest = left;
            }

            if (right < n && arr[right].CompareTo(arr[largest]) > 0)
            {
                largest = right;
            }

            if (largest != i)
            {
                // Swap elements
                T temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;

                // Recursively heapify sub-tree
                Heapify(arr, n, largest);
            }
        }
        private void DrawGraphic_Button_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
            chart1.Series[4].Points.Clear();
            chart1.Series[5].Points.Clear();
            chart1.Series[6].Points.Clear();
            chart1.Series[7].Points.Clear();

            int begin = int.Parse(Begin_TextBox.Text), end = int.Parse(End_TextBox.Text), step = int.Parse(Step_TextBox.Text);
            if (begin > end)
            {
                MessageBox.Show("Данные не корректны!");
                return;
            }
            for (int countData = begin; countData <= end; countData+=step)
            {
                string typeData = TypeData_ComboBox.Text;
                dynamic array = 0;
                if (typeData == "массив чисел(double)") array = GenerateRandomArray<double>(countData);
                else if (typeData == "массив чисел(int)") array = GenerateRandomArray<int>(countData);
                else if (typeData == "массив строк(string)") array = GenerateRandomArray<string>(countData);
                else if (typeData == "массив дат(DateTime)") array = GenerateRandomArray<DateTime>(countData);


                Stopwatch stopwatchInsertionSort = new Stopwatch();
                Stopwatch stopwatchBubbleSort = new Stopwatch();
                Stopwatch stopwatchSelectionSort = new Stopwatch();
                Stopwatch stopwatchShellSort = new Stopwatch();
                Stopwatch stopwatchQuickSort = new Stopwatch();
                Stopwatch stopwatchMergeSort = new Stopwatch();
                Stopwatch stopwatchHeapSort = new Stopwatch();
                Stopwatch stopwatchIncludeSort = new Stopwatch();


                /*double[] arrayDouble = GenerateRandomArray<double>(countData);
                int[] arrayInt = GenerateRandomArray<int>(countData);
                string[] arrayString = GenerateRandomArray<string>(countData);
                DateTime[] arrayDateTime = GenerateRandomArray<DateTime>(countData);

               if (typeSort == "Сортировка вставкой")
                {
                    stopwatchDouble.Start();
                    InsertionSort(arrayDouble);
                    stopwatchDouble.Stop();

                    stopwatchInt.Start();
                    InsertionSort(arrayInt);
                    stopwatchInt.Stop();

                    stopwatchString.Start();
                    InsertionSort(arrayString);
                    stopwatchString.Stop();

                    stopwatchDateTime.Start();
                    InsertionSort(arrayDateTime);
                    stopwatchDateTime.Stop();
                }
                else if (typeSort == "Сортировка выбором")
                {
                    stopwatchDouble.Start();
                    SelectionSort(arrayDouble);
                    stopwatchDouble.Stop();

                    stopwatchInt.Start();
                    SelectionSort(arrayInt);
                    stopwatchInt.Stop();

                    stopwatchString.Start();
                    SelectionSort(arrayString);
                    stopwatchString.Stop();

                    stopwatchDateTime.Start();
                    SelectionSort(arrayDateTime);
                    stopwatchDateTime.Stop();
                }
                else if (typeSort == "Сортировка пузырьком")
                {
                    stopwatchDouble.Start();
                    BubbleSort(arrayDouble);
                    stopwatchDouble.Stop();

                    stopwatchInt.Start();
                    BubbleSort(arrayInt);
                    stopwatchInt.Stop();

                    stopwatchString.Start();
                    BubbleSort(arrayString);
                    stopwatchString.Stop();

                    stopwatchDateTime.Start();
                    BubbleSort(arrayDateTime);
                    stopwatchDateTime.Stop();
                }
                else if (typeSort == "Сортировка Шелла")
                {
                    stopwatchDouble.Start();
                    ShellSort(arrayDouble);
                    stopwatchDouble.Stop();

                    stopwatchInt.Start();
                    ShellSort(arrayInt);
                    stopwatchInt.Stop();

                    stopwatchString.Start();
                    ShellSort(arrayString);
                    stopwatchString.Stop();

                    stopwatchDateTime.Start();
                    ShellSort(arrayDateTime);
                    stopwatchDateTime.Stop();
                }
                else if (typeSort == "Быстрая сортировка")
                {
                    stopwatchDouble.Start();
                    QuickSort(arrayDouble);
                    stopwatchDouble.Stop();

                    stopwatchInt.Start();
                    QuickSort(arrayInt);
                    stopwatchInt.Stop();

                    stopwatchString.Start();
                    QuickSort(arrayString);
                    stopwatchString.Stop();

                    stopwatchDateTime.Start();
                    QuickSort(arrayDateTime);
                    stopwatchDateTime.Stop();
                }
                else if (typeSort == "Сортировка слиянием")
                {
                    stopwatchDouble.Start();
                    MergeSort(arrayDouble);
                    stopwatchDouble.Stop();

                    stopwatchInt.Start();
                    MergeSort(arrayInt);
                    stopwatchInt.Stop();

                    stopwatchString.Start();
                    MergeSort(arrayString);
                    stopwatchString.Stop();

                    stopwatchDateTime.Start();
                    MergeSort(arrayDateTime);
                    stopwatchDateTime.Stop();
                }
                else if (typeSort == "Сортировка кучей")
                {
                    stopwatchDouble.Start();
                    HeapSort(arrayDouble);
                    stopwatchDouble.Stop();

                    stopwatchInt.Start();
                    HeapSort(arrayInt);
                    stopwatchInt.Stop();

                    stopwatchString.Start();
                    HeapSort(arrayString);
                    stopwatchString.Stop();

                    stopwatchDateTime.Start();
                    HeapSort(arrayDateTime);
                    stopwatchDateTime.Stop();
                }
                else if (typeSort == "Встроенная сортировка")
                {
                    stopwatchDouble.Start();
                    Array.Sort(arrayDouble);
                    stopwatchDouble.Stop();

                    stopwatchInt.Start();
                    Array.Sort(arrayInt);
                    stopwatchInt.Stop();

                    stopwatchString.Start();
                    Array.Sort(arrayString);
                    stopwatchString.Stop();

                    stopwatchDateTime.Start();
                    Array.Sort(arrayDateTime);
                    stopwatchDateTime.Stop();
                }*/


                stopwatchInsertionSort.Start();
                InsertionSort(array);
                stopwatchInsertionSort.Stop();


                stopwatchBubbleSort.Start();
                BubbleSort(array);
                stopwatchBubbleSort.Stop();

                stopwatchSelectionSort.Start();
                SelectionSort(array);
                stopwatchSelectionSort.Stop();

                /*stopwatchShellSort.Start();
                ShellSort(array);
                stopwatchShellSort.Stop();

                stopwatchQuickSort.Start();
                QuickSort(array);
                stopwatchQuickSort.Stop();

                stopwatchMergeSort.Start();
                MergeSort(array);
                stopwatchMergeSort.Stop();

                stopwatchHeapSort.Start();
                HeapSort(array);
                stopwatchHeapSort.Stop();

                stopwatchIncludeSort.Start();
                Array.Sort(array);
                stopwatchIncludeSort.Stop();*/


                chart1.Series[0].Points.AddXY(countData, stopwatchInsertionSort.ElapsedMilliseconds);
                chart1.Series[1].Points.AddXY(countData, stopwatchBubbleSort.ElapsedMilliseconds);
                chart1.Series[2].Points.AddXY(countData, stopwatchSelectionSort.ElapsedMilliseconds);
                //chart1.Series[3].Points.AddXY(countData, stopwatchShellSort.ElapsedMilliseconds);
                //chart1.Series[4].Points.AddXY(countData, stopwatchQuickSort.ElapsedMilliseconds);
                //chart1.Series[5].Points.AddXY(countData, stopwatchMergeSort.ElapsedMilliseconds);
                //chart1.Series[6].Points.AddXY(countData, stopwatchHeapSort.ElapsedMilliseconds);
                //chart1.Series[7].Points.AddXY(countData, stopwatchIncludeSort.ElapsedMilliseconds);
            }
        }
    }
}
