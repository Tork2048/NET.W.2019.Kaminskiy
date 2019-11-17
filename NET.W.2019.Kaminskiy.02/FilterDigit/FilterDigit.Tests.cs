using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Filter.Tests
{
    [TestFixture]
    public class Tests
    {
        static TestData[] test_content = new TestData[]
        {
            new TestData
            {
                Source = new List<int> { 1, 2, 3, 4, 5, 6, 68, 69, 15, 8237 },
                Expected_result = new List<int> {68, 8237},
                Digit = 8
            },
            new TestData
            {
                Source = new List<int> { 1, 49, 34, 4, 51, 63, 68, 69, 158, 8237, 300 },
                Expected_result = new List<int> {34, 63, 8237, 300},
                Digit = 3
            },
            new TestData
            {
                Source = new List<int> { 39,45,777,2346332, 39, 674, 2398, 3958, 3214, 2398},
                Expected_result = new List<int> {39, 2398, 3958},
                Digit = 9
            },

            new TestData
            {
                Source = new List<int> { 1,2,3,4,5,6,8,9,0},
                Expected_result = new List<int> {},
                Digit = 7
            },
        };

        [Test, TestCaseSource("test_content")]
        public void ListTest(TestData content)
        {
            Program.FilterDigit(content.Source, content.Digit);
            Assert.That(content.Source, Is.EqualTo(content.Expected_result));
        }

        [TestCase(null, 6)]
        public void ExceptionTest(List<int> list, int digit)
        {
            Assert.That(() => Program.FilterDigit(list, digit), Throws.TypeOf<ArgumentNullException>());
        }

    }

    public class TestData
    {
        public List<int> Source { get; set; }
        public List<int> Expected_result { get; set; }
        public int Digit { get; set; }
    }

}
