using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Domain.Classes;

namespace StringCalculator.UnitTest.TermExtractorTests
{
    [TestClass]
    public class Part2_UnlimitedTermsTests : TermExtractorTestBase
    {
        [TestMethod]
        public void CalculatorSupportsManyValues()
        {
            var testInput = "1,2,3,4,5,6,7,8,9,10,11,12";
            var expectedResult = new List<Term> { new Term("1"), new Term("2"), new Term("3"), new Term("4"), new Term("5"), new Term("6"), new Term("7"), new Term("8"), new Term("9"), new Term("10"), new Term("11"), new Term("12") };
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void UnlimitedTermsSupported()
        {
            const string testInput = "3,21,gfd,65,845,,0";
            var expectedResult = new List<Term> { new Term("3"), new Term("21"), Term.Empty, new Term("65"), new Term("845"), Term.Empty, new Term("0") };
            RunTest(testInput, expectedResult);
        }
    }
}
