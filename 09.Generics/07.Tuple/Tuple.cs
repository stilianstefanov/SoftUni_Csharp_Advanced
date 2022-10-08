using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<T, T2>
    {
		private T item1;
        private T2 item2;
        public T Item1
        {
			get { return item1; }
			set { item1 = value; }
		}
		
		public T2 Item2
        {
			get { return item2; }
			set { item2 = value; }
		}


	}
}
