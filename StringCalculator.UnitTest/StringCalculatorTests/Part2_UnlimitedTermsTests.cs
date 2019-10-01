using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Domain.Classes;

namespace StringCalculator.UnitTest.StringCalculatorTests
{
    [TestClass]
    public class Part2_UnlimitedTermsTests : StringCalculatorUnitTestBase
    {
        [TestMethod]
        public void CalculatorSupportsManyValues()
        {
            var testInput = "1,2,3,4,5,6,7,8,9,10,11,12";
            var expectedResult = new StringCalculationResult(78, "1+2+3+4+5+6+7+8+9+10+11+12");
            RunTest(testInput, expectedResult);
        }
    }
}
