using HowShop.Core.Infra;
using NUnit.Framework;
using Shouldly;
using StructureMap.Pipeline;

namespace HowTo.IntegratedTests.Features.Testing
{
    [TestFixture]
    public class IntegratedDslTest : IntegratedTest
    {
        [Test]
        public void Db_contexts_should_be_transient_inside_test_container()
        {
            int firstDbContextHashCode = 0;
            int secondDbContextHashCode = 0;

            WithDb(db =>
            {
                firstDbContextHashCode = db.GetHashCode();
            });

            WithDb(db =>
            {
                secondDbContextHashCode = db.GetHashCode();
            });

            firstDbContextHashCode.ShouldNotBe(secondDbContextHashCode);
        }
    }
}
