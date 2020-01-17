using System;
using System.Collections.Generic;

namespace FilterDigit
{
    /// <summary>
    /// Contains entry point.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        public static void Main()
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 68, 69, 15, 8237 };
            Console.WriteLine("Original list:");
            DisplayList(list);

            try
            {
                DigitsFilter.FilterDigit(list, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Result:");
            DisplayList(list);
            Console.ReadKey();
        }

        /// <summary>
        /// Displays List on console.
        /// </summary>
        /// <param name="list">
        /// List of integers to display.
        /// </param>
        public static void DisplayList(List<int> list)
        {
            if (list == null || list.Count == 0)
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                foreach (var x in list)
                {
                    Console.Write($"{x} ");
                }

                Console.WriteLine();
            }
        }
    }
}
