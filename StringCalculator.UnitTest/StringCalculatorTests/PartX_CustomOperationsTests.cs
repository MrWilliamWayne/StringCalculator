using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Domain.Classes;

namespace StringCalculator.UnitTest.StringCalculatorTests
{
    [TestClass]
    public class PartX_CustomOperationsTests : StringCalculatorUnitTestBase
    {
        [TestMethod]
        public void CalculatorSupportsImplicitAddition()
        {
            const string testInput = "5,5";
            var expectedResults = new StringCalculationResult(5 + 5, "5+5");
            RunTest(testInput, expectedResults);
        }

        [TestMethod]
        public void CalculatorSupportsExplicitAddition()
        {
            const string testInput = "5,(+)5";
            var expectedResults = new StringCalculationResult(5 + 5, "5+5");
            RunTest(testInput, expectedResults);
        }

        [TestMethod]
        public void CalculatorSupportsSubtraction()
        {
            const string testInput = "5,(-)5";
            var expectedResults = new StringCalculationResult(5 - 5, "5-5");
            RunTest(testInput, expectedResults);
        }

        [TestMethod]
        public void CalculatorSupportsMultiplication()
        {
            const string testInput = "5,(*)5";
            var expectedResults = new StringCalculationResult(5 * 5, "5*5");
            RunTest(testInput, expectedResults);
        }

        [TestMethod]
        public void CalculatorSupportsDivision()
        {
            const string testInput = "5,(/)5";
            var expectedResults = new StringCalculationResult(5 / 5, "5/5");
            RunTest(testInput, expectedResults);
        }

        [TestMethod]
        public void DivideByZeroThrowsException()
        {
            const string testInput = "//;\n10;(/)sf";
            Assert.ThrowsException<DivideByZeroException>(() => { _calculator.Calculate(testInput, CancellationToken.None); });
        }



        [TestMethod]
        public void LeadingAdditionIgnoresImplicitZeroToBeginningOfFormula()
        {
            const string testInput = "(+)5,(/)5";
            var expectedResults = new StringCalculationResult(5 / 5, "5/5");
            RunTest(testInput, expectedResults);
        }

        [TestMethod]
        public void LeadingSubtractionAddsImplicitZeroToBeginningOfFormula()
        {
            const string testInput = "(-)5,(/)5";
            var expectedResults = new StringCalculationResult(-5 / 5, "0-5/5");
            RunTest(testInput, expectedResults);
        }

        [TestMethod]
        public void LeadingMultiplicationAddsImplicitZeroToBeginningOfFormula()
        {
            const string testInput = "(*)5,(/)5";
            var expectedResults = new StringCalculationResult((0 * 5) / 5, "0*5/5");
            RunTest(testInput, expectedResults);
        }

        [TestMethod]
        public void LeadingDivisionAddsImplicitZeroToBeginningOfFormula()
        {
            const string testInput = "(/)5,(/)5";
            var expectedResults = new StringCalculationResult((0 / 5) / 5, "0/5/5");
            RunTest(testInput, expectedResults);
        }
    }
}
