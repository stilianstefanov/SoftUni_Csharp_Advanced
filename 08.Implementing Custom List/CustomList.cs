using System;


namespace _08.Implementing_Custom_List
{
    public class CustomList
    {
        private int[] internalArray;
        private const int initialCapacity = 4;

        public CustomList()
        {
            this.internalArray = new int[initialCapacity];
        }
        public int Capacity { get { return this.internalArray.Length; } }
        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                CheckValid(index);
                return this.internalArray[index];
            }
            set
            {
                CheckValid(index);
                this.internalArray[index] = value;
            }
        }
        public void Add(int value)
        {
            if (this.Count == this.Capacity)
            {
                Resize();
            }
            this.internalArray[this.Count] = value;
            this.Count++;
        }
        public void AddRange(int[] range)
        {
            for (int i = 0; i < range.Length; i++)
            {
                Add(range[i]);
            }
        }
        public bool Contains(int value)
        {
            bool contains = false;
            for (int i = 0; i < internalArray.Length; i++)
            {
                if (this.internalArray[i] == value)
                {
                    contains = true;
                    break;
                }
            }

            return contains;
        }
        public void RemoveAt(int index)
        {
            CheckValid(index);
            this.internalArray[index] = default(int);
            ShiftLeft(index);
            this.Count--;
        }

        public void Insert(int index, int value)
        {
            CheckValid(index);
            if (this.Count == this.Capacity)
            {
                Resize();
            }
            ShiftRight(index);
            this.internalArray[index] = value;
        }
        public void Swap(int index1, int index2)
        {
            CheckValid(index1);
            CheckValid(index2);

            int temp = this.internalArray[index1];
            this.internalArray[index1] = this.internalArray[index2];
            this.internalArray[index2] = temp;
        }

        public void ForEach(Action<int> callBack)
        {
            for (int i = 0; i < Count; i++)
            {
                callBack(this.internalArray[i]);
            }
        }

        private void Resize()
        {
            int[] copy = new int[this.Capacity * 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.internalArray[i];
            }

            this.internalArray = copy;
        }
        private void ShiftRight(int atIndex)
        {
            for (int i = this.Count; i >= atIndex; i--)
            {
                this.internalArray[i] = this.internalArray[i - 1];
            }
        }
        private void ShiftLeft(int atIndex)
        {
            for (int i = atIndex; i < this.Count - 1; i++)
            {
                this.internalArray[i] = this.internalArray[i + 1];
            }
        }
        private void CheckValid(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
