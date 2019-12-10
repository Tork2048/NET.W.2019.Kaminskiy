// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SortJaggedArray
{
    using System;

    /// <summary>
    /// Class that contains entry point.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            int[][] a1 = new int[4][];
            a1[0] = new int[] { 45, 23, 3, 87 };
            a1[1] = new int[] { 10, 6, 11, 20, 0, 3 };
            a1[2] = new int[] { 0, 4, 7, 1 };
            a1[3] = new int[] { -1, 9, 34, 9, 3, -44 };

            a1.SortJaggedArray(new SortClass.CompareByMaxAscending().Compare);
            DisplayJaggedArray(a1);
            Console.WriteLine();
            a1.SortJaggedArray(new SortClass.CompareByMinAscending().Compare);
            DisplayJaggedArray(a1);
            Console.WriteLine();
            a1.SortJaggedArray(new SortClass.CompareBySumAscending().Compare);
            DisplayJaggedArray(a1);
            Console.WriteLine();
            a1.SortJaggedArray(new SortClass.CompareByMaxDescending());
            DisplayJaggedArray(a1);
            Console.WriteLine();
            a1.SortJaggedArray(new SortClass.CompareByMaxDescending());
            DisplayJaggedArray(a1);
            Console.WriteLine();

            Console.ReadKey();
        }

        /// <summary>
        /// Method that displays Jagged array on Console.
        /// </summary>
        /// <param name="array">
        /// Jagged array
        /// </param>
        public static void DisplayJaggedArray(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write($"{array[i][j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
