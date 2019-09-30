namespace StringCalculator.Domain.Classes
{
    public class Term
    {
        public static readonly Term Empty = new Term();

        public int Value { get; }

        private Term()
        {
            Value = 0;
        }

        public Term(string termInput)
        {
            // If the input can be parsed, use the out result - otherwise, substitute a 0
            Value = int.TryParse(termInput, out var termVal) ? termVal : 0;
        }

        #region Overrides

        public override bool Equals(object obj)
        {
            var other = obj as Term;

            if (null == other)
                return false;

            return Value == other.Value;
        }

        #endregion
    }
}