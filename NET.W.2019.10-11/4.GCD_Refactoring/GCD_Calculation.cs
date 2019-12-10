// <copyright file="GCD_Calculation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GCD
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Class contains methods that calculate Greates common divisor for n signed integers.
    /// </summary>
    public static class GCD_Calculation
    {
        /// <summary>
        /// Method that calculates GCD for any number of integer values.
        /// </summary>
        /// <param name="getGCDForTwo">
        /// delegate that will take GCD calculation method.
        /// </param>
        /// <param name="integers">
        /// params int[].
        /// </param>
        /// <returns>
        /// GCD for params int[].
        /// </returns>
        public static int GetGCD(Func<int, int, int> getGCDForTwo, params int[] integers)
        {
            int gcd = integers[0];
            for (int i = 1; i < integers.Length; i++)
            {
                if (integers[i] == 0 && gcd == 0)
                {
                    continue; // skips iteration if both arguments are zero
                }

                gcd = getGCDForTwo(gcd, integers[i]);
            }

            if (gcd == 0)
            {
                throw new ArgumentException();
            }

            return gcd;
        }

        /// <summary>
        /// Overloaded version of method designed to calculate runtime for given algorithm.
        /// </summary>
        /// <param name="getGCDForTwo">
        /// Delegate that defines calculation algorithm(Euclidean, Stein).
        /// </param>
        /// <param name="time">
        /// returns runtime(out).
        /// </param>
        /// <param name="integers">
        /// params int[].
        /// </param>
        /// <returns>
        /// GCD.
        /// </returns>
        public static int GetGCD(Func<int, int, int> getGCDForTwo, out int time, params int[] integers)
        {
            var watch = new Stopwatch();
            int jit_compile = getGCDForTwo(187, 319);
            watch.Start();
            int gcd = 0;

            // algorithms take less than millisecond.
            // in order to calculate runtime it runs algorithm a million times.
            for (int j = 0; j < 1000000; j++)
            {
                gcd = GetGCD(getGCDForTwo, integers);
            }

            watch.Stop();
            time = (int)watch.ElapsedMilliseconds;
            return gcd;
        }

        /// <summary>
        /// Method calculates GCD for 2 integers with Euclidean algorithm.
        /// </summary>
        /// <param name="a">
        /// first number.
        /// </param>
        /// <param name="b">
        /// second number.
        /// </param>
        /// <returns>
        /// GCD.
        /// </returns>
        public static int GetGCDForTwo(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException();
            }

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            int remainder = 1;
            int gcd = 0;
            if (a / b == 0)
            {
                gcd = a;
                a = b;
                b = gcd;
            }

            while (remainder > 0)
            {
                remainder = a % b;
                gcd = b;
                b = remainder;
                a = gcd;
            }

            return Math.Abs(gcd);
        }

        /// <summary>
        /// Method calculates GCD for 2 integers with Stein algorithm(Binary).
        /// </summary>
        /// <param name="a">
        /// First number.
        /// </param>
        /// <param name="b">
        /// Second Number.
        /// </param>
        /// <returns>
        /// GCD for two numbers.
        /// </returns>
        public static int GetGCDForTwoBinary(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException();
            }

            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == 0)
            {
                return b;  // everything divides zero
            }

            if (b == 0)
            {
                return a;  // everything divides zero
            }

            int k = 0;
            while (((a | b) & 1) == 0)
            {
                a >>= 1; // right shift multiplies number by 2;
                b >>= 1;
                k++;
            }

            while ((a & 1) == 0)
            {
                a >>= 1;
            }

            do
            {
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }

                if (a > b)
                {
                    int temp = a;
                    a = b;
                    b = temp;
                }

                b -= a;
            }
            while (b != 0);
            return a << k;
        }
    }
}
