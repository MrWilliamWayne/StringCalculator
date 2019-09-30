using System.Collections.Generic;
using System.Linq;
using StringCalculator.Domain.Exceptions;
using StringCalculator.Domain.Interfaces;

namespace StringCalculator.Domain.Classes
{
    public class StrCalculator : IStringCalculator
    {
        private readonly ITermExtractor _termExtractor;
        private bool _allowNegativeNumbers = false;

        public StrCalculator(ITermExtractor termExtractor)
        {
            _termExtractor = termExtractor;
        }

        public IStringCalculationResult Calculate(string userInput)
        {
            var terms = _termExtractor.GetTerms(userInput)?.ToList() ?? new List<Term>();
            var negativeNumbers = new List<int>();
            
            var result = new StringCalculationResult();
            terms.ForEach(t =>
            {
                result.AddTerm(t);

                // If we are not allowing negative numbers, record when we have one (or more)
                if (!_allowNegativeNumbers && t.Value < 0)
                    negativeNumbers.Add(t.Value);
            });

            if (!_allowNegativeNumbers && negativeNumbers.Any()) // Technically we don't have to check the flag, but it's a good safety catch.
                throw new NegativeNumbersException("Negative numbers are not supported", negativeNumbers.ToArray());

            return result;
        }
    }
}
