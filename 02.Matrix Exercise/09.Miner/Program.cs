using System;
using System.Linq;

namespace _09.Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[] moves = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int playerRow = 0;
            int playerCol = 0;

            int coalsLeft = 0;
            int coalsCollected = 0;

            char[,] matrix = ReadMatrix(size, ref playerRow, ref playerCol, ref coalsLeft);
           

            foreach (var move in moves)
            {
                int playerNewRow = playerRow;
                int plauerNewCol = playerCol;

                bool hasPlayerSteppedOnE = false;
                bool isValidMove = true;

                switch (move)
                {
                    case "up":
                        playerNewRow--;
                        MovePlayer(playerNewRow, playerCol, matrix, ref coalsCollected, ref coalsLeft, ref hasPlayerSteppedOnE, ref isValidMove);
                        if (isValidMove) matrix[playerRow, playerCol] = '*';
                        break;
                    case "down":
                        playerNewRow++;
                        MovePlayer(playerNewRow, playerCol, matrix, ref coalsCollected, ref coalsLeft, ref hasPlayerSteppedOnE, ref isValidMove);
                        if (isValidMove) matrix[playerRow, playerCol] = '*';
                        break;
                    case "left":
                        plauerNewCol--;
                        MovePlayer(playerRow, plauerNewCol, matrix, ref coalsCollected, ref coalsLeft, ref hasPlayerSteppedOnE, ref isValidMove);
                        if (isValidMove) matrix[playerRow, playerCol] = '*';
                        break;
                    case "right":
                        plauerNewCol++;
                        MovePlayer(playerRow, plauerNewCol, matrix, ref coalsCollected, ref coalsLeft, ref hasPlayerSteppedOnE, ref isValidMove);
                        if (isValidMove) matrix[playerRow, playerCol] = '*';
                        break;
                }
                if (isValidMove == true)
                {
                    playerRow = playerNewRow;
                    playerCol = plauerNewCol;
                }
                if (hasPlayerSteppedOnE)
                {
                    Console.WriteLine($"Game over! ({playerRow}, {playerCol})");
                    return;
                }

                if (coalsLeft == 0)
                {
                    Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol})");
                    return;
                }
            }

            Console.WriteLine($"{coalsLeft} coals left. ({playerRow}, {playerCol})");
        }

        private static void MovePlayer(int playerRow, int playerCol, char[,] matrix, ref int coalsCollected, ref int coalsLeft, ref bool hasPlayerSteppedOnE, ref bool isValidMove)
        {
            if (IsValidMove(playerRow, playerCol, matrix))
            {                
                if (matrix[playerRow, playerCol] == 'e')
                {
                    hasPlayerSteppedOnE = true;
                }
                else if (matrix[playerRow, playerCol] == 'c')
                {
                    coalsCollected++;
                    coalsLeft--;
                }
                matrix[playerRow, playerCol] = 's';
            }
            else
            {
                isValidMove = false;
            }
        }

        private static bool IsValidMove(int playerRow, int playerCol, char[,] matrix)
        {
            return playerRow >= 0 && playerRow < matrix.GetLength(0)
                && playerCol >= 0 && playerCol < matrix.GetLength(1);
        }

        private static char[,] ReadMatrix(int size, ref int playerRow, ref int playerCol, ref int coalsLeft)
        {
            char[,] newMatrix = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                char[] curRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    newMatrix[row, col] = curRow[col];

                    if (curRow[col] == 's')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    if (curRow[col] == 'c')
                    {
                        coalsLeft++;
                    }
                }
            }
            return newMatrix;
        }
    }
}
