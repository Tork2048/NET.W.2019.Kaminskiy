// <copyright file="Tests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GCD.Tests
{
    using System;
    using NUnit.Framework;

    /// <summary>
    /// Class for tests.
    /// </summary>
    [TestFixture]
    public class Tests
    {
        private static readonly Tuple<Func<int, int, int>, int, int[]>[] Testdata = new Tuple<Func<int, int, int>, int, int[]>[]
        {
            new Tuple<Func<int, int, int>, int, int[]>(GCD_Calculation.GetGCDForTwo, 11, new int[] { 715, 627, 6259, 858, 8679, 28259 }),
            new Tuple<Func<int, int, int>, int, int[]>(GCD_Calculation.GetGCDForTwoBinary, 11, new int[] { 715, 627, 6259, 858, 8679, 28259 }),
            new Tuple<Func<int, int, int>, int, int[]>(GCD_Calculation.GetGCDForTwo, 17, new int[] { 723078, 85, 5559, 15181 }),
            new Tuple<Func<int, int, int>, int, int[]>(GCD_Calculation.GetGCDForTwoBinary, 17, new int[] { 723078, 85, 5559, 15181 }),
        };

        private static readonly Tuple<Func<int, int, int>, int[]>[] TestdataException = new Tuple<Func<int, int, int>, int[]>[]
        {
            new Tuple<Func<int, int, int>, int[]>(GCD_Calculation.GetGCDForTwo, new int[] { 0, 0, 0, 0, 0, 0, 0 }),
            new Tuple<Func<int, int, int>, int[]>(GCD_Calculation.GetGCDForTwoBinary, new int[] { 0, 0, 0, 0, 0, 0, 0 }),
        };

        /// <summary>
        /// GCD calculation test method.
        /// </summary>
        /// <param name="tuple">
        /// Tuple with arguments
        /// </param>
        [Test]
        [TestCaseSource("Testdata")]
        public void Test_GCD_Calculation(Tuple<Func<int, int, int>, int, int[]> tuple)
        {
            int gcd = GCD_Calculation.GetGCD(tuple.Item1, tuple.Item3);
            Assert.That(gcd, Is.EqualTo(tuple.Item2));
        }

        /// <summary>
        /// Exception test method
        /// </summary>
        /// <param name="tuple">
        /// Tuple with arguments.
        /// </param>
        [Test]
        [TestCaseSource("TestdataException")]
        public void GCD_Exception_Test(Tuple<Func<int, int, int>, int[]> tuple)
        {
            Assert.That(() => GCD_Calculation.GetGCD(tuple.Item1, tuple.Item2), Throws.TypeOf<ArgumentException>());
        }
    }
}
