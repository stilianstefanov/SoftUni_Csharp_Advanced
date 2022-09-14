using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int countToPushX = inputArr[0];
            int countToPopS = inputArr[1];
            int numToFind = inputArr[2];

            var integers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var myStack = new Stack<int>();

            for (int i = 0; i < countToPushX; i++)
            {
                myStack.Push(integers[i]);
            }

            if (countToPopS >= myStack.Count)
            {
                while (myStack.Count > 0)
                {
                    myStack.Pop();
                }
                Console.WriteLine("0");
                return;
            }
            else
            {
                for (int i = 0; i < countToPopS; i++)
                {
                    myStack.Pop();
                }
            }

            int smallestNumber = int.MaxValue;
            bool isFound = false;
            while (myStack.Count > 0)
            {
                int currNum = myStack.Pop();

                if (currNum == numToFind)
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
            if (isFound == false)
            {
                Console.WriteLine(smallestNumber);
            }
        }
    }
}
