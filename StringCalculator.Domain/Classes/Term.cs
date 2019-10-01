using StringCalculator.Domain.Enumerations;
using StringCalculator.Domain.Helpers;

namespace StringCalculator.Domain.Classes
{
    public class Term
    {
        public static readonly Term Empty = new Term();

        public int Value { get; }
        public Operations Operation { get; }

        private Term()
        {
            Value = 0;
            Operation = Operations.Addition;
        }

        public Term(string termInput)
        {
            var val = termInput;
            Operation = Operations.Addition;

            // To have an operation specified for this Term, there must be a single symbol provided inside parenthesis.
            // This allows subtraction without confusing it for a negative number and gives us more control over this.
            if (termInput.Length > 3 && termInput[0] == '(' && termInput[2] == ')')
            {
                Operation = OperationsHelper.GetOperationFromSymbol(termInput[1]);

                // correct the input for the remaining characters
                val = val.Substring(3);
            }

            // If the input can be parsed, use the out result - otherwise, substitute a 0
            Value = int.TryParse(val, out var termVal) ? termVal : 0;
        }

        #region Overrides

        public override bool Equals(object obj)
        {
            var other = obj as Term;

            if (null == other)
                return false;

            return Value == other.Value && Operation == other.Operation;
        }

        #endregion
    }
}