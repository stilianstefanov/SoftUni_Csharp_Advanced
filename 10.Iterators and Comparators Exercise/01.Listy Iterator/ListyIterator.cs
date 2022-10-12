using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
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

    }
}
