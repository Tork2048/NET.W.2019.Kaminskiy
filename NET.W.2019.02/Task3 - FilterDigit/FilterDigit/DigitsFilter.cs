using System;
using System.Collections.Generic;

namespace FilterDigit
{
    /// <summary>
    /// Class designed to filter numbers.
    /// </summary>
    public static class DigitsFilter
    {
        /// <summary>
        /// Method looks for and removes numbers that contain specific digit.
        /// </summary>
        /// <param name="list">
        /// List of integers we look in.
        /// </param>
        /// <param name="digit">
        /// digit that we look for.
        /// </param>
        public static void FilterDigit(List<int> list, int digit)
        {
            if (list == null)
            {
                throw new ArgumentNullException();
            }

            int listIndex = 0;
            while (listIndex < list.Count)
            {
                if (CheckDigits(list[listIndex], digit) && !NumberExists(list, listIndex))
                {
                    listIndex++;
                }
                else
                {
                    list.RemoveAt(listIndex);
                }
            }
        }

        /// <summary>
        /// Method checks if list[0..k-1] already contains number list[k]. Required to remove repeating elemens in List.
        /// </summary>
        /// <param name="list">
        /// List of integers.
        /// </param>
        /// <param name="indexInList">
        /// current index in FilterDigit method.
        /// </param>
        /// <returns>
        /// true if element exists, false otherwise.
        /// </returns>
        private static bool NumberExists(List<int> list, int indexInList)
        {
            for (int i = 0; i < indexInList; i++)
            {
                if (list[i] == list[indexInList])
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Simple method that checks if number contains given digit.
        /// </summary>
        /// <param name="number">
        /// number to check in.
        /// </param>
        /// <param name="digit">
        /// digit that we look for.
        /// </param>
        /// <returns>
        /// true if number found, false otherwise.
        /// </returns>
        private static bool CheckDigits(int number, int digit)
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
    }
}
