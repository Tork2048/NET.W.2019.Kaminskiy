using System;

namespace GCD
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
            int time;
            int result = GCDCalculation.GetGCD(GCDCalculation.AlgOption.Stein, out time, 715, 627, 6259, 858, 8679, 28259);
            Console.WriteLine(result);
            Console.WriteLine($"Calculation time - {time} nanoseconds");
            Console.ReadKey();
        }
    }
}
