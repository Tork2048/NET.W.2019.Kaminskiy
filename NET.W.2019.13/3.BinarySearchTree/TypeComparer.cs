// <copyright file="TypeComparer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BinarySearchTree
{
    using System.Collections.Generic;

    /// <summary>
    /// Class that contains sublcasses with custom comparers.
    /// </summary>
    public class TypeComparer
    {
        /// <summary>
        /// Class that implements custom comparer for int32.
        /// </summary>
        public class IntComparerDescending : IComparer<int>
        {
            /// <summary>
            /// Custom comparer for int32. Inverses default comparer output.
            /// </summary>
            /// <param name="a">
            /// first value.
            /// </param>
            /// <param name="b">
            /// second value.
            /// </param>
            /// <returns>
            /// Standard comparer output (0,1,-1)
            /// </returns>
            int IComparer<int>.Compare(int a, int b)
            {
                if (a > b)
                {
                    return -1;
                }

                if (b > a)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Class that implements custom comparer for String.
        /// </summary>
        public class StringComparerBySymbolCount : IComparer<string>
        {
            /// <summary>
            /// Custom comparer for String. Compares according to symbols count in string.
            /// </summary>
            /// <param name="a">
            /// first value.
            /// </param>
            /// <param name="b">
            /// second value.
            /// </param>
            /// <returns>
            /// Standard comparer output (0,1,-1)
            /// </returns>
            int IComparer<string>.Compare(string a, string b)
            {
                if (a.Length > b.Length)
                {
                    return 1;
                }

                if (b.Length > a.Length)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Class that implements custom comparer for Book.
        /// </summary>
        public class BookComparerByPriceDescending : IComparer<Book>
        {
            /// <summary>
            /// Custom comparer for Book. Compares books accroding to Price (Descending).
            /// </summary>
            /// <param name="a">
            /// first value.
            /// </param>
            /// <param name="b">
            /// second value.
            /// </param>
            /// <returns>
            /// Standard comparer output (0,1,-1).
            /// </returns>
            int IComparer<Book>.Compare(Book a, Book b)
            {
                if (a.Price > b.Price)
                {
                    return -1;
                }

                if (b.Price > a.Price)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Class that implements custom comparer for Point.
        /// </summary>
        public class PointComparerVectorLength : IComparer<Point>
        {
            /// <summary>
            /// Custom comparer for Point. Compares points accroding to vector length.
            /// </summary>
            /// <param name="a">
            /// first value.
            /// </param>
            /// <param name="b">
            /// second value.
            /// </param>
            /// <returns>
            /// Standard comparer output (0,1,-1).
            int IComparer<Point>.Compare(Point a, Point b)
            {
                return a.VectorLength().CompareTo(b.VectorLength());
            }
        }
    }
}
