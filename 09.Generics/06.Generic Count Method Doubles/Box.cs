using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace GenericBoxofString
{
    public class Box<T> where T : IComparable<T>
    {
        public Box(T value) 
        {
            this.Value = value;
        }
        public T Value { get; set; }

        public static int GetCountOfLargerElements(List<Box<T>> list, T item)
        {
            Comparer<T> comparer = Comparer<T>.Default;
            int result = list.Where(x => comparer.Compare(x.Value, item) > 0).ToList().Count;
            return result;
        }

        public override string ToString()
        {
            return $"{typeof(T)}: {this.Value}";
        }
    }
}
