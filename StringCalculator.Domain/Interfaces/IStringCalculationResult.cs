﻿using StringCalculator.Domain.Classes;

namespace StringCalculator.Domain.Interfaces
{
    public interface IStringCalculationResult
    {
        int CalculationResult { get; }
        string Formula { get; }
        void ProcessTerm(Term term);
    }
}
