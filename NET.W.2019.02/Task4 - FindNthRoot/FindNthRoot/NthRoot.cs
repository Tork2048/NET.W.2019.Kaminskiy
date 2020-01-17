using System;

namespace FindNthRoot
{
    /// <summary>
    /// Designed to search Nth root.
    /// </summary>
    public static class NthRoot
    {
        /// <summary>
        /// Calculates Nth root using Newton's method with given precision.
        /// </summary>
        /// <param name="number">
        /// Number to operate with.
        /// </param>
        /// <param name="root">
        /// Given root index.
        /// </param>
        /// <param name="precision">
        /// Given precision.
        /// </param>
        /// <returns>
        /// Nth root from number with given precision.
        /// </returns>
        public static double FindNthRoot(double number, double root, double precision)
        {
            if (root <= 0 || precision >= 1 || precision <= 0 || (number < 0 && root % 2 == 0))
            {
                Console.WriteLine("invalid arguments");
                return number;
            }

            if (root == 1)
            {
                return number;
            }

            double x0 = number / root;
            double x1 = ((number / Math.Pow(x0, root - 1)) + (x0 * (root - 1))) / root;
            while (Math.Abs(x1 - x0) > precision / 10)
            {
                x0 = x1;
                x1 = ((number / Math.Pow(x0, root - 1)) + (x0 * (root - 1))) / root;
            }

            int fractionalDigits = 0;
            while (precision < 1)
            {
                precision *= 10;
                fractionalDigits++;
            }

            return Math.Round(x1, fractionalDigits);
        }
    }
}
