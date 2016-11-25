using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using FubuCore;
using FubuCore.Binding;
using FubuCore.Configuration;
using NUnit.Framework;
using Shouldly;
using SolidR.Core;
using StructureMap;
using StructureMap.Graph;
using StructureMap.Graph.Scanning;
using StructureMap.Pipeline;

namespace HowTo.IntegratedTests.Features.Settings
{
    [TestFixture]
    public class SettingsProviderTest : IntegratedTest
    {
        [Test]
        public void Should_return_app_settings()
        {
            Container.Configure(cfg =>
            {
                cfg.Scan(scan =>
                {
                    scan.Convention<SettingsScanner>();
                });

                cfg.For<DatabaseSettings>()
                    .LifecycleIs(Lifecycles.Singleton)
                    .Use(u => u.GetInstance<ISettingsProvider>().SettingsFor<DatabaseSettings>());
            });

            //var settings = new AppSettingsProvider(ObjectResolver.Basic())
            //    .SettingsFor<DatabaseSettings>();

            var settings = Container.GetInstance<DatabaseSettings>();

            settings.ConnectionString.ShouldBe(ConfigurationManager.AppSettings["DatabaseSettings.ConnectionString"]);
        }
    }

    public class SettingsScanner : IRegistrationConvention
    {
        public static readonly Func<Type, bool> DefaultFilter =
            type => type.Name.EndsWith("Settings") && !type.IsInterface;

        private readonly Func<Type, bool> _filter;

        public SettingsScanner()
            : this(DefaultFilter)
        {
        }

        public SettingsScanner(Func<Type, bool> filter)
        {
            _filter = filter;
        }

        public void ScanTypes(TypeSet types, Registry registry)
        {
            types.FindTypes(TypeClassification.Concretes | TypeClassification.Closed)
                .Where(_filter)
                .Each(type => Process(type, registry));
        }

        public void Process(Type type, Registry graph)
        {
            var instanceType = typeof(SettingsInstance<>).MakeGenericType(type);
            var instance = Activator.CreateInstance(instanceType).As<Instance>();
            graph.For(type).Add(instance).Singleton();
        }
    }

    public class SettingsInstance<T> : LambdaInstance<T> where T : class, new()
    {
        public SettingsInstance() : base("Building {0} from application settings".ToFormat(typeof(T).FullName), c => c.GetInstance<ISettingsProvider>().SettingsFor<T>())
        {
            LifecycleIs<SingletonLifecycle>();
        }
    }
}
