using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;




namespace InsertBits.Tests
{
    [TestFixture]
    public class Tests
    {
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(105, 37, 2, 7, ExpectedResult = 149)]
        [TestCase(873, 37, 2, 7, ExpectedResult = 917)]
        [TestCase(873, 37, 2, 9, ExpectedResult = 149)]
        [TestCase(873, -37, 2, 11, ExpectedResult = 3949)]
        
        public int ValuesTest(int val1, int val2, int i, int j)
        {
            return Program.InsertNumber(val1, val2, i, j);
        }

        [TestCase(34,20,15,1)]
        public void ExceptionTest(int val1, int val2, int i, int j)
        {
            Assert.That(() => Program.InsertNumber(val1, val2, i, j), Throws.TypeOf<ArgumentException>());
        }
    }
}
