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
            
            var result = new StringCalculationResult();
            terms.ForEach(t =>
            {
                result.AddTerm(t);

            });

            if (!_allowNegativeNumbers && result.NegativeNumbers.Any())
                throw new NegativeNumbersException("Negative numbers are not supported", result.NegativeNumbers.ToArray());

            return result;
        }
    }
}
