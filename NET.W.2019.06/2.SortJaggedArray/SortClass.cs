using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortJaggedArray
{
    public static class SortClass
    {                        
        public enum SortOrderOption
        {
            Ascend,
            Descend
        }

        public enum SortOption
        {
            ByMaxInRow,
            ByMinInRow,
            ByRowSum
        }
        
        public static int[][] JuggedArraySort(int[][] source_array, SortOption sortoption, SortOrderOption orderoption)
        {
            int[][] indexes_array = null;
            switch (sortoption)
            {
                case SortOption.ByMaxInRow:
                    indexes_array = GetIndexesMax(source_array);
                    break;
                case SortOption.ByMinInRow:
                    indexes_array = GetIndexesMin(source_array);
                    break;
                case SortOption.ByRowSum:
                    indexes_array = GetIndexesSum(source_array);
                    break;
            }

            BubbleSort(indexes_array, orderoption);
            int[][] result_array = new int[source_array.Length][];
            for (int i = 0; i < source_array.Length; i++)
            {
                result_array[i] = new int[source_array[indexes_array[i][1]].Length];
                for (int j = 0; j < source_array[indexes_array[i][1]].Length; j++)
                {
                    result_array[i][j] = source_array[indexes_array[i][1]][j];
                }
            }

            return result_array;
        }

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

        private static int[][] GetIndexesSum(int[][] source_array)
        {
            int[][] result_array = new int[source_array.Length][];
            for (int i = 0; i < source_array.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < source_array[i].Length; j++)
                {
                    sum += source_array[i][j];
                }

                result_array[i] = new int[] { sum, i };
            }

            return result_array;
        }

        private static int[][] GetIndexesMax(int[][] source_array)
        {
            int[][] result_array = new int[source_array.Length][];
            for (int i = 0; i < source_array.Length; i++)
            {
                int max = int.MinValue;
                for (int j = 0; j < source_array[i].Length; j++)
                {
                    if (source_array[i][j] > max)
                    {
                        max = source_array[i][j];
                    }
                }

                result_array[i] = new int[] { max, i };
            }

            return result_array;
        }

        private static int[][] GetIndexesMin(int[][] source_array)
        {
            int[][] result_array = new int[source_array.Length][];
            for (int i = 0; i < source_array.Length; i++)
            {
                int min = int.MaxValue;
                for (int j = 0; j < source_array[i].Length; j++)
                {
                    if (source_array[i][j] < min)
                    {
                        min = source_array[i][j];
                    }
                }

                result_array[i] = new int[] { min, i };
            }

            return result_array;
        }

        private static void BubbleSort(int[][] array, SortOrderOption option)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i][0] > array[j][0] && option == SortOrderOption.Ascend)
                    {
                        int temp_value = array[i][0];
                        int temp_index = array[i][1];
                        array[i][0] = array[j][0];
                        array[i][1] = array[j][1];
                        array[j][0] = temp_value;
                        array[j][1] = temp_index;
                    }
                    else if (array[i][0] < array[j][0] && option == SortOrderOption.Descend)
                    {
                        int temp_value = array[i][0];
                        int temp_index = array[i][1];
                        array[i][0] = array[j][0];
                        array[i][1] = array[j][1];
                        array[j][0] = temp_value;
                        array[j][1] = temp_index;
                    }
                }
            }
        }
    }
}
