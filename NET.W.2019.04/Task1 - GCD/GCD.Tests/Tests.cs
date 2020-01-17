using System;
using NUnit.Framework;

namespace GCD.Tests
{
    /// <summary>
    /// Test class for unit testing.
    /// </summary>
    [TestFixture]
    public class Tests
    {
        /// <summary>
        /// GCD calculation method testing.
        /// </summary>
        /// <param name="option">
        /// Algorithm option.
        /// </param>
        /// <param name="integers">
        /// Numbers to calculate GCD for.
        /// </param>
        /// <returns>
        /// GCD.
        /// </returns>
        [TestCase(GCDCalculation.AlgOption.Euclidean, 715, 627, 6259, 858, 8679, 28259, ExpectedResult = 11)]
        [TestCase(GCDCalculation.AlgOption.Stein, 715, 627, 6259, 858, 8679, 28259, ExpectedResult = 11)]
        [TestCase(GCDCalculation.AlgOption.Euclidean, 723078, 85, 5559, 15181, ExpectedResult = 17)]
        [TestCase(GCDCalculation.AlgOption.Stein, 723078, 85, 5559, 15181, ExpectedResult = 17)]
        public int TestGCDCalculation(GCDCalculation.AlgOption option, params int[] integers)
        {
            return GCDCalculation.GetGCD(option, integers);
        }

        /// <summary>
        /// GCD exception test.
        /// </summary>
        /// <param name="option">
        /// Algorithm option.
        /// </param>
        /// <param name="integers">
        /// Numbers to calculate GCD for.
        /// </param>
        [TestCase(GCD.GCDCalculation.AlgOption.Euclidean, 0, 0, 0, 0, 0, 0, 0)]
        [TestCase(GCD.GCDCalculation.AlgOption.Stein, 0, 0, 0, 0, 0, 0, 0)]
        public void GCDExceptionTest(GCDCalculation.AlgOption option, params int[] integers)
        {
            Assert.That(() => GCDCalculation.GetGCD(option, integers), Throws.TypeOf<ArgumentException>());
        }
    }
}
