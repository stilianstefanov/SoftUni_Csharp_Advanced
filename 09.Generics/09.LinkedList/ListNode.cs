using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Implementing_LinkedList
{
    public class ListNode<T>
    {
        public ListNode(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }
        public ListNode<T> NextNode { get; set; }
        public ListNode<T> PreviousNode { get; set; }
    }
}
