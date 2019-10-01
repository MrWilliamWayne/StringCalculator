using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Domain.Classes;

namespace StringCalculator.UnitTest.TermExtractorTests
{
    [TestClass]
    public class Part1_BasicRequirementsTests : TermExtractorTestBase
    {
        [TestMethod]
        public void EmptyString()
        {
            var testInput = string.Empty;
            var expectedResults = new List<Term> { Term.Empty, Term.Empty };
            RunTest(testInput, expectedResults);
        }

        [TestMethod]
        public void DelimiterOnly()
        {
            const string testInput = ",";
            var expectedResults = new List<Term> { Term.Empty, Term.Empty };
            RunTest(testInput, expectedResults);
        }

        [TestMethod]
        public void NumberOnly()
        {
            const string testInput = "5";
            var expectedResult = new List<Term> { new Term("5"), Term.Empty };
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void NumberAndDelimiter()
        {
            const string testInput = "5,";
            var expectedResult = new List<Term> { new Term("5"), Term.Empty };
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void DelimiterAndNumber()
        {
            const string testInput = ",5";
            var expectedResult = new List<Term> { Term.Empty, new Term("5") };
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void StringOperand()
        {
            const string testInput = "fdhreg";
            var expectedResult = new List<Term> { Term.Empty, Term.Empty };
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void TwoStringOperands()
        {
            const string testInput = "fdhreg,dfslj";
            var expectedResult = new List<Term> { Term.Empty, Term.Empty };
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void NumberAndStringOperands()
        {
            const string testInput = "22,fdhreg";
            var expectedResult = new List<Term> { new Term("22"), Term.Empty };
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void StringAndNumberOperands()
        {
            const string testInput = "hrtr,21";
            var expectedResult = new List<Term> { Term.Empty, new Term("21") };
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void TwoNumericOperands()
        {
            const string testInput = "3,21";
            var expectedResult = new List<Term> { new Term("3"), new Term("21") };
            RunTest(testInput, expectedResult);
        }

        // Part 2

        [TestMethod]
        public void UnlimitedTermsSupported()
        {
            const string testInput = "3,21,gfd,65,845,,0";
            var expectedResult = new List<Term> { new Term("3"), new Term("21"), Term.Empty, new Term("65"), new Term("845"), Term.Empty, new Term("0") };
            RunTest(testInput, expectedResult);
        }
    }
}
