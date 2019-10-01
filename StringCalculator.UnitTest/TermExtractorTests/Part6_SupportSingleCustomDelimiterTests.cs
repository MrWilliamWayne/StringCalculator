using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Domain.Classes;

namespace StringCalculator.UnitTest.TermExtractorTests
{
    [TestClass]
    public class Part6_SupportSingleCustomDelimiterTests : TermExtractorTestBase
    {
        [TestMethod]
        public void AllowASingleCustomDelimiter()
        {
            var testInput = $"//;\n1;5,1000{Environment.NewLine}1001,5000";
            var expectedResult = new List<Term> { new Term("1"), new Term("5"), new Term("1000"), new Term("1001"), new Term("5000"), };
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void AllowNumericCustomDelimiter()
        {
            var testInput = $"//5\n1,5,1000{Environment.NewLine}1001,60510";
            var expectedResult = new List<Term> { new Term("1"), new Term("0"), new Term("0"), new Term("1000"), new Term("1001"), new Term("60"), new Term("10"), };
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void MultiCharacterDelimitersAreNotSupportedWithoutBrackets()
        {
            var testInput = $"//abc\n1,abc,1000{Environment.NewLine}1001,60abc10";
            var expectedResult = new List<Term> { new Term("1"), new Term("0"), new Term("1000"), new Term("1001"), new Term("0"), };
            RunTest(testInput, expectedResult);
        }
    }
}
