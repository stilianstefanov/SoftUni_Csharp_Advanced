using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book
    {
        public Book(string title, int year, params string[] autors)
        {
            Title = title;
            Year = year;
            Autors = autors.ToList();
        }

        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Autors { get; set; }
    }
}
