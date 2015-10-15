using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedMassSort
{
    public class MassSorter
    {
        public int[][] Massive
        {
            get { return _massive; }
            set { _massive = makeCopy(value); }
        }

        int[][] _massive;

        int[][] makeCopy(int[][] mass)
        {
            return (int[][])mass.Clone();
        }

        static void Swap(ref int x, ref int y)
        {
            var temp = x;
            x = y;
            y = temp;
        }
        static void Swap(ref int[] x, ref int[] y)
        {
            var temp = x;
            x = y;
            y = temp;
        }

        static int getValue(bool orderByDescending)
        {
            int res = orderByDescending ? int.MinValue : int.MaxValue;
            return res;
        }

        static void Sort(int[][] jaggedMass, int[] mass, bool orderByDescending)
        {
            bool success;
            for (int i = 0; i < mass.Length; i++)
            {
                for (int j = i + 1; j < mass.Length; j++)
                {
                    success = orderByDescending ? mass[i] < mass[j] : mass[i] > mass[j];
                    if (success)
                    {
                        Swap(ref mass[i], ref mass[j]);
                        Swap(ref jaggedMass[i], ref jaggedMass[j]);
                    }
                }
            }
        }

        public void SortByMinElement(bool orderByDescending = false)
        {
            int[] mins = new int[Massive.Length];
            for (int i = 0; i < Massive.Length; i++)
            {
                if (Massive[i] != null)
                {
                    mins[i] = Massive[i][0];
                    for (int j = 1; j < Massive[i].Length; j++)
                    {
                        if (Massive[i][j] < mins[i])
                            mins[i] = Massive[i][j];
                    }
                }
                else mins[i] = getValue(orderByDescending);
            }

            Sort(Massive, mins, orderByDescending);


        }

        public void SortByMaxElement(bool orderByDescending = false)
        {
            int[] maxes = new int[Massive.Length];
            for (int i = 0; i < Massive.Length; i++)
            {
                if (Massive[i] != null)
                {
                    maxes[i] = Massive[i][0];
                    for (int j = 1; j < Massive[i].Length; j++)
                    {
                        if (Massive[i][j] > maxes[i])
                            maxes[i] = Massive[i][j];
                    }
                }
                else maxes[i] = getValue(orderByDescending);
            }

            Sort(Massive, maxes, orderByDescending);


        }

        public void SortBySum(bool orderByDescending = false)
        {
            int[] sums = new int[Massive.Length];
            for (int i = 0; i < Massive.Length; i++)
            {
                if (Massive[i] != null)
                    for (int j = 0; j < Massive[i].Length; j++)
                    {
                        sums[i] += Massive[i][j];
                    }
                else sums[i] = getValue(orderByDescending);
            }

            Sort(Massive, sums, orderByDescending);


        }

    }
}
