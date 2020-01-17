using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace FilterDigit.Tests
{
    /// <summary>
    /// Test class.
    /// </summary>
    [TestFixture]
    public class Tests
    {
        private static TestData[] testContent = new TestData[]
        {
            new TestData
            {
                Source = new List<int> { 1, 2, 3, 4, 5, 6, 68, 69, 15, 8237 },
                ExpectedResult = new List<int> { 68, 8237 },
                Digit = 8,
            },
            new TestData
            {
                Source = new List<int> { 1, 49, 34, 4, 51, 63, 68, 69, 158, 8237, 300 },
                ExpectedResult = new List<int> { 34, 63, 8237, 300 },
                Digit = 3,
            },
            new TestData
            {
                Source = new List<int> { 39, 45, 777, 2346332, 39, 674, 2398, 3958, 3214, 2398 },
                ExpectedResult = new List<int> { 39, 2398, 3958 },
                Digit = 9,
            },

            new TestData
            {
                Source = new List<int> { 1, 2, 3, 4, 5, 6, 8, 9, 0 },
                ExpectedResult = new List<int> { },
                Digit = 7,
            },
        };

        /// <summary>
        /// Mthod to test FilterDigitMethod.
        /// </summary>
        /// <param name="content">
        /// Instance of test data class.
        /// </param>
        [Test]
        [TestCaseSource("testContent")]
        public void ListTest(TestData content)
        {
            FilterDigit.DigitsFilter.FilterDigit(content.Source, content.Digit);
            Assert.That(content.Source, Is.EqualTo(content.ExpectedResult));
        }

        /// <summary>
        /// Method tests exception thrown by FilterDigit.
        /// </summary>
        /// <param name="list">
        /// List of numbers to operate.
        /// </param>
        /// <param name="digit">
        /// Digit to filter.
        /// </param>
        [TestCase(null, 6)]
        public void ExceptionTest(List<int> list, int digit)
        {
            Assert.That(() => FilterDigit.DigitsFilter.FilterDigit(list, digit), Throws.TypeOf<ArgumentNullException>());
        }
    }
}
