using System;
using System.Collections.Generic;

namespace _09.Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());

            Stack<Queue<char>> stackOfQueues = new Stack<Queue<char>>();

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] command = Console.ReadLine().Split();

                switch (command[0])
                {
                    case "1":
                        AppendText(stackOfQueues, command);
                        break;
                    case "2":
                        EraseText(stackOfQueues, command);
                        break;
                    case "3":
                        ShowAtPosition(stackOfQueues, command);
                        break;
                    case "4":
                        stackOfQueues.Pop();
                        break;
                }
            }
        }

        private static void ShowAtPosition(Stack<Queue<char>> stackOfQueues, string[] command)
        {
            int showAtIndex = int.Parse(command[1]);
            Queue<char> currQueue = stackOfQueues.Peek();
            

            for (int i = 1; i <= currQueue.Count; i++)
            {
                char currChar = currQueue.Dequeue();

                if (showAtIndex == i)
                {
                    Console.WriteLine(currChar);
                }
                currQueue.Enqueue(currChar);
            }
        }

        private static void EraseText(Stack<Queue<char>> stackOfQueues, string[] command)
        {
            int countToErase = int.Parse(command[1]);

            Queue<char> newQueue = new Queue<char>(stackOfQueues.Peek());

            for (int i = 0; i < newQueue.Count - countToErase; i++)
            {
                char currChar = newQueue.Dequeue();
                newQueue.Enqueue(currChar);
            }

            for (int i = 0; i < countToErase; i++)
            {
                newQueue.Dequeue();
            }

            stackOfQueues.Push(newQueue);
        }

        private static void AppendText(Stack<Queue<char>> stackOfQueues, string[] command)
        {
            string textToAppend = command[1];
            char[] charsToAppend = textToAppend.ToCharArray();

            if (stackOfQueues.Count == 0)
            {
                Queue<char> firstQueue = new Queue<char>();

                for (int i = 0; i < charsToAppend.Length; i++)
                {
                    firstQueue.Enqueue(charsToAppend[i]);
                }

                stackOfQueues.Push(firstQueue);
            }
            else
            {
                Queue<char> newQueue = new Queue<char>(stackOfQueues.Peek());

                for (int i = 0; i < charsToAppend.Length; i++)
                {
                    newQueue.Enqueue(charsToAppend[i]);
                }
                stackOfQueues.Push(newQueue);
            }
        }
    }
}
