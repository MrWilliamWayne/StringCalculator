using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Domain.Classes;

namespace StringCalculator.UnitTest.TermExtractorTests
{
    [TestClass]
    public class Part3_NewLineDelimiterSupportTests : TermExtractorTestBase
    {
        [TestMethod]
        public void EnvironmentNewLineCharacterSupported()
        {
            var testInput = $"1{Environment.NewLine}5";
            var expectedResult = new List<Term> { new Term("1"), new Term("5") };
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void NewLineCharacterSupported()
        {
            const string testInput = "4\n9";
            var expectedResult = new List<Term> { new Term("4"), new Term("9") };
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void TextNewLineCharacterSupported()
        {
            const string testInput = "2\\n8";
            var expectedResult = new List<Term> { new Term("2"), new Term("8") };
            RunTest(testInput, expectedResult);
        }
    }
}
