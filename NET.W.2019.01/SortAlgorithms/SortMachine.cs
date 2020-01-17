using System;

namespace SortAlgorithms
{
    /// <summary>
    /// Static class. Contains implementations of Quick, Merge and Bubble sort methods. Also can display array on console.
    /// </summary>
    public static class SortMachine
    {
        /// <summary>
        ///  Will be used as an option param for Sort method.
        /// </summary>
        public enum Method
        {
            /// <summary>
            /// Quick sort method.
            /// </summary>
            Quick,

            /// <summary>
            /// Merge sort method.
            /// </summary>
            Merge,

            /// <summary>
            /// Bubble sort method.
            /// </summary>
            Bubble,
        }

        /// <summary>
        /// Main sort method that agregates all sort methods.
        /// </summary>
        /// <param name="sourceArray">
        /// target array to sort.
        /// </param>
        /// <param name="method">
        /// enum variable that defines sort method.
        /// </param>
        /// <returns>
        /// Sorted array.
        /// </returns>
        public static int[] Sort(int[] sourceArray, Method method)
        {
            if (sourceArray == null)
            {
                throw new ArgumentNullException(nameof(sourceArray), message: "Source array cannot be null.");
            }

            int[] array = new int[sourceArray.Length];
            if (sourceArray == null)
            {
                Console.WriteLine("Array is null");
                return null;
            }

            sourceArray.CopyTo(array, 0);
            switch (method)
            {
                case Method.Quick:
                    QuickSort(array, 0, array.Length - 1);
                    break;
                case Method.Merge:
                    MergeSort(array, 0, array.Length - 1);
                    break;
                case Method.Bubble:
                    Bubble_Sort(array);
                    break;
            }

            return array;
        }

        /// <summary>
        /// Self test method. Tests Sort methods on randomly generated arrays and compares results with reference sort method (Bubble).
        /// </summary>
        /// <param name="testAmount">
        /// Number of tests (new array is generated with each test).
        /// </param>
        /// <param name="arrayCapacity">
        /// number of elements in the array.
        /// </param>
        /// <param name="method">
        /// sort method that will be tested.
        /// </param>
        public static void SelfTest(int testAmount, int arrayCapacity, Method method)
        {
            int testNumber = 0;
            int success = 0;
            while (testNumber < testAmount)
            {
                int[] array = ArrayRandomizer(arrayCapacity, int.MinValue, int.MaxValue);
                int[] bubble = Sort(array, Method.Bubble);
                int[] tested = null;
                switch (method)
                {
                    case Method.Quick:
                        tested = Sort(array, Method.Quick);
                        break;
                    case Method.Merge:
                        tested = Sort(array, Method.Merge);
                        break;
                    case Method.Bubble:
                        tested = Sort(array, Method.Bubble);
                        break;
                }

                bool equil = true;
                for (int i = 0; i < array.Length; i++)
                {
                    if (tested[i] != bubble[i])
                    {
                        equil = false;
                        break;
                    }
                }

                if (equil)
                {
                    success++;
                }

                testNumber++;
            }

            Console.WriteLine($"Tested Method - {method.ToString()}, Tests - {testAmount}, successful - {success}");
        }

        /// <summary>
        /// Array generator (random).
        /// </summary>
        /// <param name="capacity">
        /// number of elements in generated array.
        /// </param>
        /// <param name="begin">
        /// the least number in random range.
        /// </param>
        /// <param name="end">
        /// the greatest number in random range.
        /// </param>
        /// <returns>
        /// Randomly generated array of integers.
        /// </returns>
        public static int[] ArrayRandomizer(int capacity, int begin, int end)
        {
            int[] array = new int[capacity];
            var rand = new Random();
            for (int i = 0; i < capacity; i++)
            {
                array[i] = rand.Next(begin, end);
            }

            return array;
        }

