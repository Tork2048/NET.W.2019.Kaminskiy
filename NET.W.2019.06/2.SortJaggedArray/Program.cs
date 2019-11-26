using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SortJaggedArray.SortClass;

namespace SortJaggedArray
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[][] a1 = new int[6][];
            a1[0] = new int[] { 1, 2, 6, 0, 10 };
            a1[1] = new int[] { 1, 2, 3 };
            a1[2] = new int[] { 1, 2, 30, 4, 5 };
            a1[3] = new int[] { 1, 2, 88 };
            a1[4] = new int[] { 1, 2, 34 };
            a1[5] = new int[] { 1, 2, 3, 4, 5 };
            int[][] result = JuggedArraySort(a1, SortOption.ByMaxInRow, SortOrderOption.Descend);
            SortClass.DisplayJaggedArray(result);
            Console.ReadKey();
        }
    }
}
