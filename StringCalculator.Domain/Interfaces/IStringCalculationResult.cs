namespace StringCalculator.Domain.Interfaces
{
    public interface IStringCalculationResult
    {
        int CalculationResult { get; }
        string Formula { get; }
    }
}
