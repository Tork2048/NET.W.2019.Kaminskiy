// <copyright file="SortClass.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SortJaggedArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// SortClass.
    /// </summary>
    public static class SortClass
    {
        /// <summary>
        /// Sort Method that takes IComparer interface as parameter.
        /// </summary>
        /// <param name="array">
        /// Jagged array to sort
        /// </param>
        /// <param name="comparer">
        /// Comparer.
        /// </param>
        public static void SortJaggedArray(this int[][] array, IComparer<int[]> comparer)
        {
            if (array == null || comparer == null)
            {
                throw new ArgumentException();
            }

            array.SortJaggedArray(comparer.Compare);
        }

        /// <summary>
        /// Sort Method that takes delegate as parameter.
        /// </summary>
        /// <param name="array">
        /// Jagged array.
        /// </param>
        /// <param name="comparer">
        /// Delegate.
        /// </param>
        public static void SortJaggedArray(this int[][] array, Func<int[], int[], int> comparer)
        {
            if (array == null || comparer == null)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (comparer.Invoke(array[i], array[j]) > 0)
                    {
                        array.Swap(i, j);
                    }
                }
            }
        }

        /// <summary>
        /// Method that swaps inner arrays in Jagged array.
        /// </summary>
        /// <param name="array">
        /// Jagged array.
        /// </param>
        /// <param name="index1">
        /// first index of array to swap.
        /// </param>
        /// <param name="index2">
        /// second index of array to swap.
        /// </param>
        public static void Swap(this int[][] array, int index1, int index2)
        {
            if (array == null || array.Length < index1 + 1 || array.Length < index2 + 1)
            {
                throw new ArgumentException();
            }

            var temprow = array[index1];
            array[index1] = array[index2];
            array[index2] = temprow;
        }

        /// <summary>
        /// Class that implements IComparer interface.
        /// </summary>
        public class CompareByMaxAscending : IComparer<int[]>
        {
            /// <summary>
            /// Compare method that compares based on max elements in arrays (asc).
            /// </summary>
            /// <param name="x">
            /// first array.
            /// </param>
            /// <param name="y">
            /// second array.
            /// </param>
            /// <returns>
            /// 0,1,-1.
            /// </returns>
            public int Compare(int[] x, int[] y)
            {
                if (x == null || y == null)
                {
                    throw new ArgumentException();
                }

                return x.Max().CompareTo(y.Max());
            }
        }

        /// <summary>
        /// Class that implements IComparer interface.
        /// </summary>
        public class CompareByMaxDescending : IComparer<int[]>
        {
            /// <summary>
            /// Compare method that compares based on max elements in arrays(desc).
            /// </summary>
            /// <param name="x">
            /// first array.
            /// </param>
            /// <param name="y">
            /// second array.
            /// </param>
            /// <returns>
            /// 0,1,-1.
            /// </returns>
            public int Compare(int[] x, int[] y)
            {
                if (x == null || y == null)
                {
                    throw new ArgumentException();
                }

                return y.Max().CompareTo(x.Max());
            }
        }

        /// <summary>
        /// Class that implements IComparer interface.
        /// </summary>
        public class CompareBySumAscending : IComparer<int[]>
        {
            /// <summary>
            /// Compare method that compares based on elements sum in arrays(asc).
            /// </summary>
            /// <param name="x">
            /// first array.
            /// </param>
            /// <param name="y">
            /// second array.
            /// </param>
            /// <returns>
            /// 0,1,-1.
            /// </returns>
            public int Compare(int[] x, int[] y)
            {
                if (x == null || y == null)
                {
                    throw new ArgumentException();
                }

                return x.Sum().CompareTo(y.Sum());
            }
        }

        /// <summary>
        /// Class that implements IComparer interface.
        /// </summary>
        public class CompareBySumDescending : IComparer<int[]>
        {
            /// <summary>
            /// Compare method that compares based on elements sum in arrays(desc).
            /// </summary>
            /// <param name="x">
            /// first array.
            /// </param>
            /// <param name="y">
            /// second array.
            /// </param>
            /// <returns>
            /// 0,1,-1.
            /// </returns>
            public int Compare(int[] x, int[] y)
            {
                if (x == null || y == null)
                {
                    throw new ArgumentException();
                }

                return y.Sum().CompareTo(x.Sum());
            }
        }

        /// <summary>
        /// Class that implements IComparer interface.
        /// </summary>
        public class CompareByMinAscending : IComparer<int[]>
        {
            /// <summary>
            /// Compare method that compares based on Min elements in arrays(asc).
            /// </summary>
            /// <param name="x">
            /// first array.
            /// </param>
            /// <param name="y">
            /// second array.
            /// </param>
            /// <returns>
            /// 0,1,-1.
            /// </returns>
            public int Compare(int[] x, int[] y)
            {
                if (x == null || y == null)
                {
                    throw new ArgumentException();
                }

                return x.Min().CompareTo(y.Min());
            }
        }

        /// <summary>
        /// Class that implements IComparer interface.
        /// </summary>
        public class CompareByMinDescending : IComparer<int[]>
        {
            /// <summary>
            /// Compare method that compares based on Min elements in arrays(desc).
            /// </summary>
            /// <param name="x">
            /// first array.
            /// </param>
            /// <param name="y">
            /// second array.
            /// </param>
            /// <returns>
            /// 0,1,-1.
            /// </returns>
            public int Compare(int[] x, int[] y)
            {
                if (x == null || y == null)
                {
                    throw new ArgumentException();
                }

                return y.Min().CompareTo(x.Min());
            }
        }
    }
}
