using NUnit.Framework;

namespace Polynomial.Tests
{
    /// <summary>
    /// Test class.
    /// </summary>
    [TestFixture]
    public class Tests
    {
        private static TestData[] testArray = new TestData[]
            {
                new TestData()
                {
                    FirstPolynom = new Polynom(3, 8, -4, 1),
                    SecondPolynom = new Polynom(0, 77, 8),
                    ExpectedAddResult = new Polynom(3, 85, 4, 1),
                    ExpectedSubtractResult = new Polynom(3, -69, -12, 1),
                    ExpectedMultiplyResult = new Polynom(0, 231, 640, -244, 45, 8),
                    ExpectedEqualResult = false,
                    ExpectedHashCodeResult = 3,
                    ExpectedToStringResult = "x^3-4x^2+8x+3",
                },
                new TestData()
                {
                    FirstPolynom = new Polynom(2, -1, -7, 1),
                    SecondPolynom = new Polynom(8),
                    ExpectedAddResult = new Polynom(10, -1, -7, 1),
                    ExpectedSubtractResult = new Polynom(-6, -1, -7, 1),
                    ExpectedMultiplyResult = new Polynom(16, -8, -56, 8),
                    ExpectedEqualResult = false,
                    ExpectedHashCodeResult = 3,
                    ExpectedToStringResult = "x^3-7x^2-x+2",
                },
                new TestData()
                {
                    FirstPolynom = new Polynom(1, 0, 0, 0, 3),
                    SecondPolynom = new Polynom(1, 0, 0, 0, 3),
                    ExpectedAddResult = new Polynom(2, 0, 0, 0, 6),
                    ExpectedSubtractResult = new Polynom(0),
                    ExpectedMultiplyResult = new Polynom(1, 0, 0, 0, 6, 0, 0, 0, 9),
                    ExpectedEqualResult = true,
                    ExpectedHashCodeResult = 4,
                    ExpectedToStringResult = "3x^4+1",
                },
            };

        /// <summary>
        /// Test addition.
        /// </summary>
        /// <param name="data">
        /// Instance of test data class.
        /// </param>
        [Test]
        [TestCaseSource("testArray")]
        public void TestAdd(TestData data)
        {
            Polynom result = data.FirstPolynom + data.SecondPolynom;
            Assert.That(result, Is.EqualTo(data.ExpectedAddResult));
        }

        /// <summary>
        /// Test subtraction.
        /// </summary>
        /// <param name="data">
        /// Instance of test data class.
        /// </param>
        [Test]
        [TestCaseSource("testArray")]
        public void TestSubtract(TestData data)
        {
            Polynom result = data.FirstPolynom - data.SecondPolynom;
            Assert.That(result, Is.EqualTo(data.ExpectedSubtractResult));
        }

        /// <summary>
        /// Test multiplication.
        /// </summary>
        /// <param name="data">
        /// Instance of test data class.
        /// </param>
        [Test]
        [TestCaseSource("testArray")]
        public void TestMultiply(TestData data)
        {
            Polynom result = data.FirstPolynom * data.SecondPolynom;
            Assert.That(result, Is.EqualTo(data.ExpectedMultiplyResult));
        }

        /// <summary>
        /// Test equality.
        /// </summary>
        /// <param name="data">
        /// Instance of test data class.
        /// </param>
        [Test]
        [TestCaseSource("testArray")]
        public void TestEqual(TestData data)
        {
            bool result = data.FirstPolynom.Equals(data.SecondPolynom);
            Assert.That(result, Is.EqualTo(data.ExpectedEqualResult));
        }

        /// <summary>
        /// Test == operator.
        /// </summary>
        /// <param name="data">
        /// Instance of test data class.
        /// </param>
        [Test]
        [TestCaseSource("testArray")]
        public void TestEqualOperator(TestData data)
        {
            bool result = data.FirstPolynom == data.SecondPolynom;
            Assert.That(result, Is.EqualTo(data.ExpectedEqualResult));
        }

        /// <summary>
        /// Test ToString method.
        /// </summary>
        /// <param name="data">
        /// Instance of test data class.
        /// </param>
        [Test]
        [TestCaseSource("testArray")]
        public void TestToString(TestData data)
        {
            string result = data.FirstPolynom.ToString();
            Assert.That(result, Is.EqualTo(data.ExpectedToStringResult));
        }

        /// <summary>
        /// Test GetHashCode method.
        /// </summary>
        /// <param name="data">
        /// Instance of test data class.
        /// </param>
        [Test]
        [TestCaseSource("testArray")]
        public void TestGetHashCode(TestData data)
        {
            int result = data.FirstPolynom.GetHashCode();
            Assert.That(result, Is.EqualTo(data.ExpectedHashCodeResult));
        }
    }
}
