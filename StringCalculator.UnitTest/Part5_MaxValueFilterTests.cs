using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Domain.Classes;

namespace StringCalculator.UnitTest
{
    [TestClass]
    public class Part5_MaxValueFilterTests : StringCalculatorUnitTestBase
    {
        [TestMethod]
        public void IgnoreValuesGreaterThanOneThousand()
        {
            const string testInput = "1,5,1000,1001,5000,10";
            var expectedResult = new StringCalculationResult(1016, "1+5+1000+0+0+10");
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void AllTermsGreaterThanMaxValueShouldPassAsAllZero()
        {
            const string testInput = "10000,5000,1001,5000";
            var expectedResult = new StringCalculationResult(0, "0+0+0+0");
            RunTest(testInput, expectedResult);
        }
    }
}
