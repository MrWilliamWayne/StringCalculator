using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Domain.Classes;

namespace StringCalculator.UnitTest.TermExtractorTests
{
    [TestClass]
    public class Part7_MultiCharCustomDelimiterTests : TermExtractorTestBase
    {
        [TestMethod]
        public void AllowMultiCharCustomDelimiter()
        {
            var testInput = $"//[abc]\n1abc5,1000{Environment.NewLine}1001abc5000";
            var expectedResult = new List<Term> { new Term("1"), new Term("5"), new Term("1000"), new Term("1001"), new Term("5000"), };
            RunTest(testInput, expectedResult);
        }
    }
}
