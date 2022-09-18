using System;
using System.Linq;

namespace _04.Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCount = matrixInfo[0];
            int colsCount = matrixInfo[1];

            string[,] matrix = new string[rowsCount, colsCount];

            for (int row = 0; row < rowsCount ; row++)
            {
                string[] curRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = curRow[col];
                }
            }

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "END")
            {
                if (isCommandValid(command, matrix))
                {
                    SwapValues(command, matrix);
                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        private static void SwapValues(string[] command, string[,] matrix)
        {
            int firstRow = int.Parse(command[1]);
            int firstCol = int.Parse(command[2]);

            int secondRow = int.Parse(command[3]);
            int secondCol = int.Parse(command[4]);

            string temp = matrix[firstRow, firstCol];
            matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
            matrix[secondRow, secondCol] = temp;
        }

        private static bool isCommandValid(string[] command, string[,] matrix)
        {
            if (command[0] != "swap")
            {
                return false;
            }
            if (command.Length != 5)
            {
                return false;
            }
            int firstRow = int.Parse(command[1]);
            int firstCol = int.Parse(command[2]);

            int secondRow = int.Parse(command[3]);
            int secondCol = int.Parse(command[4]);

            if (firstRow < 0 || firstRow >= matrix.GetLength(0) || firstCol < 0 || firstCol >= matrix.GetLength(1))
            {
                return false;
            }
            if (secondRow < 0 || secondRow >= matrix.GetLength(0) || secondCol < 0 || secondCol >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }
    }
}
