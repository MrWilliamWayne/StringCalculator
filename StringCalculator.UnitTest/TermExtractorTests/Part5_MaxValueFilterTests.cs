using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Domain.Classes;

namespace StringCalculator.UnitTest.TermExtractorTests
{
    [TestClass]
    public class Part5_MaxValueFilterTests : TermExtractorTestBase
    {
        [TestMethod]
        public void TermExtractorDoesNotFilterNumbersByValue()
        {
            const string testInput = "1,5,1000,1001,5000,10";
            var expectedResult = new List<Term> { new Term("1"), new Term("5"), new Term("1000"), new Term("1001"), new Term("5000"), new Term("10") };
            RunTest(testInput, expectedResult);
        }
    }
}
