using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringCalculator.Domain.Interfaces;

namespace StringCalculator.Domain.Classes
{
    public class StrCalculator : IStringCalculator
    {
        private readonly ITermExtractor _termExtractor;

        public StrCalculator(ITermExtractor termExtractor)
        {
            _termExtractor = termExtractor;
        }

        public IStringCalculationResult Calculate(string userInput)
        {
            var terms = _termExtractor.GetTerms(userInput)?.ToList() ?? new List<Term>();
            
            var result = new StringCalculationResult();
            terms.ForEach(t => result.AddTerm(t));

            return result;
        }
    }
}
