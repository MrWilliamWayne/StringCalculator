using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Domain.Classes;

namespace StringCalculator.UnitTest.TermExtractorTests
{
    [TestClass]
    public class Part4_RejectFormulasWithNegativeNumbersTests : TermExtractorTestBase
    {
        [TestMethod]
        public void NegativeNumbersAreReturnedAsTermsFromTheTermExtractor()
        {
            const string testInput = "0,-5,65,48,-105";
            var expectedResult = new List<Term> { new Term("0"), new Term("-5"), new Term("65"), new Term("48"), new Term("-105") };
            RunTest(testInput, expectedResult);
        }
    }
}
