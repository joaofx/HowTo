using System;
using NSubstitute;
using Ploeh.AutoFixture;
using SolidR.TestFx.FixtureHelpers;
using SolidR.TestFx.SpecimenBuilders;
using StructureMap;

namespace SolidR.TestFx
{
    public class TestFixture
    {
        private readonly IContainer _container;
        private static readonly Fixture Fixture;

        public TestFixture(IContainer container)
        {
            _container = container;
        }

        static TestFixture()
        {
            Fixture = new Fixture();
            Fixture.Customizations.Add(new IdOmitterBuilder());
            Fixture.Customizations.Add(new IsDeletedBuilder());
            Fixture.Customizations.Add(new ListOmitterBuilder());
            Fixture.Customizations.Add(new IgnoreEntitiesReferenceProperties());
            Fixture.Customizations.Add(new EmailSpecimenBuilder());

            Fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        public T Create<T>(params Action<T>[] composers)
        {
            var item = Fixture.Create<T>();

            foreach (var compose in composers)
            {
                compose?.Invoke(item);
            }

            return item;
        }

        public T Mock<T>() where T : class
        {
            var mock = Substitute.For<T>();

            _container.EjectAllInstancesOf<T>();
            _container.Inject(mock);

            return mock;
        }
    }
}
