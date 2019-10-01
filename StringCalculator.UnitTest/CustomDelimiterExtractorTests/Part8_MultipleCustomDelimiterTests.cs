using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.UnitTest.CustomDelimiterExtractorTests
{
    [TestClass]
    public class Part8_MultipleCustomDelimiterTests : CustomDelimiterExtractorTestBase
    {
        [TestMethod]
        public void AllowMultipleCustomDelimiters()
        {
            const string testInput = "//[abc][fe][53]";
            var expectedResult = new List<string> { "abc", "fe", "53" };
            expectedResult.AddRange(_defaultDelimiters);
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void OnlyDelimitersInBracketsAreUsed()
        {
            var testInput = "//;[abc],[gdf]";
            var expectedResult = new List<string> { "abc", "gdf" };
            expectedResult.AddRange(_defaultDelimiters);
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void NewLineIsNotASupportedCustomDelimiter()
        {
            var testInput = "//;[abc],[g\ndf]";
            var expectedResult = new List<string> { "abc" };
            expectedResult.AddRange(_defaultDelimiters);
            RunTest(testInput, expectedResult);
        }
    }
}
