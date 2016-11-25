using System;
using System.IO;
using FluentValidation;
using HowShop.Core.Concerns;
using HowShop.Core.Handlers;
using MediatR;
using SolidR.Core.Handlers;
using SolidR.Core.Validation;
using StructureMap;

namespace HowShop.Core.Boot
{
    public class MediatorPipelineRegistry : Registry
    {
        public MediatorPipelineRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<MediatorPipelineRegistry>();
                scanner.WithDefaultConventions();
                scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>));
                scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncNotificationHandler<>));

                // TODO: move to ValidationRegistry
                scanner.AddAllTypesOf(typeof(IValidator<>));
                scanner.AddAllTypesOf(typeof(IAuthorization<>));
            });

            For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
            For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));
            For<TextWriter>().Use(Console.Out);

            // TODO: move to ValidationRegistry
            For<IValidatorFactory>().Use<StructureMapValidatorFactory>();

            // first here is last to be executed
            var handlerType = For(typeof(IRequestHandler<,>));
            handlerType.DecorateAllWith(typeof(ValidatorHandler<,>));
            handlerType.DecorateAllWith(typeof(AuthorizationHandler<,>));
            handlerType.DecorateAllWith(typeof(TransactionHandler<,>));
            handlerType.DecorateAllWith(typeof(LogHandler<,>));
        }
    }
}
