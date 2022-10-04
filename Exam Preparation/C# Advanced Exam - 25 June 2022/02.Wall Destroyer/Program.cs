using System;

namespace _02.Wall_Destroyer
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
                    if (curRow[col] == 'V')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    matrix[row, col] = curRow[col];
                }
            }

            string command;
            bool isElectrocuted = false;
            int holesMade = 1;
            int rodsHitted = 0;
            while ((command = Console.ReadLine()) != "End")
            {
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;
                bool hasplayerMoved = false;
                bool isWallAlreadyDestroyed = false;
                
                switch (command)
                {
                    case "up":
                        if (isValidMove(newPlayerRow - 1, newPlayerCol, matrix))
                        {
                            newPlayerRow--;
                            MovePlayer(newPlayerRow, newPlayerCol, matrix, ref isElectrocuted, ref hasplayerMoved, ref rodsHitted, ref isWallAlreadyDestroyed);
                        }
                        break;
                    case "down":
                        if (isValidMove(newPlayerRow + 1, newPlayerCol, matrix))
                        {
                            newPlayerRow++;
                            MovePlayer(newPlayerRow, newPlayerCol, matrix, ref isElectrocuted, ref hasplayerMoved, ref rodsHitted, ref isWallAlreadyDestroyed);
                        }
                        break;
                    case "left":
                        if (isValidMove(newPlayerRow, newPlayerCol - 1, matrix))
                        {
                            newPlayerCol--;
                            MovePlayer(newPlayerRow, newPlayerCol, matrix, ref isElectrocuted, ref hasplayerMoved, ref rodsHitted, ref isWallAlreadyDestroyed);
                        }
                        break;
                    case "right":
                        if (isValidMove(newPlayerRow, newPlayerCol + 1, matrix))
                        {
                            newPlayerCol++;
                            MovePlayer(newPlayerRow, newPlayerCol, matrix, ref isElectrocuted, ref hasplayerMoved, ref rodsHitted, ref isWallAlreadyDestroyed);
                        }
                        break;
                }

                if (isElectrocuted)
                {
                    matrix[playerRow, playerCol] = '*';
                    holesMade++;
                    break;
                }

                if (hasplayerMoved == true)
                {
                    if (!isWallAlreadyDestroyed)
                    {
                        holesMade++;
                    }
                    matrix[playerRow, playerCol] = '*';                    
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                }               
            }

            if (!isElectrocuted)
            {
                Console.WriteLine($"Vanko managed to make {holesMade} hole(s) and he hit only {rodsHitted} rod(s).");
            }
            else
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesMade} hole(s).");
            }
            PrintMatrix(matrix);
        }

        private static void MovePlayer(int newPlayerRow, int newPlayerCol, char[,] matrix, ref bool isElectrocuted, ref bool hasplayerMoved, ref int rodsHitted, ref bool isWallAlreadyDestroyed)
        {
            if (matrix[newPlayerRow, newPlayerCol] == 'R')
            {
                Console.WriteLine("Vanko hit a rod!");
                rodsHitted++;
                return;
            }
            else if (matrix[newPlayerRow, newPlayerCol] == 'C')
            {
                isElectrocuted = true;
                hasplayerMoved = true;
                matrix[newPlayerRow, newPlayerCol] = 'E';
                return;
            }
            else if (matrix[newPlayerRow, newPlayerCol] == '*')
            {
                matrix[newPlayerRow, newPlayerCol] = 'V';
                hasplayerMoved = true;
                isWallAlreadyDestroyed = true;
                Console.WriteLine($"The wall is already destroyed at position [{newPlayerRow}, {newPlayerCol}]!");
                return;
            }
            else
            {
                hasplayerMoved = true;
                matrix[newPlayerRow, newPlayerCol] = 'V';
            }
        }

        private static bool isValidMove(int playerRow, int playerCol, char[,] matrix)
        {
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
