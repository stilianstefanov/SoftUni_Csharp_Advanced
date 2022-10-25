using System;
using System.Linq;

namespace _07.Binary_Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int searchedItem = int.Parse(Console.ReadLine());
            Array.Sort(input);

            int indexOfItem = BinarySearch<int>.IndexOf(input, searchedItem);
            Console.WriteLine(indexOfItem);
        }
    }

    public class BinarySearch<T> where T : IComparable<T>
    {
        public static int IndexOf(T[] arr, T key)
        {
            int lo = 0;
            int hi = arr.Length - 1;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (key.CompareTo(arr[mid]) == -1)
                {
                    hi = mid - 1;
                }
                else if (key.CompareTo(arr[mid]) == 1)
                {
                    lo = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }
    }
}
