using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> internalList;

        public Stack()
        {
            internalList = new List<T>();
        }

        public void Push(params T[] entries)
        {
            for (int i = entries.Length - 1; i >= 0; i--)
            {
                internalList.Add(entries[i]);
            }
        }
        public T Pop()
        {
            if (this.internalList.Count == 0)
            {
                Console.WriteLine("No elements");
                return default(T);
            }
            T elementToRemove = this.internalList[0];
            this.internalList.RemoveAt(0);
            return elementToRemove;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < internalList.Count; i++)
            {
                yield return internalList[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
