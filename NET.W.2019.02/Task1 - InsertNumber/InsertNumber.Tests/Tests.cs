using System;
using NUnit.Framework;

namespace InsertBits.Tests
{
    /// <summary>
    /// Test class.
    /// </summary>
    [TestFixture]
    public class Tests
    {
        /// <summary>
        /// Tests InsertNumber method with values.
        /// </summary>
        /// <param name="val1">
        /// Value 1.
        /// </param>
        /// <param name="val2">
        /// Value 2.
        /// </param>
        /// <param name="i">
        /// Lower bit position.
        /// </param>
        /// <param name="j">
        /// Higher bit position.
        /// </param>
        /// <returns>
        /// Result number.
        /// </returns>
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(105, 37, 2, 7, ExpectedResult = 149)]
        [TestCase(873, 37, 2, 7, ExpectedResult = 917)]
        [TestCase(873, 37, 2, 9, ExpectedResult = 149)]
        [TestCase(873, -37, 2, 11, ExpectedResult = 3949)]
        public int ValuesTest(int val1, int val2, int i, int j)
        {
            return InsertNumber.Inserter.InsertNumber(val1, val2, i, j);
        }

        /// <summary>
        /// Tests exception thrown by InsertNumber method.
        /// </summary>
        /// <param name="val1">
        /// Value 1.
        /// </param>
        /// <param name="val2">
        /// Value 2.
        /// </param>
        /// <param name="i">
        /// Lower bit position.
        /// </param>
        /// <param name="j">
        /// Higher bit position.
        /// </param>
        [TestCase(34, 20, 15, 1)]
        public void ExceptionTest(int val1, int val2, int i, int j)
        {
            Assert.That(() => InsertNumber.Inserter.InsertNumber(val1, val2, i, j), Throws.TypeOf<ArgumentException>());
        }
    }
}
