using System.Collections.Generic;
using StringCalculator.Domain.Classes;

namespace StringCalculator.Domain.Interfaces
{
    public interface ITermExtractor
    {
        IEnumerable<Term> GetTerms(string userInput);
    }
}