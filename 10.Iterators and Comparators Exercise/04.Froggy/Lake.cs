using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        public Lake(params int[] entries)
        {
            this.Collection = new List<int>(entries);
        }

        public List<int> Collection { get; set; }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Collection.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return this.Collection[i];
                }
            }
            for (int i = Collection.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return this.Collection[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
