using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace GenericBoxofString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int inputCnt = int.Parse(Console.ReadLine());

            List<Box<string>> list = new List<Box<string>>();

            for (int i = 0; i < inputCnt; i++)
            {
                string input = Console.ReadLine();

                Box<string> box = new Box<string>(input);
                list.Add(box);
            }
            string elementInfo = Console.ReadLine();

            Console.WriteLine(Box<string>.GetCountOfLargerElements(list, elementInfo));
        }
        
       
    }
}
