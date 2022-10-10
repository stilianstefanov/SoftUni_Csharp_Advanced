using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Pawn_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 8;

            char[,] matrix = new char[size, size];

            int whitePawnRow = 0;
            int whitePawnCol = 0;

            int blackPawnRow = 0;
            int blackPawnCol = 0;

            for (int row = 0; row < size; row++)
            {
                char[] curRow = Console.ReadLine().ToCharArray();
                    
                for (int col = 0; col < size; col++)
                {
                    if (curRow[col] == 'w')
                    {
                        whitePawnRow = row;
                        whitePawnCol = col;
                    }
                    if (curRow[col] == 'b')
                    {
                        blackPawnRow = row;
                        blackPawnCol = col;
                    }
                    matrix[row, col] = curRow[col];
                }
            }

            Dictionary<int, string> rowValidation = new Dictionary<int, string>();
            rowValidation.Add(0, "8");
            rowValidation.Add(1, "7");
            rowValidation.Add(2, "6");
            rowValidation.Add(3, "5");
            rowValidation.Add(4, "4");
            rowValidation.Add(5, "3");
            rowValidation.Add(6, "2");
            rowValidation.Add(7, "1");
            Dictionary<int, string> columnValidation = new Dictionary<int, string>();
            columnValidation.Add(0, "a");
            columnValidation.Add(1, "b");
            columnValidation.Add(2, "c");
            columnValidation.Add(3, "d");
            columnValidation.Add(4, "e");
            columnValidation.Add(5, "f");
            columnValidation.Add(6, "g");
            columnValidation.Add(7, "h");
           
            int counter = 0;

            while (true)
            {
                if (counter % 2 == 0)
                {
                    if (whitePawnRow - 1 >= 0 && whitePawnCol - 1 >= 0) // Left
                    {
                        if (matrix[whitePawnRow - 1, whitePawnCol - 1] == 'b')
                        {
                            Console.WriteLine($"Game over! White capture on {columnValidation[whitePawnCol - 1]}{rowValidation[whitePawnRow - 1]}.");
                            return;
                        }
                    }
                    if (whitePawnRow - 1 >= 0 && whitePawnCol + 1 < size) // Right
                    {
                        if (matrix[whitePawnRow - 1, whitePawnCol + 1] == 'b')
                        {
                            Console.WriteLine($"Game over! White capture on {columnValidation[whitePawnCol + 1]}{rowValidation[whitePawnRow - 1]}.");
                            return;
                        }
                    }
                    matrix[whitePawnRow, whitePawnCol] = '-';
                    matrix[whitePawnRow - 1, whitePawnCol] = 'w';

                    whitePawnRow--;
                    if (whitePawnRow == 0)
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {columnValidation[whitePawnCol]}{rowValidation[whitePawnRow]}.");
                        return;
                    }
                }
                else
                {
                    if (blackPawnRow + 1 < size && blackPawnCol - 1 >= 0) // Left
                    {
                        if (matrix[blackPawnRow + 1, blackPawnCol - 1] == 'w')
                        {
                            Console.WriteLine($"Game over! Black capture on {columnValidation[blackPawnCol - 1]}{rowValidation[blackPawnRow + 1]}.");
                            return;
                        }
                    }
                    if (blackPawnRow + 1 < size && blackPawnCol + 1 < size) // Right
                    {
                        if (matrix[blackPawnRow + 1, blackPawnCol + 1] == 'w')
                        {
                            Console.WriteLine($"Game over! Black capture on {columnValidation[blackPawnCol + 1]}{rowValidation[blackPawnRow + 1]}.");
                            return;
                        }
                    }
                    matrix[blackPawnRow, blackPawnCol] = '-';
                    matrix[blackPawnRow + 1, blackPawnCol] = 'b';

                    blackPawnRow++;
                    if (blackPawnRow == size - 1)
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {columnValidation[blackPawnCol]}{rowValidation[blackPawnRow]}.");
                        return;
                    }
                }

                counter++;
            }
        }

    }
}
