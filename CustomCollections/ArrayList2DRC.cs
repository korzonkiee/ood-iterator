using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.CustomCollections
{
    class ArrayList2DRC : ArrayList2D, ICustomList<double>
    {
        public ArrayList2DRC(double[,] matrix) : base(matrix) { }

        public Iterator CreateIterator()
        {
            return new RCIterator(this);
        }

        public override double Get(int n)
        {
            return base.Get(n % base.RowSize, n / base.RowSize);
        }
    }

    class RCIterator : Iterator
    {
        private readonly ArrayList2DRC list;

        int index;
        double lastSum;

        public RCIterator(ArrayList2DRC list)
        {
            this.list = list;

            index = -1;
            lastSum = 0;
        }

        public object Next()
        {
            if (index < list.Size - 1)
            {
                index++;
                lastSum = lastSum + list.Get(index);
                return lastSum;
            }

            return null;
        }
    }
}
