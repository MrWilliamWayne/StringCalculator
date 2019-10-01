using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Domain.Classes;
using StringCalculator.Domain.Interfaces;

namespace StringCalculator.UnitTest.CustomDelimiterExtractorTests
{
    public abstract class CustomDelimiterExtractorTestBase
    {
        protected readonly ICustomDelimiterExtractor _delimiterExtractor;
        protected static readonly string[] _defaultDelimiters = { ",", Environment.NewLine, "\n", "\\n" };

        protected CustomDelimiterExtractorTestBase()
        {
            _delimiterExtractor = new CustomDelimiterExtractor();
        }

        protected void RunTest(string testInput, IReadOnlyList<string> expectedResults)
        {
            var actualResults = _delimiterExtractor.GetDelimiters(testInput).ToList();

            Assert.AreEqual(expectedResults.Count, actualResults.Count, "Delimiter count mismatch");
            Assert.IsTrue(expectedResults.SequenceEqual(actualResults));
        }
    }
}
