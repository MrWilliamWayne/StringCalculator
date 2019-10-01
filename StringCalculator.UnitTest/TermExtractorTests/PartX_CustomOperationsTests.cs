using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Domain.Enumerations;

namespace StringCalculator.UnitTest.TermExtractorTests
{
    [TestClass]
    public class PartX_CustomOperationsTests : TermExtractorTestBase
    {
        [TestMethod]
        public void TermExtractorSupportsImplicitAddition()
        {
            var testInput = "5,5";
            var actualResults = _termExtractor.GetTerms(testInput).ToList();

            Assert.AreEqual(Operations.Addition, actualResults[0].Operation);
            Assert.AreEqual(Operations.Addition, actualResults[1].Operation);
        }

        [TestMethod]
        public void TermExtractorSupportsExplicitAddition()
        {
            var testInput = "(+)5,(+)5";
            var actualResults = _termExtractor.GetTerms(testInput).ToList();

            Assert.AreEqual(Operations.Addition, actualResults[0].Operation);
            Assert.AreEqual(Operations.Addition, actualResults[1].Operation);
        }

        [TestMethod]
        public void TermExtractorSupportsSubtraction()
        {
            var testInput = "5,(-)5";
            var actualResults = _termExtractor.GetTerms(testInput).ToList();

            Assert.AreEqual(Operations.Addition, actualResults[0].Operation);
            Assert.AreEqual(Operations.Subtraction, actualResults[1].Operation);
        }

        [TestMethod]
        public void TermExtractorSupportsMultiplication()
        {
            var testInput = "5,(*)5";
            var actualResults = _termExtractor.GetTerms(testInput).ToList();

            Assert.AreEqual(Operations.Addition, actualResults[0].Operation);
            Assert.AreEqual(Operations.Multiplication, actualResults[1].Operation);
        }

        [TestMethod]
        public void TermExtractorSupportsDivision()
        {
            var testInput = "5,(/)5";
            var actualResults = _termExtractor.GetTerms(testInput).ToList();

            Assert.AreEqual(Operations.Addition, actualResults[0].Operation);
            Assert.AreEqual(Operations.Division, actualResults[1].Operation);
        }
    }
}
