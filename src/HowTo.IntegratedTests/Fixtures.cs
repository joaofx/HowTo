using System;
using Ploeh.AutoFixture;
using SolidR.TestFx.FixtureHelpers;
using SolidR.TestFx.SpecimenBuilders;

namespace HowTo.IntegratedTests
{
    public class Fixtures
    {
        private static readonly Fixture Fixture;

        static Fixtures()
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

        public static T Create<T>(params Action<T>[] composers)
        {
            var item = Fixture.Create<T>();

            foreach (var compose in composers)
            {
                compose?.Invoke(item);
            }

            return item;
        }
    }
}
