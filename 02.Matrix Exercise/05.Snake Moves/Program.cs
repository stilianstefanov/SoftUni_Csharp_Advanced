using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCount = matrixInfo[0];
            int colsCount = matrixInfo[1];

            char[] snake = Console.ReadLine().ToCharArray();
            Queue<char> queue = new Queue<char>(snake);

            char[,] matrix = new char[rowsCount, colsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < colsCount; col++)
                    {
                        char curChar = queue.Dequeue();
                        matrix[row, col] = curChar;
                        queue.Enqueue(curChar);
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        char curChar = queue.Dequeue();
                        matrix[row, col] = curChar;
                        queue.Enqueue(curChar);
                    }
                }
            }

            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }

        }
    }
}
