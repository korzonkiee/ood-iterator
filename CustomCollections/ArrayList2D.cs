using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.CustomCollections
{
    abstract class ArrayList2D
    {
        private double[,] matrix;
        private int listSize;

        public int RowSize { get; private set; }
        public int ColumnSize { get; private set; }

        public int Size
        {
            get { return listSize; }
        }

        public ArrayList2D(double[,] matrix)
        {
            this.matrix = matrix;
            if(matrix.Length == 0)
            {
                //matrix should have elements!! throw a new exception here
            } else {
                this.RowSize = matrix.GetLength(0);
                this.ColumnSize = matrix.GetLength(1);
                this.listSize = matrix.Length;
            }
        }

        public double Get(int x, int y)
        {
            return matrix[x, y];
        }

        public void Set(int x, int y, double value)
        {
            matrix[x, y] = value;
        }

        public abstract double Get(int n);
    }
}
