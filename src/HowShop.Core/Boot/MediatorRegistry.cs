using System;
using System.IO;
using FluentValidation;
using HowShop.Core.Handlers;
using HowShop.Core.Infra;
using MediatR;
using SolidR.Handlers;
using StructureMap;

namespace HowShop.Core.Boot
{
    public class MediatorRegistry : Registry
    {
        public MediatorRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<MediatorRegistry>();
                scanner.WithDefaultConventions();
                scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>));
                scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncNotificationHandler<>));

                scanner.AddAllTypesOf(typeof(IValidator<>));
            });

            For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
            For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));
            For<TextWriter>().Use(Console.Out);

            // first here is last to be executed
            var handlerType = For(typeof(IRequestHandler<,>));
            handlerType.DecorateAllWith(typeof(ValidatorHandler<,>));
            handlerType.DecorateAllWith(typeof(TransactionHandler<,>));
        }
    }
}
