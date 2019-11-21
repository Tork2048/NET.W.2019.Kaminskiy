using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GCD.Tests
{
    [TestFixture]
    public class Tests
    {
        [TestCase(GCD_Calculation.Alg_option.Euclidean, 715, 627, 6259, 858, 8679, 28259, ExpectedResult = 11)]
        [TestCase(GCD_Calculation.Alg_option.Stein, 715, 627, 6259, 858, 8679, 28259, ExpectedResult = 11)]
        [TestCase(GCD_Calculation.Alg_option.Euclidean, 723078, 85, 5559, 15181, ExpectedResult = 17)]
        [TestCase(GCD_Calculation.Alg_option.Stein, 723078, 85, 5559, 15181, ExpectedResult = 17)]
        public int Test_GCD_Calculation(GCD_Calculation.Alg_option option, params int[] integers)
        {
            return GCD_Calculation.GetGCD(option, integers);
        }

        [TestCase(GCD.GCD_Calculation.Alg_option.Euclidean, 0,0,0,0,0,0,0)]
        [TestCase(GCD.GCD_Calculation.Alg_option.Stein, 0, 0, 0, 0, 0, 0, 0)]
        public void GCD_Exception_Test(GCD_Calculation.Alg_option option, params int[] integers)
        {
            Assert.That(() => GCD_Calculation.GetGCD(option, integers), Throws.TypeOf<ArgumentException>());
        }
    }
}
