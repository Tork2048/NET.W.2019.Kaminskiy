using System;

namespace SortAlgorithms
{
    /// <summary>
    /// Class that contains entry point.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        public static void Main()
        {
            int[] array = SortMachine.ArrayRandomizer(11, -100, 100);
            Console.WriteLine("Source array:");
            Display(array);

            int[] result = SortMachine.Sort(array, SortMachine.Method.Quick);

            Console.WriteLine("Quick sort method result:");
            Display(result);
            result = SortMachine.Sort(array, SortMachine.Method.Merge);
            Console.WriteLine("Merge sort method result:");
            Display(result);
            Console.WriteLine();
            SortMachine.SelfTest(100000, 101, SortMachine.Method.Quick);
            SortMachine.SelfTest(100000, 101, SortMachine.Method.Merge);
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }

        /// <summary>
        /// Outputs elements of any array of integers to console.
        /// </summary>
        /// <param name="array">
        /// Source array to display.
        /// </param>
        public static void Display(int[] array)
        {
            if (array == null)
            {
                Console.WriteLine("Array is null");
                return;
            }

            foreach (int a in array)
            {
                Console.Write($"{a} ");
            }

            Console.WriteLine();
        }
    }
}