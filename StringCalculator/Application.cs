using System;
using System.Threading;
using StringCalculator.Domain.Exceptions;
using StringCalculator.Domain.Interfaces;

namespace StringCalculator
{
    class Application
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly IStringCalculator _stringCalculator;

        public Application(IStringCalculator stringCalculator)
        {
            _stringCalculator = stringCalculator;
        }

        public void Run()
        {
            Console.CancelKeyPress += (sender, args) =>
            {
                args.Cancel = true;
                _cancellationTokenSource.Cancel();
            };

            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                var userInput = PromptUserForInput();
                Console.WriteLine();

                if (_cancellationTokenSource.IsCancellationRequested)
                    return;

                try
                {
                    var calcResult = _stringCalculator.Calculate(userInput, _cancellationTokenSource.Token);

                    Console.WriteLine(calcResult);
                }
                catch (NegativeNumbersException nne)
                {
                    Console.WriteLine($"Negative numbers are disallowed. The following negative numbers were input:{Environment.NewLine}{string.Join(", ", nne.NegativeNumbers)}{Environment.NewLine}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e + Environment.NewLine);
                }
            }
        }

        private string PromptUserForInput()
        {
            Console.WriteLine("Enter the terms to calculate. Press Ctrl+C to quit.");
            return Console.ReadLine();
        }
    }
}
