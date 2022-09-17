using System;
using System.Linq;

namespace _06.Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int jaggedArrayRows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[jaggedArrayRows][];

            for (int row = 0; row < jaggedArrayRows; row++)
            {
                int[] currRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jaggedArray[row] = new int[currRow.Length];

                for (int col = 0; col < currRow.Length; col++)
                {
                    jaggedArray[row][col] = currRow[col];
                }
            }

            string[] command = Console.ReadLine().Split();
            while (command[0] != "END")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse((command[2]));
                int value = int.Parse(command[3]);
                if (row >= 0 && row < jaggedArray.GetLength(0) && col >= 0 && col < jaggedArray[row].Length)
                {
                    switch (command[0])
                    {
                        case "Add":
                            jaggedArray[row][col] += value;
                            break;
                        case "Subtract":
                            jaggedArray[row][col] -= value;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");                 
                }               

                command = Console.ReadLine().Split();
            }

            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
