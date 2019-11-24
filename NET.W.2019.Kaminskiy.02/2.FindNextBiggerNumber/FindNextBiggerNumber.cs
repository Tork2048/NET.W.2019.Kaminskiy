using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FindNumber
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = 232743422;           
            Console.WriteLine($"Number - {n}");
            var watch = new Stopwatch();
            watch.Start();   //stopwatch to find out runtime;
            int result = FindNextBiggerNumber(n);
            watch.Stop();
            Console.WriteLine($"Nearest greater number is {result}");
            Console.WriteLine($"Calculation time - {watch.ElapsedMilliseconds} ms");
            Console.ReadLine();
        }
        /// <summary>
        /// Simple method that turns number into array of its digits
        /// </summary>
        /// <param name="number">
        /// integer number
        /// </param>
        /// <returns>
        /// array of integers that represents number as its digits in the same order
        /// </returns>
        public static int[] Extract_digits(int number)
        {
            int[] temp_array = new int[10]; //maximum number of digits for int value is 10
            int k = 0;
            while (true)
            {
                temp_array[k++] = number % 10;
                if (number / 10 != 0)
                {
                    number /= 10;
                }
                else
                {
                    break;
                }
            }
            //new array is created to invert digit order and have a correct array length
            int[] array = new int[k];
            int q = k - 1;
            for (int i = 0; i < k; i++)
            {
                array[i] = temp_array[q--];
            }
            return array;
        }
        /// <summary>
        /// Method searches for the next greater number that consitsts of digits of the original number
        /// </summary>
        /// <param name="number">
        /// interger number
        /// </param>
        /// <returns>
        /// next greater number
        /// </returns>        
        public static int FindNextBiggerNumber(int number)
        {
            if (number < 0)
            {
                number *= -1;
                Console.WriteLine("Negative numbers are not allowed. Method will work with absolute value {0}", number);
            }
            int[] array = Extract_digits(number);
            if (array.Length == 1)
            {
                return -1;
            }                        
            int result = -1;
            while (Generate_set(array))  //turns array into next permutation in lexicographic order which is what we need (nearest greater number)
            {
                if (array[0] == 0) //first digit cannot be zero
                {
                    continue;
                }
                int constructed_number = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    constructed_number += array[i] * ((int)(Math.Pow(10, array.Length - 1 - i))); //restores number from array
                }
                if (constructed_number - number > 0) //excludes equil and lesser numbers, looking for the nearest greater number.
                {                    
                    result = constructed_number;
                    break; //greatest nearest number found - breaking the cycle
                }                
            }
            return result;
        }
        /// <summary>
        /// simple method that swaps elements in the array
        /// </summary>
        /// <param name="array">
        /// source array with ref modifier
        /// </param>
        /// <param name="i">
        /// array index
        /// </param>
        /// <param name="j">
        /// array index
        /// </param>
        public static void swap_elements(int[] array, int i, int j)
        {
            if (i >= array.Length || j >= array.Length || j < 0 || i < 0)
            {
                Console.WriteLine("Swap method critical error - out of range.");
                return;
            }
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        /// <summary>
        /// Next Permutation: Narayana Pandita’s algorithm.
        /// </summary>
        /// <param name="array">
        /// source array with ref modifier
        /// </param>
        /// <returns>
        /// next lexicographic permutation of source array
        /// </returns>
        private static bool Generate_set(int[] array)
        {
            int array_length = array.Length;
            int cur1 = array_length - 2;
            while (cur1 != -1 && array[cur1] >= array[cur1 + 1])
            {
                cur1--;
            }
            if (cur1 == -1)
            {
                return false; //out of permutations
            }
            int cur2 = array_length - 1;
            while (array[cur1] >= array[cur2])
            {
                cur2--;
            }
            swap_elements(array, cur1, cur2);
            int left = cur1 + 1;
            int right = array_length - 1;
            while (left < right)
            {
                swap_elements(array, left++, right--);
            }
            return true;
        }
    }
}
