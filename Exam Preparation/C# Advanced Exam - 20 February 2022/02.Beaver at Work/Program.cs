using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Beaver_at_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            Stack<char> woodBranches = new Stack<char>();

            int playerRow = 0;
            int playerCol = 0;

            int woodBranchesLeft = 0;

            for (int row = 0; row < size; row++)
            {
                char[] curRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    if (curRow[col] == 'B')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    if (char.IsLower(curRow[col]))
                    {
                        woodBranchesLeft++;
                    }
                    matrix[row, col] = curRow[col];
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                switch (command)
                {
                    case "up":
                        if (IsValidMove(newPlayerRow - 1, newPlayerCol, size, woodBranches))
                        {
                            newPlayerRow--;
                            MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, woodBranches, ref woodBranchesLeft, command);
                            matrix[playerRow, playerCol] = '-';
                        }
                        break;
                    case "down":
                        if (IsValidMove(newPlayerRow + 1, newPlayerCol, size, woodBranches))
                        {
                            newPlayerRow++;
                            MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, woodBranches, ref woodBranchesLeft, command);
                            matrix[playerRow, playerCol] = '-';
                        }
                        break;
                    case "left":
                        if (IsValidMove(newPlayerRow, newPlayerCol - 1, size, woodBranches))
                        {
                            newPlayerCol--;
                            MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, woodBranches, ref woodBranchesLeft, command);
                            matrix[playerRow, playerCol] = '-';
                        }
                        break;
                    case "right":
                        if (IsValidMove(newPlayerRow, newPlayerCol + 1, size, woodBranches))
                        {
                            newPlayerCol++;
                            MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, woodBranches, ref woodBranchesLeft, command);
                            matrix[playerRow, playerCol] = '-';
                        }
                        break;
                }
                playerRow = newPlayerRow;
                playerCol = newPlayerCol;
                if (woodBranchesLeft == 0)
                {
                    break;
                }                
            }
            if (woodBranchesLeft == 0)
            {
                List<char> branches = woodBranches.Reverse().ToList();
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {woodBranchesLeft} branches left.");
            }
            PrintMatrix(matrix);
        }

        private static void MovePlayer(ref int newPlayerRow, ref int newPlayerCol, char[,] matrix, Stack<char> woodBranches, ref int woodBranchesLeft, string command)
        {
            if (char.IsLower(matrix[newPlayerRow, newPlayerCol]))
            {
                char woodBranch = matrix[newPlayerRow, newPlayerCol];
                woodBranches.Push(woodBranch);
                woodBranchesLeft--;
                matrix[newPlayerRow, newPlayerCol] = 'B';
            }
            else if (matrix[newPlayerRow, newPlayerCol] == 'F')
            {
                if (command == "up")
                {
                    if (newPlayerRow != 0)
                    {
                        newPlayerRow = 0;
                        if (char.IsLower(matrix[newPlayerRow, newPlayerCol]))
                        {
                            char woodBranch = matrix[newPlayerRow, newPlayerCol];
                            woodBranches.Push(woodBranch);
                            woodBranchesLeft--;
                        }
                    }
                    else
                    {
                        newPlayerRow = matrix.GetLength(0) - 1;
                        if (char.IsLower(matrix[newPlayerRow, newPlayerCol]))
                        {
                            char woodBranch = matrix[newPlayerRow, newPlayerCol];
                            woodBranches.Push(woodBranch);
                            woodBranchesLeft--;
                        }
                    }
                    matrix[newPlayerRow, newPlayerCol] = 'B';
                }
                if (command == "down")
                {
                    if (newPlayerRow != matrix.GetLength(0) - 1)
                    {
                        newPlayerRow = matrix.GetLength(0) - 1;
                        if (char.IsLower(matrix[newPlayerRow, newPlayerCol]))
                        {
                            char woodBranch = matrix[newPlayerRow, newPlayerCol];
                            woodBranches.Push(woodBranch);
                            woodBranchesLeft--;
                        }
                    }
                    else
                    {
                        newPlayerRow = 0;
                        if (char.IsLower(matrix[newPlayerRow, newPlayerCol]))
                        {
                            char woodBranch = matrix[newPlayerRow, newPlayerCol];
                            woodBranches.Push(woodBranch);
                            woodBranchesLeft--;
                        }
                    }
                    matrix[newPlayerRow, newPlayerCol] = 'B';
                }
                if (command == "left")
                {
                    if (newPlayerCol != 0)
                    {
                        newPlayerCol = 0;
                        if (char.IsLower(matrix[newPlayerRow, newPlayerCol]))
                        {
                            char woodBranch = matrix[newPlayerRow, newPlayerCol];
                            woodBranches.Push(woodBranch);
                            woodBranchesLeft--;
                        }
                    }
                    else
                    {
                        newPlayerCol = matrix.GetLength(1) - 1;
                        if (char.IsLower(matrix[newPlayerRow, newPlayerCol]))
                        {
                            char woodBranch = matrix[newPlayerRow, newPlayerCol];
                            woodBranches.Push(woodBranch);
                            woodBranchesLeft--;
                        }
                    }
                    matrix[newPlayerRow, newPlayerCol] = 'B';
                }
                if (command == "right")
                {
                    if (newPlayerCol != matrix.GetLength(1) - 1)
                    {
                        newPlayerCol = matrix.GetLength(1) - 1;
                        if (char.IsLower(matrix[newPlayerRow, newPlayerCol]))
                        {
                            char woodBranch = matrix[newPlayerRow, newPlayerCol];
                            woodBranches.Push(woodBranch);
                            woodBranchesLeft--;
                        }
                    }
                    else
                    {
                        newPlayerCol = 0;
                        if (char.IsLower(matrix[newPlayerRow, newPlayerCol]))
                        {
                            char woodBranch = matrix[newPlayerRow, newPlayerCol];
                            woodBranches.Push(woodBranch);
                            woodBranchesLeft--;
                        }
                    }
                    matrix[newPlayerRow, newPlayerCol] = 'B';
                }
            }
            else
            {
                matrix[newPlayerRow, newPlayerCol] = 'B';
            }
        }

        private static bool IsValidMove(int playerRow, int playerCol, int size, Stack<char> woodBranches)
        {
            if (playerRow >= 0 && playerRow < size
                && playerCol >= 0 && playerCol < size)
            {
                return true;
            }
            else
            {
                if (woodBranches.Any())
                {
                    woodBranches.Pop();                    
                }
                return false;
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
