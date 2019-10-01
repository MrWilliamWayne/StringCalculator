using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.UnitTest.CustomDelimiterExtractorTests
{
    [TestClass]
    public class Part6_SupportSingleCustomDelimiterTests : CustomDelimiterExtractorTestBase
    {
        [TestMethod]
        public void NoCustomDelimiterShouldReturnDefaultDelimiters()
        {
            var testInput = $"1;5,1000{Environment.NewLine}1001,5000";
            var expectedResult = new List<string> { };
            expectedResult.AddRange(_defaultDelimiters);
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void SingleCustomDelimiterShouldReturnDefaultDelimitersAfterCustomDelimiter()
        {
            var testInput = $"//;\n1;5,1000{Environment.NewLine}1001,5000";
            var expectedResult = new List<string> { ";" };
            expectedResult.AddRange(_defaultDelimiters);
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void NumericDelimitersAreSupported()
        {
            var testInput = $"//5\n1;5,1000{Environment.NewLine}1001,5000";
            var expectedResult = new List<string> { "5" };
            expectedResult.AddRange(_defaultDelimiters);
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void MultiCharacterDelimitersAreNotSupportedWithoutBrackets()
        {
            var testInput = $"//abc\n1;5,1000{Environment.NewLine}1001,5000";
            var expectedResult = new List<string> { "a" };
            expectedResult.AddRange(_defaultDelimiters);
            RunTest(testInput, expectedResult);
        }
    }
}
