using System;
using static SortJaggedArray.SortClass;

namespace SortJaggedArray
{
    /// <summary>
    /// Contains Entry point.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        public static void Main()
        {
            int[][] a1 = new int[6][];
            a1[0] = new int[] { 1, 2, 6, 0, 10 };
            a1[1] = new int[] { 1, 2, 3 };
            a1[2] = new int[] { 1, 2, 30, 4, 5 };
            a1[3] = new int[] { 1, 2, 88 };
            a1[4] = new int[] { 1, 2, 34 };
            a1[5] = new int[] { 1, 2, 3, 4, 5 };
            int[][] result = JuggedArraySort(a1, SortOption.ByMaxInRow, SortOrderOption.Descend);

            DisplayJaggedArray(result);
            Console.ReadKey();
        }

        /// <summary>
        /// Method displays jagged array on console.
        /// </summary>
        /// <param name="array">
        /// Array to display.
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
