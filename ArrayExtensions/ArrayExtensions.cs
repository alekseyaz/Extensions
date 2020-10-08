using System;

namespace Zaac.Extensions
{
    public static class ArrayExtensions
    {
        public static void Fill<T>(this T[] destinationArray, T value)
        {
            if (destinationArray == null) {
                throw new ArgumentNullException(nameof(destinationArray));
            }

            destinationArray[0] = value;
            FillInternal(destinationArray, 1);
        }

        public static void Fill<T>(this T[] destinationArray, T[] values)
        {
            if (destinationArray == null) {
                throw new ArgumentNullException(nameof(destinationArray));
            }

            var copyLength = values.Length;
            var destinationArrayLength = destinationArray.Length;

            if (copyLength == 0) {
                throw new ArgumentException("Параметр должен содержать хотя бы одно значение.", nameof(values));
            }

            if (copyLength > destinationArrayLength) {
                // значение для копирования длиннее, чем место назначения,
                // поэтому заполните место назначения первой частью значения
                Array.Copy(values, destinationArray, destinationArrayLength);
                return;
            }

            Array.Copy(values, destinationArray, copyLength);

            FillInternal(destinationArray, copyLength);
        }

        private static void FillInternal<T>(this T[] destinationArray, int copyLength)
        {
            var destinationArrayLength = destinationArray.Length;
            var destinationArrayHalfLength = destinationArrayLength / 2;

            // циклическое копирование от начала массива до текущей позиции,
            // удваивающее длину копии с каждым проходом
            for (; copyLength < destinationArrayHalfLength; copyLength *= 2) {
                Array.Copy(
                    sourceArray: destinationArray,
                    sourceIndex: 0,
                    destinationArray: destinationArray,
                    destinationIndex: copyLength,
                    length: copyLength);
            }

            // мы прошли половину пути, это означает, что остается только одна копия,
            // точно заполняющая остаток массива
            Array.Copy(
                sourceArray: destinationArray,
                sourceIndex: 0,
                destinationArray: destinationArray,
                destinationIndex: copyLength,
                length: destinationArrayLength - copyLength);
        }

        public static void BubbleSort(this int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length - 1; j++)
                    if (array[j] > array[j + 1])
                    {
                        int t = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = t;
                    }
        }

        private static void QuickSort(int[] arr, int depth, int range)
        {
            int i = depth;
            int j = range;
            int x = arr[(depth + range) / 2];
            while (i <= j)
            {
                while (arr[i] < x) i++;
                while (arr[j] > x) j--;
                if (i <= j)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            }
            if (depth < j) QuickSort(arr, depth, j);
            if (i < range) QuickSort(arr, i, range);
        }

        public static void QuickSort(this int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }

        private static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }

        private static int[] MergeSort(this int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }

        public static int[] MergeSort(this int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }
    }
}
