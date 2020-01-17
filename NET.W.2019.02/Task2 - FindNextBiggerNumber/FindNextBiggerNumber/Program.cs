using System;
using System.Diagnostics;

namespace FindNextBiggerNumber
{
    /// <summary>
    /// Contains entry point.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Netry point.
        /// </summary>
        public static void Main()
        {
            int n = 232743422;
            Console.WriteLine($"Number - {n}");
            var watch = new Stopwatch();
            watch.Start();   // stopwatch to find out runtime;
            int result = NumberSeeker.FindNextBiggerNumber(n);
            watch.Stop();
            Console.WriteLine($"Nearest greater number is {result}");
            Console.WriteLine($"Calculation time - {watch.ElapsedMilliseconds} ms");
            Console.ReadLine();
        }
    }
}
