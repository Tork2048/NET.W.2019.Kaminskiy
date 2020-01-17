using System;

namespace Polynomial
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
            Polynom x1 = new Polynom();
            Polynom x2 = new Polynom();
            Polynom x3 = x1 * x2;
            string str = x3.ToString();
            for (int i = 0; i < x3.ArrayOfFactors.Length; i++)
            {
                Console.Write($"{x3.ArrayOfFactors[i]} ");
            }

            Console.WriteLine();
            Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}
