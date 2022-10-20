using System;

namespace _02.Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < size; row++)
            {
                char[] curRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    if (curRow[col] == 'B')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    matrix[row, col] = curRow[col];
                }
            }

            bool hasMovedOut = false;
            int flowersPolinationed = 0;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                switch (command)
                {
                    case "up":
                        if (isValid(newPlayerRow - 1, newPlayerCol, matrix, ref hasMovedOut))
                        {
                            newPlayerRow--;
                            MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, ref flowersPolinationed, command);
                            matrix[playerRow, playerCol] = '.';
                        }
                        break;
                    case "down":
                        if (isValid(newPlayerRow + 1, newPlayerCol, matrix, ref hasMovedOut))
                        {
                            newPlayerRow++;
                            MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, ref flowersPolinationed, command);
                            matrix[playerRow, playerCol] = '.';
                        }
                        break;
                    case "left":
                        if (isValid(newPlayerRow, newPlayerCol - 1, matrix, ref hasMovedOut))
                        {
                            newPlayerCol--;
                            MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, ref flowersPolinationed, command);
                            matrix[playerRow, playerCol] = '.';
                        }
                        break;
                    case "right":
                        if (isValid(newPlayerRow, newPlayerCol + 1, matrix, ref hasMovedOut))
                        {
                            newPlayerCol++;
                            MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, ref flowersPolinationed, command);
                            matrix[playerRow, playerCol] = '.';
                        }
                        break;
                }
                if (hasMovedOut)
                {
                    matrix[playerRow, playerCol] = '.';
                    Console.WriteLine("The bee got lost!");
                    break;
                }
                playerRow = newPlayerRow;
                playerCol = newPlayerCol;
            }
            if (flowersPolinationed >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowersPolinationed} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowersPolinationed} flowers more");
            }
            PrintMatrix(matrix);
        }

        private static void MovePlayer(ref int newPlayerRow, ref int newPlayerCol, char[,] matrix, ref int flowersPolinationed, string direction)
        {
            if (matrix[newPlayerRow, newPlayerCol] == 'f')
            {
                flowersPolinationed++;
                matrix[newPlayerRow, newPlayerCol] = 'B';
            }
            else if (matrix[newPlayerRow, newPlayerCol] == 'O')
            {
                matrix[newPlayerRow, newPlayerCol] = '.';
                switch (direction)
                {
                    case "up":
                        newPlayerRow--;
                        break;
                    case "down":
                        newPlayerRow++;
                        break;
                    case "left":
                        newPlayerCol--;
                        break;
                    case "right":
                        newPlayerCol++;
                        break;
                }
                if (matrix[newPlayerRow, newPlayerCol] == 'f') flowersPolinationed++;
                matrix[newPlayerRow, newPlayerCol] = 'B';
            }
            else
            {
                matrix[newPlayerRow, newPlayerCol] = 'B';
            }
        }

        private static bool isValid(int newPlayerRow, int newPlayerCol, char[,] matrix, ref bool hasMovedOut)
        {
            if (newPlayerRow >= 0 && newPlayerRow < matrix.GetLength(0)
                && newPlayerCol >= 0 && newPlayerCol < matrix.GetLength(1))
            {
                return true;
            }
            else
            {
                hasMovedOut = true;
                return false;
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
