using System;

namespace FindNthRoot
{
    /// <summary>
    /// Contains entry point.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        public static void Main()
        {
            double x = NthRoot.FindNthRoot(-338, 3, 0.0001);
            Console.WriteLine(x);
            Console.ReadKey();
        }
    }
}
