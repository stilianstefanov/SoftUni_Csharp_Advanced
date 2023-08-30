using System;
using System.Linq;

namespace _02.Rally_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine()!);
            string carNumber = Console.ReadLine();

            char[,] matrix = new char[size, size];

            int playerRow = 0;
            int playerCol = 0;

            int firstSpecialRow = -1;
            int firstSpecialCol = -1;

            int secondSpecialRow = -1;
            int secondSpecialCol = -1;

            for (int row = 0; row < size; row++)
            {
                char[] curRow = Console.ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {                    
                    if (curRow[col] == 'T' && firstSpecialCol != -1)
                    {
                        secondSpecialRow = row;
                        secondSpecialCol = col;
                    }
                    else if (curRow[col] == 'T' && firstSpecialCol == -1)
                    {
                        firstSpecialRow = row;
                        firstSpecialCol = col;
                    }
                    matrix[row, col] = curRow[col];
                }
            }

            int kilometersTraveled = 0;
            bool hasFinished = false;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {               
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                switch (command)
                {
                    case "up":
                        newPlayerRow--;
                        MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, ref kilometersTraveled, ref hasFinished, firstSpecialRow, firstSpecialCol, secondSpecialRow, secondSpecialCol);
                      
                        break;
                    case "down":
                        newPlayerRow++;
                        MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, ref kilometersTraveled, ref hasFinished, firstSpecialRow, firstSpecialCol, secondSpecialRow, secondSpecialCol);
                        
                        break;
                    case "left":
                        newPlayerCol--;
                        MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, ref kilometersTraveled, ref hasFinished, firstSpecialRow, firstSpecialCol, secondSpecialRow, secondSpecialCol);
                        
                        break;
                    case "right":
                        newPlayerCol++;
                        MovePlayer(ref newPlayerRow, ref newPlayerCol, matrix, ref kilometersTraveled, ref hasFinished, firstSpecialRow, firstSpecialCol, secondSpecialRow, secondSpecialCol);
                        
                        break;
                }                
                if (hasFinished)
                {
                    Console.WriteLine($"Racing car {carNumber} finished the stage!");
                    Console.WriteLine($"Distance covered {kilometersTraveled} km.");
                    PrintMatrix(matrix);
                    return;
                }
                playerRow = newPlayerRow;
                playerCol = newPlayerCol;
            }
            matrix[playerRow, playerCol] = 'C';
            Console.WriteLine($"Racing car {carNumber} DNF.");
            Console.WriteLine($"Distance covered {kilometersTraveled} km.");
            PrintMatrix(matrix);

        }

        private static void MovePlayer(ref int newPlayerRow, ref int newPlayerCol, char[,] matrix, ref int kilometersTraveled, ref bool hasFinished, int firstSpecialRow, int firstSpecialCol, int secondSpecialRow, int secondSpecialCol)
        {
            if (matrix[newPlayerRow, newPlayerCol] == 'T')
            {
                matrix[newPlayerRow, newPlayerCol] = '.';
                kilometersTraveled += 30;
                if (newPlayerRow == firstSpecialRow && newPlayerCol == firstSpecialCol)
                {
                    newPlayerRow = secondSpecialRow;
                    newPlayerCol = secondSpecialCol;                    
                }
                else
                {
                    newPlayerRow = firstSpecialRow;
                    newPlayerCol = firstSpecialCol;                  
                }
                matrix[newPlayerRow, newPlayerCol] = '.';
            }
            else if (matrix[newPlayerRow, newPlayerCol] == 'F')
            {
                kilometersTraveled += 10;
                hasFinished = true;
                matrix[newPlayerRow, newPlayerCol] = 'C';
            }
            else
            {
                kilometersTraveled += 10;                
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
