using System;

namespace _02.The_Battle_of_The_Five_Armies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int rowCount = int.Parse(Console.ReadLine());
         
            int playerRow = 0;
            int playerCol = 0;

            char[] curRow = Console.ReadLine().ToCharArray();
            char[,] matrix = new char[rowCount, curRow.Length];

            for (int row = 0; row < rowCount; row++)
            {               
                for (int col = 0; col < curRow.Length; col++)
                {
                    if (curRow[col] == 'A')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    matrix[row, col] = curRow[col];
                }
                if (row != rowCount - 1)
                {
                    curRow = Console.ReadLine().ToCharArray();
                }               
            }

            bool hasArmyWon = false;
            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = command[0];
                int enemySpawnRow = int.Parse(command[1]);
                int enemySpawnCol = int.Parse(command[2]);

                matrix[enemySpawnRow, enemySpawnCol] = 'O';

                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                switch (direction)
                {
                    case "up":
                        if (isValidMove(newPlayerRow - 1, newPlayerCol, matrix, ref armor))
                        {
                            newPlayerRow--;
                            MoveArmy(newPlayerRow, newPlayerCol, matrix, ref armor, ref hasArmyWon);
                            matrix[playerRow, playerCol] = '-';
                        }
                        break;
                    case "down":
                        if (isValidMove(newPlayerRow + 1, newPlayerCol, matrix, ref armor))
                        {
                            newPlayerRow++;
                            MoveArmy(newPlayerRow, newPlayerCol, matrix, ref armor, ref hasArmyWon);
                            matrix[playerRow, playerCol] = '-';
                        }
                        break;
                    case "left":
                        if (isValidMove(newPlayerRow, newPlayerCol - 1, matrix, ref armor))
                        {
                            newPlayerCol--;
                            MoveArmy(newPlayerRow, newPlayerCol, matrix, ref armor, ref hasArmyWon);
                            matrix[playerRow, playerCol] = '-';
                        }
                        break;
                    case "right":
                        if (isValidMove(newPlayerRow, newPlayerCol + 1, matrix, ref armor))
                        {
                            newPlayerCol++;
                            MoveArmy(newPlayerRow, newPlayerCol, matrix, ref armor, ref hasArmyWon);
                            matrix[playerRow, playerCol] = '-';
                        }
                        break;
                }
                if (hasArmyWon)
                {
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    PrintMatrix(matrix);
                    return;
                }
                if (armor <= 0)
                {
                    matrix[newPlayerRow, newPlayerCol] = 'X';
                    Console.WriteLine($"The army was defeated at {newPlayerRow};{newPlayerCol}.");
                    PrintMatrix(matrix);

                    return;
                }

                playerRow = newPlayerRow;
                playerCol = newPlayerCol;                
            }
        }

        private static void MoveArmy(int newPlayerRow, int newPlayerCol, char[,] matrix, ref int armor, ref bool hasArmyWon)
        {
            if (matrix[newPlayerRow, newPlayerCol] == 'O')
            {
                armor -= 2;
                matrix[newPlayerRow, newPlayerCol] = 'A';
            }
            else if (matrix[newPlayerRow, newPlayerCol] == 'M')
            {
                hasArmyWon = true;
                matrix[newPlayerRow, newPlayerCol] = '-';
            }
            else
            {
                matrix[newPlayerRow, newPlayerCol] = 'A';
            }
        }

        private static bool isValidMove(int playerRow, int playerCol, char[,] matrix, ref int armor)
        {
            armor -= 1;
            if (playerRow >= 0 && playerRow < matrix.GetLength(0)
                && playerCol >= 0 && playerCol < matrix.GetLength(1))
            {
                return true;
            }
            else
            {
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
