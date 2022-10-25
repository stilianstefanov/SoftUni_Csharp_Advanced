using System;
using System.Linq;

namespace _05.Merge_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] sorted = MergeSorter<int>.MergeSort(input);
            Console.WriteLine(string.Join(" ", sorted));
        }
    }

    class MergeSorter<T> where T : IComparable<T>
    {
        public static T[] MergeSort(T[] inputArr)
        {
            if (inputArr.Length == 1)
            {
                return inputArr;
            }

            int middle = inputArr.Length / 2;

            T[] leftArr = PopulateArr(inputArr, 0, middle);
            T[] rightArr = PopulateArr(inputArr, middle, inputArr.Length);

            return MergeArrays(MergeSort(leftArr), MergeSort(rightArr));
        }

        public static T[] MergeArrays(T[] leftArr, T[] rightArr)
        {
            T[] result = new T[leftArr.Length + rightArr.Length];
            int index = 0;
            int leftIndex = 0;
            int rightIndex = 0;

            while (true)
            {
                if (leftIndex < leftArr.Length && rightIndex < rightArr.Length)
                {
                    if (leftArr[leftIndex].CompareTo(rightArr[rightIndex]) == -1)
                    {
                        result[index++] = leftArr[leftIndex++];
                    }
                    else
                    {
                        result[index++] = rightArr[rightIndex++];
                    }
                }
                else if (leftIndex < leftArr.Length)
                {
                    result[index++] = leftArr[leftIndex++];
                }
                else if (rightIndex < rightArr.Length)
                {
                    result[index++] = rightArr[rightIndex++];
                }
                else
                {
                    return result;
                }
            }

        }

        private static T[] PopulateArr(T[] inputArr, int start, int end)
        {
            T[] resultArr = new T[end - start];

            for (int i = 0; i < resultArr.Length; i++)
            {
                resultArr[i] = inputArr[start + i];
            }

            return resultArr;
        }
    }
}
