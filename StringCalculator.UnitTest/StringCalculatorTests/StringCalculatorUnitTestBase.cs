using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Domain.Classes;
using StringCalculator.Domain.Interfaces;

namespace StringCalculator.UnitTest.StringCalculatorTests
{
    public abstract class StringCalculatorUnitTestBase
    {
        protected readonly IStringCalculator _calculator;

        protected StringCalculatorUnitTestBase()
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
