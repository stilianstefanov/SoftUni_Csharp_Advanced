using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace _07.Implementing_LinkedList
{
    public class CustomLinkedList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public int Count { get; set; }

        public void AddLast(T value)
        {
            Node<T> node = new Node<T>(value);

            if (this.Head == null)
            {
                this.Head = node;
                this.Tail = node;
                this.Count++;
                return;
            }

            node.Previous = this.Tail;
            this.Tail.Next = node;
            this.Tail = node;
            this.Count++;
        }
        public void AddFirst(T value)
        {
            Node<T> node = new Node<T>(value);

            if (this.Head == null)
            {
                this.Head = node;
                this.Tail = node;
                this.Count++;
                return;
            }

            node.Next = this.Head;
            this.Head.Previous = node;
            this.Head = node;
            this.Count++;
        }

        public T RemoveFirst()
        {
            Node<T> nodeToRemove = this.Head;
            this.Head = nodeToRemove.Next;
            nodeToRemove.Next = null;
            this.Head.Previous = null;

            this.Count--;

            return nodeToRemove.Value;
        }

        public T RemoveLast()
        {
            Node<T> nodeToRemove = this.Tail;
            this.Tail = nodeToRemove.Previous;
            nodeToRemove.Previous = null;
            this.Tail.Next = null;

            this.Count--;

            return nodeToRemove.Value;
        }

        public void ForEach(Action<T> callback)
        {
            Node<T> node = this.Head;
            while (node != null)
            {
                callback(node.Value);
                node = node.Next;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            int index = 0;

            Node<T> currentNode = this.Head;
            while (currentNode != null)
            {
                array[index] = currentNode.Value;
                currentNode = currentNode.Next;
                index++;
            }

            return array;
        }
    }
}
