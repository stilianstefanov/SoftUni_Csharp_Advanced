using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Implementing_LinkedList
{
    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }
    }
}
