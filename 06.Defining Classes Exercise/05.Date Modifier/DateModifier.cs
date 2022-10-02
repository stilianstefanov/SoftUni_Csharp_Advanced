using System;
using System.Collections.Generic;
using System.Text;

namespace _05.DateModifier
{
    public class DateModifier
    {		
		public void Calculate(string firstDate, string secondDate)
		{
			string[] date1Info = firstDate.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] date2Info = secondDate.Split(" ", StringSplitOptions.RemoveEmptyEntries);
			

			DateTime date1 = new DateTime(int.Parse(date1Info[0]), int.Parse(date1Info[1]), int.Parse(date1Info[2]));
            DateTime date2 = new DateTime(int.Parse(date2Info[0]), int.Parse(date2Info[1]), int.Parse(date2Info[2]));

			double curDifference = (date1 - date2).TotalDays;
			Console.WriteLine(Math.Abs(curDifference));
        }
	}
}
