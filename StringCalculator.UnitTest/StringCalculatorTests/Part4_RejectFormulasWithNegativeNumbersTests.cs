using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Domain.Exceptions;

namespace StringCalculator.UnitTest.StringCalculatorTests
{
    [TestClass]
    public class Part4_RejectFormulasWithNegativeNumbersTests : StringCalculatorUnitTestBase
    {
        [TestMethod]
        public void NegativeNumbersAreNotSupported()
        {
            var testInput = "-1";
            var expectedNegativeNumbers = new[] {-1};

            try
            {
                _calculator.Calculate(testInput);
                Assert.Fail("Expected a NegativeNumbersException");
            }
            catch (NegativeNumbersException e)
            {
                Assert.AreEqual(expectedNegativeNumbers.Length, e.NegativeNumbers.Length);
                Assert.IsTrue(expectedNegativeNumbers.SequenceEqual(e.NegativeNumbers));
            }
        }

        [TestMethod]
        public void AllNegativeNumbersShouldBeReported()
        {
            var testInput = "0,-5,65,48,-105";
            var expectedNegativeNumbers = new[] { -5, -105 };

            try
            {
                _calculator.Calculate(testInput);
                Assert.Fail("Expected a NegativeNumbersException");
            }
            catch (NegativeNumbersException e)
            {
                Assert.AreEqual(expectedNegativeNumbers.Length, e.NegativeNumbers.Length);
                Assert.IsTrue(expectedNegativeNumbers.SequenceEqual(e.NegativeNumbers));
            }
        }
    }
}
