using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Domain.Classes;

namespace StringCalculator.UnitTest.StringCalculatorTests
{
    [TestClass]
    public class Part7_MultiCharCustomDelimiterTests : StringCalculatorUnitTestBase
    {
        [TestMethod]
        public void AllowMultiCharCustomDelimiter()
        {
            var testInput = $"//[abc]\n1abc5,1000{Environment.NewLine}1001abc5000";
            var expectedResult = new StringCalculationResult(1006, "1+5+1000+0+0");
            RunTest(testInput, expectedResult);
        }
    }
}
