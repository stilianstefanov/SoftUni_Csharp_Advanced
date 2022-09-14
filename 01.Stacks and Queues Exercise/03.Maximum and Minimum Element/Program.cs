using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int queryCount = int.Parse(Console.ReadLine());

            var myStack = new Stack<int>();

            for (int i = 0; i < queryCount; i++)
            {
                var inputQuery = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (inputQuery[0] == 1)
                {
                    myStack.Push(inputQuery[1]);
                }
                else if (inputQuery[0] == 2)
                {
                    if (myStack.Count > 0)
                    {
                        myStack.Pop();
                    }                    
                }
                else if (inputQuery[0] == 3)
                {
                    List<int> list = new List<int>();

                    int maxElement = int.MinValue;
                    if (myStack.Count > 0)
                    {
                        while (myStack.Count > 0)
                        {
                            int currNum = myStack.Pop();
                            if (currNum > maxElement)
                            {
                                maxElement = currNum;
                            }
                            list.Add(currNum);
                        }
                        list.Reverse();

                        foreach (var number in list)
                        {
                            myStack.Push(number);
                        }
                        Console.WriteLine(maxElement);
                    }
                }
                else if (inputQuery[0] == 4)
                {
                    List<int> list = new List<int>();

                    int minElement = int.MaxValue;
                    if (myStack.Count > 0)
                    {
                        while (myStack.Count > 0)
                        {
                            int currNum = myStack.Pop();
                            if (currNum < minElement)
                            {
                                minElement = currNum;
                            }
                            list.Add(currNum);
                        }
                        list.Reverse();

                        foreach (var number in list)
                        {
                            myStack.Push(number);
                        }
                        Console.WriteLine(minElement);
                    }
                }
            }

            if (myStack.Count > 0)
            {
                List<int> output = new List<int>();

                while (myStack.Count > 0)
                {
                    output.Add(myStack.Pop());
                }

                Console.WriteLine(String.Join(", ", output));
            }            
        }
    }
}
