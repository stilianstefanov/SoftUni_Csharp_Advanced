using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace _07.Implementing_LinkedList
{
    public class CustomLinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Count { get; set; }

        public void AddLast(int value)
        {
            Node node = new Node(value);

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
        public void AddFirst(int value)
        {
            Node node = new Node(value);

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

        public int RemoveFirst()
        {
            Node nodeToRemove = this.Head;
            this.Head = nodeToRemove.Next;
            nodeToRemove.Next = null;
            this.Head.Previous = null;

            this.Count--;

            return nodeToRemove.Value;
        }

        public int RemoveLast()
        {
            Node nodeToRemove = this.Tail;
            this.Tail = nodeToRemove.Previous;
            nodeToRemove.Previous = null;
            this.Tail.Next = null;

            this.Count--;

            return nodeToRemove.Value;
        }

        public void ForEach(Action<int> callback)
        {
            Node node = this.Head;
            while (node != null)
            {
                callback(node.Value);
                node = node.Next;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[this.Count];
            int index = 0;

            Node currentNode = this.Head;
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
