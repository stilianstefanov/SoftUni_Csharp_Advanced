using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var integers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var myQueue = new Queue<int>();

            int countToQueue = inputArr[0];
            int countToDeque = inputArr[1];
            int numberToFind = inputArr[2];

            for (int i = 0; i < countToQueue; i++)
            {
                myQueue.Enqueue(integers[i]);
            }

            if (countToDeque >= myQueue.Count)
            {
                while (myQueue.Count > 0)
                {
                    myQueue.Dequeue();
                }
                Console.WriteLine("0");
                return;
            }
            else
            {
                for (int i = 0; i < countToDeque; i++)
                {
                    myQueue.Dequeue();
                }
            }

            int smallestNumber = int.MaxValue;
            bool isFound = false;

            while (myQueue.Count > 0)
            {
                int currNum = myQueue.Dequeue();

                if (currNum == numberToFind)
                {
                    Console.WriteLine("true");
                    isFound = true;
                    break;
                }
                else
                {
                    if (currNum < smallestNumber)
                    {
                        smallestNumber = currNum;
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine(smallestNumber);
            }
        }
    }
}
