using System;

namespace GenericBoxofString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int inputCnt = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCnt; i++)
            {
                string input = Console.ReadLine();

                Console.WriteLine(new Box<string>(input));
            }
        }
    }
}
