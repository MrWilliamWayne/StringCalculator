using System;
using System.Collections.Generic;
using System.Text;
using StringCalculator.Domain.Enumerations;
using StringCalculator.Domain.Helpers;
using StringCalculator.Domain.Interfaces;

namespace StringCalculator.Domain.Classes
{
    public class StringCalculationResult : IStringCalculationResult
    {
        private readonly StringBuilder _formula = new StringBuilder();
        private readonly List<int> _negativeNumbers = new List<int>();

        public StringCalculationResult() { }

        public StringCalculationResult(int calculationResult, string formula)
        {
            CalculationResult = calculationResult;
            _formula.Append(formula);
        }

        #region Properties

        /// <summary>
        /// The total Calculation Result
        /// </summary>
        public int CalculationResult { get; private set; }

        /// <summary>
        /// The string representation of the calculation of all processed terms with the calculated result
        /// </summary>
        public string Formula => _formula.ToString();

        /// <summary>
        /// Returns the list of negative numbers in the formula
        /// </summary>
        public IEnumerable<int> NegativeNumbers => _negativeNumbers;
        #endregion

        /// <summary>
        /// Processes a new term, which updates the cumulative result and formula.
        /// Note that all calculations are made in-order and do not respect PEMDAS.
        /// </summary>
        /// <param name="term"></param>
        public void ProcessTerm(Term term)
        {
            UpdateResultWithTermValue(term);
            AppendTermToFormula(term);
            if (term.Value < 0)
                _negativeNumbers.Add(term.Value);
        }

        #region Private Methods
        private void UpdateResultWithTermValue(Term term)
        {
            switch (term.Operation)
            {
                case Operations.Addition:
                    CalculationResult += term.Value;
                    return;

                case Operations.Subtraction:
                    CalculationResult -= term.Value;
                    return;

                case Operations.Multiplication:
                    CalculationResult *= term.Value;
                    return;

                case Operations.Division:
                    if (term.Value == 0)
                        throw new DivideByZeroException("Illegal operation - divide by zero");

                    CalculationResult /= term.Value;
                    return;

                default:
                    throw new NotSupportedException($"The specified Operation ({term.Operation.ToString()}) is not supported.");
            }
        }

        private void AppendTermToFormula(Term term)
        {
            // If we are processing the first term, and the operation is not Addition, display the implicit first 0 in the results
            if (_formula.Length == 0 && term.Operation != Operations.Addition)
                _formula.Append("0");

            // Append the operation symbol if the current formula has any previous value
            if (_formula.Length > 0)
                _formula.Append(OperationsHelper.GetOperationSymbol(term.Operation));

            // Append the actual value to the formula
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
            return Formula + $" = {CalculationResult}";
        }

        #endregion
    }
}
