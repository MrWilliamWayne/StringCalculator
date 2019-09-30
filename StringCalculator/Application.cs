using System;
using System.Threading;
using StringCalculator.Domain.Interfaces;

namespace StringCalculator
{
    class Application
    {
        private bool exitApplication = false;
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
                exitApplication = true;
            };

            while (!exitApplication)
            {
                var userInput = PromptUserForInput();

                Thread.Sleep(100); // Yuck
                if (exitApplication) // potential race condition?
                    break;
                
                Console.WriteLine();

                try
                {
                    var calcResult = _stringCalculator.Calculate(userInput);

                    if (null != calcResult)
                    {
                        Console.WriteLine(calcResult.Formula);
                    }
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
