using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sort_project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Array = Sort_Machine.Array_Randomizer(11, -100, 100);
            Console.WriteLine("Source array:");
            Sort_Machine.Display(Array);
            int[] Result = Sort_Machine.Sort(Array, Sort_Machine.Method.Quick);
            Console.WriteLine("Quick sort method result:");
            Sort_Machine.Display(Result);            
            Result = Sort_Machine.Sort(Array, Sort_Machine.Method.Merge);
            Console.WriteLine("Merge sort method result:");
            Sort_Machine.Display(Result);
            Console.WriteLine();
            Sort_Machine.Self_Test(100000, 101, Sort_Machine.Method.Quick);
            Sort_Machine.Self_Test(100000, 101, Sort_Machine.Method.Merge);
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
    }
    /// <summary>
    /// Static class. Contains implementations of Quick, Merge and Bubble sort methods. Also can display array on console.
    /// </summary>

    static class Sort_Machine
    {
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
        static private void Merge_Sort(int[] array, int begin, int end)
        {
            if (end <= begin)
            {
                return;   //Array can no longer be devided - recursion exit point.
            }
            int mid = (begin + end) / 2;  //defines array devision point (first half last element index).
            Merge_Sort(array, begin, mid);  //recursion entry point for the first half of array,
            Merge_Sort(array, mid + 1, end);//recusrion entry point for the second half of array.
            int[] buffer = new int[array.Length];
            for (int k = begin; k <= end; k++)
            {
                buffer[k] = array[k];   //buffer array that contains merged halves (unsorted). Will be used as a source material.
            }
            int i = begin; //first half index
            int j = mid + 1; //second half index
            for (int k = begin; k <= end; k++)
            {
                if (i > mid)
                {
                    array[k] = buffer[j];  //if we run out elements in first half
                    j++;
                }
                else if (j > end)
                {
                    array[k] = buffer[i]; //if we run out of elements in second half
                    i++;
                }
                else if (buffer[i] < buffer[j]) //Sort process
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
        /// Quick sort method implementation. Private, not meant for direct use.
        /// </summary>
        /// <param name="Array">
        /// Target array for sorting. Argument is used with ref modifier - required for recursion to work. Algorithm works directly with source array.
        /// </param>
        /// <param name="begin">
        /// Defines the first element of array that will be sorted. 
        /// </param>
        /// <param name="end">
        /// Defines the last element of array that will be sorted.
        /// </param>

        static private void Quick_Sort(int[] Array, int begin, int end)
        {
            //int p_index = Piv_Index(Array, begin, end); //getting index of pivot element. 
            int p_index = (begin + end) / 2;
            int piv = Array[p_index];
            //pivot element is placed in the center of array
            int temp = Array[(begin + end) / 2];
            Array[(begin + end) / 2] = piv;
            Array[p_index] = temp;
            int l = begin; //left cursor
            int r = end;   //right cursor
            //cursors will move towards each other swaping elements that don't belong (elements lesser than pivot should be on the left, greater on the right)
            while (l < r)
            {
                while (Array[l] < piv)
                {
                    l++;
                }
                while (Array[r] > piv)
                {
                    r--;
                }
                if (l <= r)
                {
                    temp = Array[l];
                    Array[l++] = Array[r];
                    Array[r--] = temp;
                }
            }
            if (begin < r)
            {
                Quick_Sort(Array, begin, r);   //recursion entry point for left part
            }

            if (end > l)
            {
                Quick_Sort(Array, l, end);     //recursion entry point for right part
            }
        }
        /// <summary>
        /// Designed to search for pivot element that is equilly distant from min and max elements in the array.
        /// Proves to be non-effective method. Mid element of the array will be used instead.
        /// </summary>
        /// <param name="Array">
        /// Target array
        /// </param>
        /// <param name="begin">
        /// first element index in search range
        /// </param>
        /// <param name="end">
        /// last element index in search range 
        /// </param>
        /// <returns>
        /// Index of pivot element
        /// </returns>
        static private int Piv_Index(int[] Array, int begin, int end)
        {
            if (Array == null)
            {
                Console.WriteLine("Array is null");
                return 0;
            }
            int max = int.MinValue;
            int min = int.MaxValue;
            //first cycle searches for min and max elements in the array
            for (int i = begin; i <= end; i++)
            {
                if (Array[i] < min)
                {
                    min = Array[i];
                }
                if (Array[i] > max)
                {
                    max = Array[i];
                }
            }
            int min_dif = int.MaxValue;
            int p_index = 0;
            //second cycle searches for the most equilly distant element from min and max
            for (int i = begin; i <= end; i++)
            {
                int dif = Math.Abs((max - Array[i]) - (Array[i] - min));
                if (dif <= min_dif)
                {
                    min_dif = dif;
                    p_index = i;
                }
            }
            return p_index;
        }
        /// <summary>
        /// Will be used as an option param for Sort method
        /// </summary>
        public enum Method { Quick, Merge, Bubble };
        /// <summary>
        /// Main sort method that agregates all sort methods
        /// </summary>
        /// <param name="Array">
        /// target array to sort
        /// </param>
        /// <param name="method">
        /// enum variable that defines sort method
        /// </param>
        /// <returns>
        /// Sorted array
        /// </returns>
        public static int[] Sort(int[] SourceArray, Method method)
        {
            int[] Array = new int[SourceArray.Length];
            if (SourceArray == null)
            {
                Console.WriteLine("Array is null");
                return null;
            }
            SourceArray.CopyTo(Array, 0);            
            switch (method)
            {
                case Method.Quick:
                    Quick_Sort(Array, 0, Array.Length - 1);
                    break;
                case Method.Merge:
                    Merge_Sort(Array, 0, Array.Length - 1);
                    break;
                case Method.Bubble:
                    Bubble_Sort(Array);
                    break;
            }
            //Quick_Sort(ref Array, 0, Array.Length-1);
            return Array;
        }
        /// <summary>
        /// Bubble sort method. Nothing fancy but reliable. Will be used as a reference for testing purposes.
        /// </summary>
        /// <param name="Array">
        /// Target array to sort
        /// </param>
        /// <returns>
        /// Sorted array
        /// </returns>
        private static int[] Bubble_Sort(int[] Array)
        {
            for (int i = 0; i < Array.Length - 1; i++)
            {
                for (int j = i + 1; j < Array.Length; j++)
                {
                    if (Array[i] > Array[j])
                    {
                        int temp = Array[i];
                        Array[i] = Array[j];
                        Array[j] = temp;
                    }
                }
            }
            return Array;
        }
        /// <summary>
        /// Outputs elements of any array of integers to console
        /// </summary>
        /// <param name="Array">
        /// Source array to display
        /// </param>
        public static void Display(int[] Array)
        {
            if (Array == null)
            {
                Console.WriteLine("Array is null");
                return;
            }

            foreach (int a in Array)
            {
                Console.Write($"{a} ");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Self test method. Tests Sort methods on randomly generated arrays and compares results with reference sort method (Bubble)
        /// </summary>
        /// <param name="test_amount">
        /// Number of tests (new array is generated with each test)
        /// </param>
        /// <param name="array_capacity">
        /// number of elements in the array
        /// </param>
        /// <param name="method">
        /// sort method that will be tested
        /// </param>
        public static void Self_Test(int test_amount, int array_capacity, Method method)
        {
            int success = 0;
            int k = 0;
            while (k < test_amount)
            {
                int[] Array = Array_Randomizer(array_capacity, int.MinValue, int.MaxValue);
                int[] bubble = Sort(Array, Method.Bubble);
                int[] tested = null;
                switch (method)
                {
                    case Method.Quick:
                        tested = Sort(Array, Method.Quick);
                        break;
                    case Method.Merge:
                        tested = Sort(Array, Method.Merge);
                        break;
                    case Method.Bubble:
                        tested = Sort(Array, Method.Bubble);
                        break;
                }
                if (tested.GetHashCode() == bubble.GetHashCode())
                {
                    bool equil = true;
                    for (int i = 0; i < array_capacity; i++)
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
                }
                k++;
            }
            Console.WriteLine($"Tested Method - {method.ToString()}, Tests - {test_amount}, successful - {success}");
        }
        /// <summary>
        /// Array generator (random)
        /// </summary>
        /// <param name="capacity">
        /// number of elements in generated array
        /// </param>
        /// <param name="begin">
        /// the least number in random range
        /// </param>
        /// <param name="end">
        /// the greatest number in random range
        /// </param>
        /// <returns>
        /// Randomly generated array of integers
        /// </returns>
        public static int[] Array_Randomizer(int capacity, int begin, int end)
        {
            int[] array = new int[capacity];
            var rand = new Random();
            for (int i = 0; i < capacity; i++)
            {
                array[i] = rand.Next(begin, end);
            }
            return array;
        }
    }
}
