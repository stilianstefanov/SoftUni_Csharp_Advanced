using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace GenericBoxofString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int inputCnt = int.Parse(Console.ReadLine());

            List<Box<int>> list = new List<Box<int>>();

            for (int i = 0; i < inputCnt; i++)
            {
                string input = Console.ReadLine();

                Box<int> box = new Box<int>(int.Parse(input));

                list.Add(box);
            }

            int[] indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            Swap(firstIndex, secondIndex, list);

            foreach (var box in list)
            {
                Console.WriteLine(box);
            }
        }
        public static void Swap<T> (int firstIndex, int secondIndex, List<T> list)
        {
            T temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }
      
    }
}
