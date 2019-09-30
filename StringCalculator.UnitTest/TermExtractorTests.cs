using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Domain.Classes;
using StringCalculator.Domain.Interfaces;

namespace StringCalculator.UnitTest
{
    [TestClass]
    public class TermExtractorTests
    {
        private readonly ITermExtractor _termExtractor;

        public TermExtractorTests()
        {
            _termExtractor = new TermExtractor();
        }

        [TestMethod]
        public void EmptyString()
        {
            var testInput = string.Empty;
            var expectedResults = new List<Term> { new Term("0"), new Term("0") };
            RunTest(testInput, expectedResults);
        }

        [TestMethod]
        public void DelimiterOnly()
        {
            const string testInput = ",";
            var expectedResults = new List<Term> { new Term("0"), new Term("0") };
            RunTest(testInput, expectedResults);
        }

        [TestMethod]
        public void NumberOnly()
        {
            const string testInput = "5";
            var expectedResult = new List<Term> { new Term("5"), new Term("0") };
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void NumberAndDelimiter()
        {
            const string testInput = "5,";
            var expectedResult = new List<Term> { new Term("5"), new Term("0") };
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void DelimiterAndNumber()
        {
            const string testInput = ",5";
            var expectedResult = new List<Term> { new Term("0"), new Term("5") };
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void StringOperand()
        {
            const string testInput = "fdhreg";
            var expectedResult = new List<Term> { new Term("0"), new Term("0") };
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void TwoStringOperands()
        {
            const string testInput = "fdhreg,dfslj";
            var expectedResult = new List<Term> { new Term("0"), new Term("0") };
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void NumberAndStringOperands()
        {
            const string testInput = "22,fdhreg";
            var expectedResult = new List<Term> { new Term("22"), new Term("0") };
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void StringAndNumberOperands()
        {
            const string testInput = "hrtr,21";
            var expectedResult = new List<Term> { new Term("0"), new Term("21") };
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void TwoNumericOperands()
        {
            const string testInput = "3,21";
            var expectedResult = new List<Term> { new Term("3"), new Term("21") };
            RunTest(testInput, expectedResult);
        }


        private void RunTest(string testInput, IReadOnlyList<Term> expectedResults)
        {
            var actualResults = _termExtractor.GetTerms(testInput).ToList();

            Assert.AreEqual(expectedResults.Count, actualResults.Count, "Term count mismatch");

            for (var i = 0; i < expectedResults.Count; i++)
            {
                Assert.AreEqual(expectedResults[i], actualResults[i]);
            }
        }
    }
}
