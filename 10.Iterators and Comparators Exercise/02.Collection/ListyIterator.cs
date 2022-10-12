using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _01.ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int index;
        private List<T> Collection;
        public ListyIterator(params T[] entries)
        {
            this.Collection = new List<T>(entries);
            this.index = 0;
        }
        
        public bool Move()
        {
            if (this.index < this.Collection.Count - 1)
            {
                this.index++;
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            return index < this.Collection.Count - 1;
        }
        public void Print()
        {
            if (this.Collection.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(this.Collection[index]);
            }            
        }

        public void PrintAll()
        {
            if (this.Collection.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                foreach (T item in this.Collection)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }            
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Collection.Count; i++)
            {
                yield return this.Collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
