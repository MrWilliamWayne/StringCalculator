using System.Text;
using StringCalculator.Domain.Interfaces;

namespace StringCalculator.Domain.Classes
{
    public class StringCalculationResult : IStringCalculationResult
    {
        private int _calculationResult;
        private readonly StringBuilder _formula = new StringBuilder();

        public StringCalculationResult() { }

        public StringCalculationResult(int calculationResult, string formula)
        {
            _calculationResult = calculationResult;
            _formula.Append(formula);
        }

        #region Properties

        /// <summary>
        /// The total Calculation Result
        /// </summary>
        public int CalculationResult => _calculationResult;

        /// <summary>
        /// The string representation of the calculation of all processed terms with the calculated result
        /// </summary>
        public string Formula => _formula.ToString();
        #endregion

        /// <summary>
        /// Adds a term to the StringCalculationResult
        /// </summary>
        /// <param name="term"></param>
        public void AddTerm(Term term)
        {
            AddTermToResult(term);
            AppendTermToFormula(term);
        }

        #region Private Methods
        private void AddTermToResult(Term term)
        {
            _calculationResult += term.Value;
        }

        private void AppendTermToFormula(Term term)
        {
            if (_formula.Length > 0)
                _formula.Append("+");

            _formula.Append(term.Value.ToString());
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            var other = obj as IStringCalculationResult;

            if (null == other)
                return false;

            return CalculationResult == other.CalculationResult && Formula.Equals(other.Formula);
        }

        public override string ToString()
        {
            return Formula + $" = {_calculationResult}";
        }

        #endregion
    }
}
