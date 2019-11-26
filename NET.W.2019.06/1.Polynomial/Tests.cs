using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Polynomial.Tests
{
    [TestFixture]
    public class Tests
    {
        private static TestData[] testArray = new TestData[]
            {
                new TestData()
                {
                    P1 = new Polynom(3, 8, -4, 1),
                    P2 = new Polynom(0, 77, 8),
                    Expected_Add = new Polynom(3, 85, 4, 1),
                    Expected_Subtract = new Polynom(3, -69, -12, 1),
                    Expected_Multiply = new Polynom(0, 231, 640, -244, 45, 8),
                    Expected_Equal = false,
                    Expected_HashCode = 3,
                    Expected_ToString = "x^3-4x^2+8x+3"
                },
                new TestData()
                {
                    P1 = new Polynom(2, -1, -7, 1),
                    P2 = new Polynom(8),
                    Expected_Add = new Polynom(10, -1, -7, 1),
                    Expected_Subtract = new Polynom(-6, -1, -7, 1),
                    Expected_Multiply = new Polynom(16, -8, -56, 8),
                    Expected_Equal = false,
                    Expected_HashCode = 3,
                    Expected_ToString = "x^3-7x^2-x+2"
                },
                new TestData()
                {
                    P1 = new Polynom(1, 0, 0, 0, 3),
                    P2 = new Polynom(1, 0, 0, 0, 3),
                    Expected_Add = new Polynom(2, 0, 0, 0, 6),
                    Expected_Subtract = new Polynom(0),
                    Expected_Multiply = new Polynom(1, 0, 0, 0, 6, 0, 0, 0, 9),
                    Expected_Equal = true,
                    Expected_HashCode = 4,
                    Expected_ToString = "3x^4+1"
                }                
            };
            
        [Test, TestCaseSource("testArray")]
        public void TestAdd(TestData data)
        {
            Polynom result = data.P1 + data.P2;
            Assert.That(result, Is.EqualTo(data.Expected_Add));
        }

        [Test, TestCaseSource("testArray")]
        public void TestSubtract(TestData data)
        {
            Polynom result = data.P1 - data.P2;
            Assert.That(result, Is.EqualTo(data.Expected_Subtract));
        }

        [Test, TestCaseSource("testArray")]
        public void TestMultiply(TestData data)
        {
            Polynom result = data.P1 * data.P2;
            Assert.That(result, Is.EqualTo(data.Expected_Multiply));
        }

        [Test, TestCaseSource("testArray")]
        public void TestEqual(TestData data)
        {
            bool result = data.P1.Equals(data.P2);
            Assert.That(result, Is.EqualTo(data.Expected_Equal));
        }

        [Test, TestCaseSource("testArray")]
        public void TestEqualOperator(TestData data)
        {
            bool result = data.P1 == data.P2;
            Assert.That(result, Is.EqualTo(data.Expected_Equal));
        }

        [Test, TestCaseSource("testArray")]
        public void TestToString(TestData data)
        {
            string result = data.P1.ToString();
            Assert.That(result, Is.EqualTo(data.Expected_ToString));
        }

        [Test, TestCaseSource("testArray")]
        public void TestGetHashCode(TestData data)
        {
            int result = data.P1.GetHashCode();
            Assert.That(result, Is.EqualTo(data.Expected_HashCode));
        }
    }
}
