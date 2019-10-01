using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Domain.Classes;
using StringCalculator.Domain.Interfaces;

namespace StringCalculator.UnitTest.TermExtractorTests
{
    public abstract class TermExtractorTestBase
    {
        protected readonly ITermExtractor _termExtractor;

        protected TermExtractorTestBase()
        {
            _termExtractor = new TermExtractor();
        }

        protected void RunTest(string testInput, IReadOnlyList<Term> expectedResults)
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
