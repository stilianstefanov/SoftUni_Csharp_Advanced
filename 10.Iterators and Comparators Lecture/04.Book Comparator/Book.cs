using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] autors)
        {
            Title = title;
            Year = year;
            Autors = new List<string>(autors);
        }

        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Autors { get; set; }

        public int CompareTo(Book other)
        {
            BookComparator comparator = new BookComparator();
            return comparator.Compare(this, other);
        }

        public override string ToString()
        {
            return $"{Title} - {Year}";
        }
    }
}
