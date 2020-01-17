namespace Polynomial.Tests
{
    /// <summary>
    /// Test data class.
    /// </summary>
    public class TestData
    {
        /// <summary>
        /// Gets or sets first polynomial.
        /// </summary>
        /// <value>
        /// First polynomial.
        /// </value>
        public Polynom FirstPolynom { get; set; }

        /// <summary>
        /// Gets or sets second polynomial.
        /// </summary>
        /// <value>
        /// Second polynomial.
        /// </value>
        public Polynom SecondPolynom { get; set; }

        /// <summary>
        /// Gets or sets excpected addition result.
        /// </summary>
        /// <value>
        /// Excpected addition result.
        /// </value>
        public Polynom ExpectedAddResult { get; set; }

        /// <summary>
        /// Gets or sets expected subtraction result.
        /// </summary>
        /// <value>
        /// Expected subtraction result.
        /// </value>
        public Polynom ExpectedSubtractResult { get; set; }

        /// <summary>
        /// Gets or sets expected result.
        /// </summary>
        /// <value>
        /// Expected result.
        /// </value>
        public Polynom ExpectedMultiplyResult { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether polynomials are equil.
        /// </summary>
        /// <value>
        /// A value indicating whether polynomials are equil.
        /// </value>
        public bool ExpectedEqualResult { get; set; }

        /// <summary>
        /// Gets or sets expected hashcode.
        /// </summary>
        /// <value>
        /// Expected hashcode.
        /// </value>
        public int ExpectedHashCodeResult { get; set; }

        /// <summary>
        /// Gets or sets expected ToString result.
        /// </summary>
        /// <value>
        /// Expected ToString result.
        /// </value>
        public string ExpectedToStringResult { get; set; }
    }
}
