using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace _07.Implementing_LinkedList
{
    public class CustomDoublyLinkedList<T> : IEnumerable<T>
    {
        private ListNode<T> head;

        private ListNode<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            ListNode<T> newHead = new ListNode<T>(element);

            if (Count == 0)
            {
                this.head = this.tail = newHead;
            }
            else
            {
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }
            this.Count++;
        }

        public void AddLast(T element)
        {
            ListNode<T> newTail = new ListNode<T>(element);

            if (this.Count == 0)
            {
                this.head = this.tail = newTail;
            }
            else
            {
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }
            this.Count++;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            T firstElement = head.Value;
            this.head = this.head.NextNode;
            if (this.head != null)
                this.head.PreviousNode = null;
            else
                this.tail = null;

            this.Count--;
            return firstElement;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            T lastElement = tail.Value;
            this.tail = this.tail.PreviousNode;

            if (this.tail != null)
                this.tail.NextNode = null;
            else
                this.head = null;

            this.Count--;
            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            ListNode<T> current = this.head;

            while (current != null)
            {
                action(current.Value);
                current = current.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            ListNode<T> node = head;
            for (int i = 0; i < Count; i++)
            {
                array[i] = node.Value;
                node = node.NextNode;
            }
            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListNode<T> current = this.head;

            while (current != null)
            {
                yield return current.Value;
                current = current.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
