using System;
using System.Linq;

namespace _08.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsCols = int.Parse(Console.ReadLine());

            if (rowsCols == 0)
            {
                Console.WriteLine("Alive cells: 0");
                Console.WriteLine("Sum: 0");
                return;
            }

            int[,] matrix = new int[rowsCols, rowsCols];

            for (int row = 0; row < rowsCols; row++)
            {
                int[] curRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < rowsCols; col++)
                {

                    matrix[row, col] = curRow[col];
                }
            }

            string[] bombsInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int bomb = 0; bomb < bombsInfo.Length; bomb++)
            {
                string[] currBombInfo = bombsInfo[bomb].Split(",", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(currBombInfo[0]);
                int col = int.Parse(currBombInfo[1]);

                if (matrix[row, col] > 0)
                {
                    Explode(matrix, row, col);
                }
            }

            PrintMatrixInfo(matrix);
        }

        private static void PrintMatrixInfo(int[,] matrix)
        {
            int liveElementsCount = 0;
            int liveElementsSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        liveElementsCount++;
                        liveElementsSum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {liveElementsCount}");
            Console.WriteLine($"Sum: {liveElementsSum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
        static void Explode(int[,] matrix, int row, int col)
        {
            int bombValue = matrix[row, col];
            matrix[row, col] = 0;

            if (row >= 1 && col >= 1 && row < matrix.GetLength(0) - 1 && col < matrix.GetLength(1) - 1)
            {
                if (matrix[row - 1, col - 1] > 0)
                {
                    matrix[row - 1, col - 1] -= bombValue;
                }
                if (matrix[row - 1, col] > 0)
                {
                    matrix[row - 1, col] -= bombValue;
                }
                if (matrix[row - 1, col + 1] > 0)
                {
                    matrix[row - 1, col + 1] -= bombValue;
                }
                if (matrix[row, col - 1] > 0)
                {
                    matrix[row, col - 1] -= bombValue;
                }
                if (matrix[row, col + 1] > 0)
                {
                    matrix[row, col + 1] -= bombValue;
                }
                if (matrix[row + 1, col - 1] > 0)
                {
                    matrix[row + 1, col - 1] -= bombValue;
                }
                if (matrix[row + 1, col] > 0)
                {
                    matrix[row + 1, col] -= bombValue;
                }
                if (matrix[row + 1, col + 1] > 0)
                {
                    matrix[row + 1, col + 1] -= bombValue;
                }
                
            }
            else if (row == 0)
            {
                if (col == 0)
                {
                    if (matrix[row + 1, col] > 0)
                    {
                        matrix[row + 1, col] -= bombValue;
                    }
                    if (matrix[row, col + 1] > 0)
                    {
                        matrix[row, col + 1] -= bombValue;
                    }
                    if (matrix[row + 1, col + 1] > 0)
                    {
                        matrix[row + 1, col + 1] -= bombValue;
                    }
                }
                else if (col == matrix.GetLength(1) - 1)
                {
                    if (matrix[row, col - 1] > 0)
                    {
                        matrix[row, col - 1] -= bombValue;
                    }
                    if (matrix[row + 1, col] > 0)
                    {
                        matrix[row + 1, col] -= bombValue;
                    }
                    if (matrix[row + 1, col - 1] > 0)
                    {
                        matrix[row + 1, col - 1] -= bombValue;
                    }
                }
                else
                {
                    if (matrix[row, col - 1] > 0)
                    {
                        matrix[row, col - 1] -= bombValue;
                    }
                    if (matrix[row, col + 1] > 0)
                    {
                        matrix[row, col + 1] -= bombValue;
                    }
                    if (matrix[row + 1, col - 1] > 0)
                    {
                        matrix[row + 1, col - 1] -= bombValue;
                    }
                    if (matrix[row + 1, col] > 0)
                    {
                        matrix[row + 1, col] -= bombValue;
                    }
                    if (matrix[row + 1, col + 1] > 0)
                    {
                        matrix[row + 1, col + 1] -= bombValue;
                    }
                }
            }
            else if (row == matrix.GetLength(0) - 1)
            {
                if (col == 0)
                {
                    if (matrix[row - 1, col] > 0)
                    {
                        matrix[row - 1, col] -= bombValue;
                    }
                    if (matrix[row, col + 1] > 0)
                    {
                        matrix[row, col + 1] -= bombValue;
                    }
                    if (matrix[row - 1, col + 1] > 0)
                    {
                        matrix[row - 1, col + 1] -= bombValue;
                    }
                }
                else if (col == matrix.GetLength(1) - 1)
                {
                    if (matrix[row - 1, col] > 0)
                    {
                        matrix[row - 1, col] -= bombValue;
                    }
                    if (matrix[row, col - 1] > 0)
                    {
                        matrix[row, col - 1] -= bombValue;
                    }
                    if (matrix[row - 1, col - 1] > 0)
                    {
                        matrix[row - 1, col - 1] -= bombValue;
                    }
                }
                else
                {
                    if (matrix[row, col - 1] > 0)
                    {
                        matrix[row, col - 1] -= bombValue;
                    }
                    if (matrix[row - 1, col - 1] > 0)
                    {
                        matrix[row - 1, col - 1] -= bombValue;
                    }
                    if (matrix[row - 1, col] > 0)
                    {
                        matrix[row - 1, col] -= bombValue;
                    }
                    if (matrix[row - 1, col + 1] > 0)
                    {
                        matrix[row - 1, col + 1] -= bombValue;
                    }
                    if (matrix[row, col + 1] > 0)
                    {
                        matrix[row, col + 1] -= bombValue;
                    }
                }
            }
            else
            {
                if (col == 0)
                {
                    if (matrix[row - 1, col] > 0)
                    {
                        matrix[row - 1, col] -= bombValue;
                    }
                    if (matrix[row - 1, col + 1] > 0)
                    {
                        matrix[row - 1, col + 1] -= bombValue;
                    }
                    if (matrix[row, col + 1] > 0)
                    {
                        matrix[row, col + 1] -= bombValue;
                    }
                    if (matrix[row + 1, col + 1] > 0)
                    {
                        matrix[row + 1, col + 1] -= bombValue;
                    }
                    if (matrix[row + 1, col] > 0)
                    {
                        matrix[row + 1, col] -= bombValue;
                    }
                }
                else if (col == matrix.GetLength(1) - 1)
                {
                    if (matrix[row - 1, col] > 0)
                    {
                        matrix[row - 1, col] -= bombValue;
                    }
                    if (matrix[row - 1, col - 1] > 0)
                    {
                        matrix[row - 1, col - 1] -= bombValue;
                    }
                    if (matrix[row, col - 1] > 0)
                    {
                        matrix[row, col - 1] -= bombValue;
                    }
                    if (matrix[row + 1, col - 1] > 0)
                    {
                        matrix[row + 1, col - 1] -= bombValue;
                    }
                    if (matrix[row + 1, col] > 0)
                    {
                        matrix[row + 1, col] -= bombValue;
                    }
                }
            }
        }
    }
}
