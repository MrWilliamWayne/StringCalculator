using System;

namespace StringCalculator.Domain.Exceptions
{
    public class NegativeNumbersException : Exception
    {
        public NegativeNumbersException(string message, int[] negativeNumbers, Exception innerException = null) : base(message, innerException)
        {
            NegativeNumbers = negativeNumbers;
        }

        public int[] NegativeNumbers { get; }

        public override string ToString()
        {
            return Message + Environment.NewLine + NegativeNumbers;
        }
    }
}
