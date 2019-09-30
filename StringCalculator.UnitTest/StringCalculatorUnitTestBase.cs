using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Domain.Classes;
using StringCalculator.Domain.Interfaces;

namespace StringCalculator.UnitTest
{
    public class StringCalculatorUnitTestBase
    {
        private readonly IStringCalculator _calculator;

        public StringCalculatorUnitTestBase()
        {
            _calculator = new StrCalculator(new TermExtractor());
        }

        protected void RunTest(string testInput, IStringCalculationResult expectedResult)
        {
            var actualResult = _calculator.Calculate(testInput);

            Assert.AreEqual(expectedResult, actualResult, $"Test Failed for user input '{testInput}'");
        }
    }
}
