using System;
using System.Linq;

namespace _06.Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());

            int[][] jaggedArr = new int[rowsCount][];

            for (int row = 0; row < rowsCount; row++)
            {
                int[] curRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jaggedArr[row] = new int[curRow.Length];

                for (int col = 0; col < curRow.Length; col++)
                {
                    jaggedArr[row][col] = curRow[col];
                }
            }

            AnalyzeArr(jaggedArr);

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "End")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (row >= 0 && row < jaggedArr.GetLength(0) && col >= 0 && col < jaggedArr[row].Length)
                {
                    switch (command[0])
                    {
                        case "Add":
                            jaggedArr[row][col] += value;
                            break;
                        case "Subtract":
                            jaggedArr[row][col] -= value;
                            break;
                    }
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            PrintMatrix(jaggedArr);
        }

        private static void PrintMatrix(int[][] jaggedArr)
        {
            for (int row = 0; row < jaggedArr.GetLength(0); row++)
            {
                for (int col = 0; col < jaggedArr[row].Length; col++)
                {
                    Console.Write($"{jaggedArr[row][col]} ");
                }
                Console.WriteLine();
            }
        }

        private static void AnalyzeArr(int[][] jaggedArr)
        {
            for (int row = 0; row < jaggedArr.GetLength(0) - 1; row++)
            {
                if (jaggedArr[row].Length == jaggedArr[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArr[row].Length; col++)
                    {
                        jaggedArr[row][col] *= 2;
                        jaggedArr[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int curArrCol = 0; curArrCol < jaggedArr[row].Length; curArrCol++)
                    {
                        jaggedArr[row][curArrCol] /= 2;
                    }
                    for (int nextArrCol = 0; nextArrCol < jaggedArr[row + 1].Length; nextArrCol++)
                    {
                        jaggedArr[row + 1][nextArrCol] /= 2;
                    }
                }
            }
        }
    }
}
