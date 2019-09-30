using System.Collections.Generic;
using System.Linq;
using StringCalculator.Domain.Exceptions;
using StringCalculator.Domain.Interfaces;

namespace StringCalculator.Domain.Classes
{
    public class StrCalculator : IStringCalculator
    {
        private readonly ITermExtractor _termExtractor;

        // TODO: Relocate to a settings class, which gets populated locally in Calculate
        private bool _allowNegativeNumbers = false;
        private int _maxValue = 1000;

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
                // Enforce the max value, substituting an Emtpy Term in its place if it's too large.
                result.AddTerm(t.Value <= _maxValue ? t : Term.Empty);
            });

            if (!_allowNegativeNumbers && result.NegativeNumbers.Any())
                throw new NegativeNumbersException("Negative numbers are not supported", result.NegativeNumbers.ToArray());

            return result;
        }
    }
}
