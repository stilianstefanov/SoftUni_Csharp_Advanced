using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            int taskToKill = int.Parse(Console.ReadLine());

            while (true)
            {
                int currentTask = tasks.Pop();
                int currentThread = threads.Dequeue();

                if (currentTask == taskToKill)
                {
                    Console.WriteLine($"Thread with value {currentThread} killed task {taskToKill}");

                    List<int> result = new List<int>(threads);
                    result.Insert(0, currentThread);
                    Console.WriteLine(String.Join(" ", result));
                    return;
                }

                while (currentThread < currentTask)
                {
                    currentThread = threads.Dequeue();
                }
            }
        }
    }
}
