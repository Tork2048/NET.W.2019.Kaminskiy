namespace SortJaggedArray
{
    /// <summary>
    /// Designed to sort jagged arrays.
    /// </summary>
    public static class SortClass
    {
        /// <summary>
        /// Sort order.
        /// </summary>
        public enum SortOrderOption
        {
            /// <summary>
            /// Order by ascending.
            /// </summary>
            Ascend,

            /// <summary>
            /// Order by descending.
            /// </summary>
            Descend,
        }

        /// <summary>
        /// Sort option.
        /// </summary>
        public enum SortOption
        {
            /// <summary>
            /// Order by maximum value in a row.
            /// </summary>
            ByMaxInRow,

            /// <summary>
            /// Order by minum value in a row.
            /// </summary>
            ByMinInRow,

            /// <summary>
            /// Order by sum in a row.
            /// </summary>
            ByRowSum,
        }

        /// <summary>
        /// Sorts jagged array.
        /// </summary>
        /// <param name="source_array">
        /// Array to sort.
        /// </param>
        /// <param name="sortoption">
        /// Sort option from enumeration.
        /// </param>
        /// <param name="orderoption">
        /// Sort order from enumeration.
        /// </param>
        /// <returns>
        /// Sorted array.
        /// </returns>
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
                result_array[i] = source_array[indexes_array[i][1]];
            }

            return result_array;
        }

        /// <summary>
        /// Gets two-dimensional array with 2 elements in each row.
        /// 1 - index in source array.
        /// 2 - sum of elements in that row.
        /// </summary>
        /// <param name="source_array">
        /// Source array.
        /// </param>
        /// <returns>
        /// Array of indexes - sum accordingly.
        /// </returns>
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

        /// <summary>
        /// Gets two-dimensional array with 2 elements in each row.
        /// 1 - index in source array.
        /// 2 - max element in that row.
        /// </summary>
        /// <param name="source_array">
        /// Source array.
        /// </param>
        /// <returns>
        /// Array of indexes - max element accordingly.
        /// </returns>
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

        /// <summary>
        /// Gets two-dimensional array with 2 elements in each row.
        /// 1 - index in source array.
        /// 2 - min element in that row.
        /// </summary>
        /// <param name="source_array">
        /// Source array.
        /// </param>
        /// <returns>
        /// Array of indexes - min element accordingly.
        /// </returns>
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

        /// <summary>
        /// Sorts twodimensional arrays of indexes by sort criteria.
        /// Uses results of following methods.
        /// <see cref="SortClass.GetIndexesMax(int[][])"/>
        /// <see cref="SortClass.GetIndexesMin(int[][])"/>
        /// <see cref="SortClass.GetIndexesSum(int[][])"/>.
        /// </summary>
        /// <param name="array">
        /// Array to sort.
        /// </param>
        /// <param name="option">
        /// Sort criteria.
        /// </param>
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
