using System.Collections.Generic;

namespace FilterDigit.Tests
{
    /// <summary>
    /// Test data class.
    /// </summary>
    public class TestData
    {
        /// <summary>
        /// Gets or sets source list of numbers.
        /// </summary>
        /// <value>
        /// Source list of numbers.
        /// </value>
        public List<int> Source { get; set; }

        /// <summary>
        /// Gets or sets result list of numbers.
        /// </summary>
        /// <value>
        /// Result list of numbers.
        /// </value>
        public List<int> ExpectedResult { get; set; }

        /// <summary>
        /// Gets or sets digit to filter.
        /// </summary>
        /// <value>
        /// Digit to filter.
        /// </value>
        public int Digit { get; set; }
    }
}
