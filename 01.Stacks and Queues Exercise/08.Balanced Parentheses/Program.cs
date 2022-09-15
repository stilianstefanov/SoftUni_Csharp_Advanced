using System;
using System.Collections.Generic;

namespace _08.Balanced_Parentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }
            if (input[0] != '[' && input[0] != '(' && input[0] != '{')
            {
                Console.WriteLine("NO");
                return;
            }
            Stack<char> myStack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    myStack.Push(input[i]);
                }
                else if (input[i] == '[')
                {
                    myStack.Push(input[i]);
                }
                else if (input[i] == '{')
                {
                    myStack.Push(input[i]);
                }
                else if (input[i] == ')')
                {
                    char lastChar = myStack.Pop();
                    if (lastChar != '(')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (input[i] == ']')
                {
                    char lastChar = myStack.Pop();
                    if (lastChar != '[')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (input[i] == '}')
                {
                    char lastChar = myStack.Pop();
                    if (lastChar != '{')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }
            Console.WriteLine("YES");
        }
    }
}
