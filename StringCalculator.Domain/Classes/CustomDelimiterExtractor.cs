using System;
using System.Collections.Generic;
using StringCalculator.Domain.Interfaces;

namespace StringCalculator.Domain.Classes
{
    public class CustomDelimiterExtractor : ICustomDelimiterExtractor
    {
        // "\\n" is support for input of "\n" test from the prompt
        private static readonly string[] _defaultDelimiters = { ",", Environment.NewLine, "\n", "\\n" };
        
        public IEnumerable<string> GetDelimiters(string userInput)
        {
            var delimiters = new List<string>();

            // If the user elected to provide a custom delimiter, it must be preceded by two forward slashes ...
            if (userInput.StartsWith("//"))
            {
                // ... and followed by a newline character or character representation
                // We just want to split once - the first string will contain the delimiter(s)
                var customDelimiter = userInput.Split(new[] { "\n", "\\n" }, 2, StringSplitOptions.None)[0].Substring(2);

                // We don't want or need to split on an empty string - I'm not sure if this would be handled gracefully by string.Split
                if (!string.IsNullOrEmpty(customDelimiter))
                {
                    // Support a single custom delimiter
                    if (customDelimiter.Length == 1)
                        delimiters.Add(customDelimiter);
                    // Otherwise, require delimiters to be defined in brackets
                    else
                    {
                        var openBracketIndex = 0;
                        while (true)
                        {
                            // Get the next opening bracket
                            openBracketIndex = customDelimiter.IndexOf('[', openBracketIndex);
                            if (openBracketIndex == -1)
                                break;

                            var closeBracketIndex = customDelimiter.IndexOf(']', openBracketIndex + 1);
                            if (closeBracketIndex == -1)
                                break;

                            // Get the substring from inside the brackets
                            var length = closeBracketIndex - openBracketIndex - 1;
                            var delimiter = customDelimiter.Substring(openBracketIndex + 1, length);
                            delimiters.Add(delimiter);

                            openBracketIndex = closeBracketIndex + 1;
                        }
                    }
                }
            }

            // Add the default delimiters to the end to process custom delimiters first
            delimiters.AddRange(_defaultDelimiters);
            return delimiters;
        }
    }
}
