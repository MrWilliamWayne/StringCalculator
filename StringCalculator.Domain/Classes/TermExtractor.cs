using System;
using System.Collections.Generic;
using System.Linq;
using StringCalculator.Domain.Interfaces;

namespace StringCalculator.Domain.Classes
{
    public class TermExtractor : ITermExtractor
    {
        private static readonly string[] _defaultDelimiters = {",", Environment.NewLine, "\\n"};

        public IEnumerable<Term> GetTerms(string userInput)
        {
            var termStrings = userInput?.Split(_defaultDelimiters, StringSplitOptions.None) ?? new string[] { };
            var results = termStrings.Select(termString => new Term(termString)).ToList();

            // Minimum of 2 terms?
            while (results.Count < 2)
            {
                results.Add(new Term(string.Empty));
            }

            return results;
        }
    }
}
