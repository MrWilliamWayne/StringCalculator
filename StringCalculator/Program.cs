using Autofac;
using StringCalculator.Domain.Classes;
using StringCalculator.Domain.Interfaces;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            CompositionRoot().Resolve<Application>().Run();
        }

        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>();
            builder.RegisterType<TermExtractor>().As<ITermExtractor>();
            builder.RegisterType<StrCalculator>().As<IStringCalculator>();
            return builder.Build();
        }
    }
}