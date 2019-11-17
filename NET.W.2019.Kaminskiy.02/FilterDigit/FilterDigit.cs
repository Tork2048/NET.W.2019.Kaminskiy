using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 68, 69, 15, 8237 };
            Console.WriteLine("Original list:");
            Display_list(list);

            try
            {
                FilterDigit(list, 1);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.WriteLine("Result:");
            Display_list(list);
            Console.ReadKey();
        }
        /// <summary>
        /// Simple method that checks if number contains given digit
        /// </summary>
        /// <param name="number">
        /// number to check in
        /// </param>
        /// <param name="digit">
        /// digit that we look for
        /// </param>
        /// <returns>
        /// true if number found, false otherwise.
        /// </returns>
        public static bool Check_digits(int number, int digit)
        {
            while (true)
            {
                if (number % 10 == digit)
                {
                    return true;
                }
                if (number / 10 != 0)
                {
                    number /= 10;
                }
                else
                {
                    break;
                }
            }
            return false;
        }

        /// <summary>
        /// Method looks for and removes numbers that contain specific digit
        /// </summary>
        /// <param name="list">
        /// List of integers we look in
        /// </param>
        /// <param name="digit">
        /// digit that we look for
        /// </param>
        public static void FilterDigit(List<int> list, int digit)
        {
            if(list == null)
            {
                throw new ArgumentNullException();
            }
            int k = 0;
            while (k < list.Count)
            {
                if (Check_digits(list[k], digit) && !Number_exists(list, k))
                {
                    k++;
                }
                else
                {
                    list.RemoveAt(k);
                }
            }

        }

        /// <summary>
        /// Displays List on console
        /// </summary>
        /// <param name="list">
        /// List of integers to display
        /// </param>
        public static void Display_list(List<int> list)
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

        /// <summary>
        /// Method checks if list[0..k-1] already contains number list[k]. Required to remove repeating elemens in List
        /// </summary>
        /// <param name="list">
        /// List of integers
        /// </param>
        /// <param name="k">
        /// current index in FilterDigit method
        /// </param>
        /// <returns>
        /// true if element exists, false otherwise
        /// </returns>
        private static bool Number_exists(List<int> list, int k)
        {
            for (int i = 0; i < k; i++)
            {
                if (list[i] == list[k])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
