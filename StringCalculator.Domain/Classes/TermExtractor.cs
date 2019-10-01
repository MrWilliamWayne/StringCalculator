using System;
using System.Collections.Generic;
using System.Linq;
using StringCalculator.Domain.Interfaces;

namespace StringCalculator.Domain.Classes
{
    public class TermExtractor : ITermExtractor
    {
        private readonly ICustomDelimiterExtractor _delimiterExtractor;

        public TermExtractor(ICustomDelimiterExtractor delimiterExtractor)
        {
            _delimiterExtractor = delimiterExtractor;
        }

        public IEnumerable<Term> GetTerms(string userInput)
        {
            // Get the list of delimiters to use
            var delimiters = _delimiterExtractor.GetDelimiters(userInput);

            var termString = userInput;

            if (userInput.StartsWith("//"))
            {
                // If the user elected to provide custom delimiters, grab the second half of the input for the term string
                termString = userInput.Split(new[] {"\n", "\\n"}, 2, StringSplitOptions.None)[1];
            }

            var termStrings = termString.Split(delimiters.ToArray(), StringSplitOptions.None);
            var results = termStrings.Select(t => new Term(t)).ToList();

            // Minimum of 2 terms?
            while (results.Count < 2)
            {
                results.Add(Term.Empty);
            }

            return results;
        }
    }
}
