using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.CustomCollections
{
    class ArrayList2DCR : ArrayList2D, ICustomList<double>
    {
        public ArrayList2DCR(double[,] matrix) : base(matrix) { }

        public override double Get(int n)
        {
            return base.Get(n / base.ColumnSize, n % base.ColumnSize);
        }

        public Iterator CreateIterator()
        {
            return new ACRIterator(this);
        }
    }

    class ACRIterator : Iterator
    {
        int index;
        double lastSum = 0;
        private readonly ArrayList2DCR list;

        public ACRIterator(ArrayList2DCR list)
        {
            this.list = list;
            this.index = -1;
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