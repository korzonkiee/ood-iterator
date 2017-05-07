using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.CustomCollections
{
    class FibonacciLazyList : ICustomList<double>
    {
        private List<double> values;
        private int sizeLimit;

        public int Size
        {
            get { return sizeLimit; }
        }

        public FibonacciLazyList(int sizeLimit)
        {
            this.values = new List<double>();
            this.sizeLimit = sizeLimit;
        }

        public double Get(int n)
        {
            double result = n;
            if (n > 1) {
                if(n < values.Count)
                {
                    result = values[n];
                } else
                {
                    result = Get(n - 1) + Get(n - 2);
                    values.Add(result);
                }
            }

            return result;
        }

        public Iterator CreateIterator()
        {
            return new FIterator(this);
        }
    }

    class FIterator : Iterator
    {
        private readonly FibonacciLazyList list;
        int index;

        public FIterator(FibonacciLazyList list)
        {
            this.list = list;
            index = -1;
        }

        public object Next()
        {
            if (index < list.Size - 1)
            {
                index++;
                return list.Get(index);
            }

            return null;
        }
    }
}
