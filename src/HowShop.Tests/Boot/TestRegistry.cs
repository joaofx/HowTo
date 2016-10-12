using HowShop.Core.Infra;
using MediatR;
using SolidR.FluentMigrator;
using SolidR.TestFx;
using StructureMap;

namespace HowShop.Tests.Boot
{
    public class TestRegistry : Registry
    {
        public TestRegistry()
        {
            For<IDatabaseMigrator>().Use<FluentDatabaseMigrator>();
            For<IDatabaseCleaner>().Use<RespawnDatabaseCleaner>();

            Scan(scanner =>
            {
                scanner.AssemblyContainingType<TestRegistry>();
                scanner.WithDefaultConventions();
                scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>));
                scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncNotificationHandler<>));
            });
            For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
            For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));
            //For<TextWriter>().Use(Console.Out);
        }
    }
}
