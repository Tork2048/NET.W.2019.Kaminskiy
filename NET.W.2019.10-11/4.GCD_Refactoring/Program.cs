// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GCD
{
    using System;

    /// <summary>
    /// Class that contains entry poit (Main).
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">
        /// Start parameters.
        /// </param>
        public static void Main(string[] args)
        {
            int time;
            int result = GCD_Calculation.GetGCD(GCD_Calculation.GetGCDForTwo, out time, 715, 627, 6259, 858, 8679, 28259);
            Console.WriteLine(result);
            Console.WriteLine($"Calculation time - {time} nanoseconds");
            Console.ReadKey();
        }
    }
}
