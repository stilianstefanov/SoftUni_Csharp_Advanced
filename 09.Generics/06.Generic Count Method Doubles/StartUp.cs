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

            List<Box<double>> items = new List<Box<double>>();

            for (int i = 0; i < inputCnt; i++)
            {
                string input = Console.ReadLine();

                Box<double> box = new Box<double>(double.Parse(input));
                items.Add(box);
            }
            double elementInfo = double.Parse(Console.ReadLine());

            Console.WriteLine(Box<double>.GetCountOfLargerElements(items, elementInfo));
        }
        
       
    }
}
