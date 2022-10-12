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
            if (this.Year != other.Year)
            {
                return this.Year.CompareTo(other.Year);
            }
            else
            {
                return this.Title.CompareTo(other.Title);
            }
        }

        public override string ToString()
        {
            return $"{Title} - {Year}";
        }
    }
}
