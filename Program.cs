using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iterator.CustomCollections;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            ICustomList<double> fibonacci = new FibonacciLazyList(6);
            ICustomList<double> d2rc = init2DRC();
            ICustomList<double> d2cr = init2DCR();

            var mergedList = new List<double>();

            Console.WriteLine("/**** ArrayList2DCR - ACRIterator ****/\n");
            var crIterator = d2cr.CreateIterator();
            var crItem = crIterator.Next();
            while (crItem != null)
            {
                mergedList.Add((double)crItem);

                Console.WriteLine((double)crItem);
                crItem = crIterator.Next();
            }

            Console.WriteLine("\n\n/**** ArrayList2DRC - ARCIterator ****/\n");

            var rcIterator = d2rc.CreateIterator();
            var rcItem = rcIterator.Next();
            while (rcItem != null)
            {
                mergedList.Add((double)rcItem);
                
                Console.WriteLine((double)rcItem);
                rcItem = rcIterator.Next();
            }

            Console.WriteLine("\n\n/**** FibonacciLazyList - FIterator ****/\n");

            var fIterator = fibonacci.CreateIterator();
            var fItem = fIterator.Next();
            while (fItem != null)
            {
                mergedList.Add((double)fItem);
                
                Console.WriteLine((double)fItem);
                fItem = fIterator.Next();
            }

            Console.WriteLine("\n\n/**** Two elements variantions of 3 lists ****/\n");
            Display2ElementsVariations(mergedList);

            Console.WriteLine("\n\n/**** Sums of two elements variantions of 3 lists ****/\n");
            DisplaySumsOf2ElementsVariations(mergedList);
        }

        static void Display2ElementsVariations(IList<double> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    Console.Write($"{{{list.ElementAt(i)}, {list.ElementAt(j)}}}, ");
                }
            }
            Console.WriteLine("\n\n");
        }

        static void DisplaySumsOf2ElementsVariations(IList<double> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    Console.Write($"{list.ElementAt(i) + list.ElementAt(j)}, ");
                }
            }
            Console.WriteLine("\n\n");
        }


        //DO NOT change code below
        static ArrayList2DRC init2DRC()
        {
            double[,] matrix = new double[3, 3];
            int n = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = n++;
                }
            }

            return new ArrayList2DRC(matrix);
        }

        static ArrayList2DCR init2DCR()
        {
            double[,] matrix = new double[3, 3];
            int n = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = n++;
                }
            }

            return new ArrayList2DCR(matrix);
        }
    }
}
