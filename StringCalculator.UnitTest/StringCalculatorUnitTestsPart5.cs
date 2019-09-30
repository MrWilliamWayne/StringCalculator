using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Domain.Classes;

namespace StringCalculator.UnitTest
{
    [TestClass]
    public class StringCalculatorUnitTestsPart5 : StringCalculatorUnitTestBase
    {
        [TestMethod]
        public void IgnoreValuesGreaterThanOneThousand()
        {
            var testInput = $"1,5,1000,1001,5000";
            var expectedResult = new StringCalculationResult(1006, "1+5+1000+0+0");
            RunTest(testInput, expectedResult);
        }
    }
}