        /// <summary>
        /// Quick sort method implementation. Private, not meant for direct use.
        /// </summary>
        /// <param name="array">
        /// Target array for sorting. Argument is used with ref modifier - required for recursion to work. Algorithm works directly with source array.
        /// </param>
        /// <param name="begin">
        /// Defines the first element of array that will be sorted.
        /// </param>
        /// <param name="end">
        /// Defines the last element of array that will be sorted.
        /// </param>
        private static void QuickSort(int[] array, int begin, int end)
        {
            // int p_index = Piv_Index(Array, begin, end); //getting index of pivot element.
            int p_index = (begin + end) / 2;
            int piv = array[p_index];

            // pivot element is placed in the center of array
            int temp = array[(begin + end) / 2];
            array[(begin + end) / 2] = piv;
            array[p_index] = temp;
            int l = begin; // left cursor
            int r = end;   // right cursor

            // cursors will move towards each other swaping elements that don't belong (elements lesser than pivot should be on the left, greater on the right)
            while (l < r)
            {
                while (array[l] < piv)
                {
                    l++;
                }

                while (array[r] > piv)
                {
                    r--;
                }

                if (l <= r)
                {
                    temp = array[l];
                    array[l++] = array[r];
                    array[r--] = temp;
                }
            }

            if (begin < r)
            {
                QuickSort(array, begin, r);   // recursion entry point for left part
            }

            if (end > l)
            {
                QuickSort(array, l, end);     // recursion entry point for right part
            }
        }

        /// <summary>
        /// Merge sort method implementation. Private, not meant for direct use.
        /// </summary>
        /// <param name="array">
        /// Target array for sorting. Argument is used with ref modifier - required for recursion to work. Algorithm works directly with source array.
        /// </param>
        /// <param name="begin">
        /// Defines the first element of array that will be sorted.
        /// </param>
        /// <param name="end">
        /// Defines the last element of array that will be sorted.
        /// </param>
        private static void MergeSort(int[] array, int begin, int end)
        {
            if (end <= begin)
            {
                return;   // Array can no longer be devided - recursion exit point.
            }

            int mid = (begin + end) / 2;  // defines array devision point (first half last element index).
            MergeSort(array, begin, mid);  // recursion entry point for the first half of array,
            MergeSort(array, mid + 1, end); // recusrion entry point for the second half of array.
            int[] buffer = new int[array.Length];
            for (int k = begin; k <= end; k++)
            {
                buffer[k] = array[k];   // buffer array that contains merged halves (unsorted). Will be used as a source material.
            }

            int i = begin; // first half index
            int j = mid + 1; // second half index
            for (int k = begin; k <= end; k++)
            {
                if (i > mid)
                {
                    array[k] = buffer[j];  // if we run out elements in first half
                    j++;
                }
                else if (j > end)
                {
                    array[k] = buffer[i]; // if we run out of elements in second half
                    i++;
                }
                else if (buffer[i] < buffer[j])
                {
                    array[k] = buffer[i];
                    i++;
                }
                else
                {
                    array[k] = buffer[j];
                    j++;
                }
            }
        }

        /// <summary>
        /// Designed to search for pivot element that is equilly distant from min and max elements in the array.
        /// Proves to be non-effective method. Mid element of the array will be used instead.
        /// </summary>
        /// <param name="array">
        /// Target array.
        /// </param>
        /// <param name="begin">
        /// first element index in search range.
        /// </param>
        /// <param name="end">
        /// last element index in search range.
        /// </param>
        /// <returns>
        /// Index of pivot element.
        /// </returns>
        private static int Piv_Index(int[] array, int begin, int end)
        {
            if (array == null)
            {
                Console.WriteLine("Array is null");
                return 0;
            }

            int max = int.MinValue;
            int min = int.MaxValue;

            // first cycle searches for min and max elements in the array
            for (int i = begin; i <= end; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }

                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            int min_dif = int.MaxValue;
            int p_index = 0;

            // second cycle searches for the most equilly distant element from min and max
            for (int i = begin; i <= end; i++)
            {
                int dif = Math.Abs((max - array[i]) - (array[i] - min));
                if (dif <= min_dif)
                {
                    min_dif = dif;
                    p_index = i;
                }
            }

            return p_index;
        }

        /// <summary>
        /// Bubble sort method. Nothing fancy but reliable. Will be used as a reference for testing purposes.
        /// </summary>
        /// <param name="array">
        /// Target array to sort.
        /// </param>
        /// <returns>
        /// Sorted array.
        /// </returns>
        private static int[] Bubble_Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }
    }
}
