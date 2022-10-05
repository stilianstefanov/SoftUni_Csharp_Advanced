using System;
using System.Linq;

namespace _02.Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                char[] curRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {                   
                    matrix[row, col] = curRow[col];
                }
            }

            int blackTruffelsPeter = 0;
            int whiteTruffelsPeter = 0;
            int summerTruffelPeter = 0;

            int wildBoarCollected = 0;

            string command;
            while ((command = Console.ReadLine()) != "Stop the hunt")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Collect")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    if (row >= 0 && row < size && col >= 0 && col < size)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            matrix[row, col] = '-';
                            blackTruffelsPeter++;
                        }
                        else if (matrix[row, col] == 'W')
                        {
                            matrix[row, col] = '-';
                            whiteTruffelsPeter++;
                        }
                        else if (matrix[row, col] == 'S')
                        {
                            matrix[row, col] = '-';
                            summerTruffelPeter++;
                        }
                    }
                }
                else
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    string direction = tokens[3];
                    MoveWildBoar(matrix, row, col, direction, ref wildBoarCollected);
                }
            }
            Console.WriteLine($"Peter manages to harvest {blackTruffelsPeter} black, {summerTruffelPeter} summer, and {whiteTruffelsPeter} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildBoarCollected} truffles.");
            PrintMatrix(matrix);
        }

        private static void MoveWildBoar(char[,] matrix, int startRow, int startCol, string direction, ref int wildBoarCollected)
        {
            switch (direction)
            {
                case "up":
                    for (int row = startRow; row >= 0; row -= 2)
                    {
                        if (matrix[row, startCol] == 'W' || matrix[row, startCol] == 'S' || matrix[row, startCol] == 'B')
                        {
                            matrix[row, startCol] = '-';
                            wildBoarCollected++;
                        }
                    }
                    break;
                case "down":
                    for (int row = startRow; row < matrix.GetLength(0); row += 2)
                    {
                        if (matrix[row, startCol] == 'W' || matrix[row, startCol] == 'S' || matrix[row, startCol] == 'B')
                        {
                            matrix[row, startCol] = '-';
                            wildBoarCollected++;
                        }
                    }
                    break;
                case "left":
                    for (int col = startCol; col >= 0; col -= 2)
                    {
                        if (matrix[startRow, col] == 'W' || matrix[startRow, col] == 'S' || matrix[startRow, col] == 'B')
                        {
                            matrix[startRow, col] = '-';
                            wildBoarCollected++;
                        }
                    }
                    break;
                case "right":
                    for (int col = startCol; col < matrix.GetLength(1); col += 2)
                    {
                        if (matrix[startRow, col] == 'W' || matrix[startRow, col] == 'S' || matrix[startRow, col] == 'B')
                        {
                            matrix[startRow, col] = '-';
                            wildBoarCollected++;
                        }
                    }
                    break;
            }
        }

        private static void PrintMatrix(char[,] matrix)
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
    }
}
