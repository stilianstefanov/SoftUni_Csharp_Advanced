using System;
using System.Linq;

namespace _02.Re_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int commandCnt = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < size; row++)
            {
                char[] curRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    if (curRow[col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    matrix[row, col] = curRow[col];
                }
            }

            bool hasPlayerWon = false;
            for (int i = 0; i < commandCnt; i++)
            {
                string command = Console.ReadLine();

                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;
                bool hasSteppedOnTrap = false;

                switch (command)
                {
                    case "up":
                        newPlayerRow--;
                        MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix,ref hasPlayerWon, command, ref hasSteppedOnTrap);
                        break;
                    case "down":
                        newPlayerRow++;
                        MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, ref hasPlayerWon, command, ref hasSteppedOnTrap);
                        break;
                    case "left":
                        newPlayerCol--;
                        MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, ref hasPlayerWon, command, ref hasSteppedOnTrap);
                        break;
                    case "right":
                        newPlayerCol++;
                        MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, ref hasPlayerWon, command, ref hasSteppedOnTrap);
                        break;
                }
                if (hasPlayerWon)
                {
                    matrix[playerRow, playerCol] = '-';
                    break;
                }
                if (!hasSteppedOnTrap)
                {
                    matrix[playerRow, playerCol] = '-';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                }               
            }

            if (hasPlayerWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            PrintMatrix(matrix);
        }

        private static void MovePlayer(ref int newPlayerRow, ref int newPlayerCol, char[,] matrix,ref bool hasPlayerWon, string direction, ref bool hasSteppedOnTrap)
        {
            CheckIsValid(ref newPlayerRow, ref newPlayerCol, direction, matrix);

            if (matrix[newPlayerRow, newPlayerCol] == 'T')
            {
                hasSteppedOnTrap = true;
                return;
            }
            else if (matrix[newPlayerRow, newPlayerCol] == 'B')
            {
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
                CheckIsValid(ref newPlayerRow, ref newPlayerCol, direction, matrix);
                if (matrix[newPlayerRow, newPlayerCol] == 'F')
                {
                    hasPlayerWon = true;
                }
                matrix[newPlayerRow, newPlayerCol] = 'f';
            }
            else if (matrix[newPlayerRow, newPlayerCol] == 'F')
            {
                matrix[newPlayerRow, newPlayerCol] = 'f';
                hasPlayerWon = true;
                return;
            }
            else
            {
                matrix[newPlayerRow, newPlayerCol] = 'f';
            }
        }

        private static void CheckIsValid(ref int newPlayerRow, ref int newPlayerCol, string direction, char[,] matrix)
        {
            if (direction == "up" && newPlayerRow == -1)
            {
                newPlayerRow = matrix.GetLength(0) - 1;
            }
            else if (direction == "down" && newPlayerRow == matrix.GetLength(0))
            {
                newPlayerRow = 0;
            }
            else if (direction == "right" && newPlayerCol == matrix.GetLength(1))
            {
                newPlayerCol = 0;
            }
            else if (direction == "left" && newPlayerCol == -1)
            {
                newPlayerCol = matrix.GetLength(0) - 1;
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
