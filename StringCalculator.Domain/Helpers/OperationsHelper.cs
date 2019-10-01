using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringCalculator.Domain.Enumerations;

namespace StringCalculator.Domain.Helpers
{
    public static class OperationsHelper
    {
        public static string GetOperationSymbol(Operations operation)
        {
            switch (operation)
            {
                case Operations.Addition:
                    return "+";
                case Operations.Subtraction:
                    return "-";
                case Operations.Multiplication:
                    return "*";
                case Operations.Division:
                    return "/";
                default:
                    throw new NotSupportedException($"Unsupported Operation: {operation.ToString()}");
            }
        }

        public static Operations GetOperationFromSymbol(char symbol)
        {
            switch (symbol)
            {
                case '-':
                    return Operations.Subtraction;
                case '*':
                    return Operations.Multiplication;
                case '/':
                    return Operations.Division;
                default:
                    return Operations.Addition;
            }
        }
    }
}
