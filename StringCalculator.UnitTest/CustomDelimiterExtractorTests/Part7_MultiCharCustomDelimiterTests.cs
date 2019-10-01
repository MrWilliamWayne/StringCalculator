using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.UnitTest.CustomDelimiterExtractorTests
{
    [TestClass]
    public class Part7_MultiCharCustomDelimiterTests : CustomDelimiterExtractorTestBase
    {
        [TestMethod]
        public void AllowMultiCharCustomDelimiter()
        {
            var testInput = $"//[abc]\n1abc5,1000{Environment.NewLine}1001abc5000";
            var expectedResult = new List<string> { "abc" };
            expectedResult.AddRange(_defaultDelimiters);
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void DelimitersNotInBracketsAreIgnoredIfBracketsExist()
        {
            var testInput = $"//;[abc]\n1abc5,1000{Environment.NewLine}1001abc5000";
            var expectedResult = new List<string> { "abc" };
            expectedResult.AddRange(_defaultDelimiters);
            RunTest(testInput, expectedResult);
        }
    }
}
