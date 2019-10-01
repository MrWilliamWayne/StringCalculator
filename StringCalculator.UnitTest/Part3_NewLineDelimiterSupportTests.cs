using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Domain.Classes;

namespace StringCalculator.UnitTest
{
    [TestClass]
    public class Part3_NewLineDelimiterSupportTests : StringCalculatorUnitTestBase
    {
        [TestMethod]
        public void EnvironmentNewLineCharacterSupported()
        {
            var testInput = $"1{Environment.NewLine}5";
            var expectedResult = new StringCalculationResult(6, "1+5");
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void NewLineCharacterSupported()
        {
            const string testInput = "4\n9";
            var expectedResult = new StringCalculationResult(13, "4+9");
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void TextNewLineCharacterSupported()
        {
            const string testInput = "2\\n8";
            var expectedResult = new StringCalculationResult(10, "2+8");
            RunTest(testInput, expectedResult);
        }
    }
}
