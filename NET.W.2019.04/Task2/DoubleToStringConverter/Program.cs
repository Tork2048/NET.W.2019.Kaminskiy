using System;

namespace DoubleToString
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
            double x = double.MinValue;
            Console.WriteLine(x.ConvertToString());

            Console.ReadKey();
        }
    }
}
