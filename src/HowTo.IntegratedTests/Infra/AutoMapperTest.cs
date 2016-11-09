using AutoMapper;
using NUnit.Framework;

namespace HowTo.IntegratedTests.Infra
{
    /// <summary>
    /// TODO: No need to use integratedtest. Could have a base class with all dependecies scanned
    /// </summary>
    [TestFixture]
    public class AutoMapperTest : IntegratedTest
    {
        [Test]
        public void Should_have_valid_configuration()
        {
            Mapper.AssertConfigurationIsValid();
        }
    }
}
