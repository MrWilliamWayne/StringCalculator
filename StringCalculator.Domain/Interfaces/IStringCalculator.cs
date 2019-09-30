namespace StringCalculator.Domain.Interfaces
{
    public interface IStringCalculator
    {
        IStringCalculationResult Calculate(string userInput);
    }
}
