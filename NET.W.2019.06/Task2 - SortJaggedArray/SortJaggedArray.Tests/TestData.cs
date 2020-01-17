namespace SortJaggedArray.Tests
{
    /// <summary>
    /// Test data clas.
    /// </summary>
    public class TestData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestData"/> class.
        /// </summary>
        /// <param name="source">
        /// Source array.
        /// </param>
        /// <param name="result">
        /// Expected result array.
        /// </param>
        /// <param name="orderoption">
        /// Order option.
        /// </param>
        /// <param name="option">
        /// Sort criteria.
        /// </param>
        public TestData(int[][] source, int[][] result, SortClass.SortOrderOption orderoption, SortClass.SortOption option)
        {
            this.SourceArray = source;
            this.ExpectedArray = result;
            this.OrderOption = orderoption;
            this.Option = option;
        }

        /// <summary>
        /// Gets or sets source array.
        /// </summary>
        /// <value>
        /// Source array.
        /// </value>
        public int[][] SourceArray { get; set; }

        /// <summary>
        /// Gets or sets expected result array.
        /// </summary>
        /// <value>
        /// Expected result array.
        /// </value>
        public int[][] ExpectedArray { get; set; }

        /// <summary>
        /// Gets or sets order option enumeration.
        /// </summary>
        /// <value>
        /// Order option enumeration.
        /// </value>
        public SortClass.SortOrderOption OrderOption { get; set; }

        /// <summary>
        /// Gets or sets sort criteria enumeration.
        /// </summary>
        /// <value>
        /// Sort criteria enumeration.
        /// </value>
        public SortClass.SortOption Option { get; set; }
    }
}
