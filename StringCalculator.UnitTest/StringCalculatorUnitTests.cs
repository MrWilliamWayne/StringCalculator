using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Domain.Classes;
using StringCalculator.Domain.Interfaces;

namespace StringCalculator.UnitTest
{
    [TestClass]
    public class StringCalculatorUnitTests
    {
        private readonly IStringCalculator _calculator;

        public StringCalculatorUnitTests()
        {
            _calculator = new StrCalculator(new TermExtractor());
        }

        [TestMethod]
        public void EmptyStringShouldResultInZero()
        {
            var testInput = string.Empty;
            var expectedResult = new StringCalculationResult(0, "0+0");
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void DelimiterOnlyShouldResultInZero()
        {
            const string testInput = ",";
            var expectedResult = new StringCalculationResult(0, "0+0");
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void NumberOnlyShouldReturnTheNumber()
        {
            // It's tempting to select a random value, but you lose control over what is being tested - and if you fail for specific values, your test may pass or fail randomly.
            // Better to implement regression tests for known bad states when identified.
            const string testInput = "5";
            var expectedResult = new StringCalculationResult(5, "5+0");
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void NumberAndDelimiterShouldReturnTheNumber()
        {
            const string testInput = "5,";
            var expectedResult = new StringCalculationResult(5, "5+0");
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void DelimiterAndNumberShouldReturnTheNumber()
        {
            const string testInput = ",5";
            var expectedResult = new StringCalculationResult(5, "0+5");
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void StringOperandsShouldBeIgnoredAsZero()
        {
            const string testInput = "fdhreg";
            var expectedResult = new StringCalculationResult(0, "0+0");
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void NumberAndStringOperandsShouldReturnNumber()
        {
            const string testInput = "22,fdhreg";
            var expectedResult = new StringCalculationResult(22, "22+0");
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void StringAndNumberOperandsShouldReturnNumber()
        {
            const string testInput = "hrtr,21";
            var expectedResult = new StringCalculationResult(21, "0+21");
            RunTest(testInput, expectedResult);
        }

        [TestMethod]
        public void TwoNumericOperandsShouldBeAddedTogether()
        {
            const string testInput = "3,21";
            var expectedResult = new StringCalculationResult(24, "3+21");
            RunTest(testInput, expectedResult);
        }



        private void RunTest(string testInput, IStringCalculationResult expectedResult)
        {
            var actualResult = _calculator.Calculate(testInput);

            Assert.AreEqual(expectedResult, actualResult, $"Test Failed for user input '{testInput}'");
        }
    }
}
