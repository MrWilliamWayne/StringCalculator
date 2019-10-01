using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Domain.Classes;

namespace StringCalculator.UnitTest.StringCalculatorTests
{
    [TestClass]
    public class Part6_SupportSingleCustomDelimiterTests : StringCalculatorUnitTestBase
    {
        [TestMethod]
        public void AllowASingleCustomDelimiter()
        {
            var testInput = $"//;\n1;5,1000{Environment.NewLine}1001,5000";
            var expectedResult = new StringCalculationResult(1006, "1+5+1000+0+0");
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void AllowNumericCustomDelimiter()
        {
            var testInput = $"//5\n1,5,1000{Environment.NewLine}1001,60510";
            var expectedResult = new StringCalculationResult(1071, "1+0+0+1000+0+60+10");
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void MultiCharacterDelimitersAreNotSupportedWithoutBrackets()
        {
            var testInput = $"//abc\n1,abc,1000{Environment.NewLine}1001,60abc10";
            var expectedResult = new StringCalculationResult(1001, "1+0+1000+0+0");
            RunTest(testInput, expectedResult);
        }
    }
}
