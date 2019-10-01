using System.Collections.Generic;

namespace StringCalculator.Domain.Interfaces
{
    public interface ICustomDelimiterExtractor
    {
        IEnumerable<string> GetDelimiters(string userInput);
    }
}
