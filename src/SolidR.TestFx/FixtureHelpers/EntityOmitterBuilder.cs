using System.Linq;
using System.Reflection;
using Ploeh.AutoFixture.Kernel;
using SolidR.Core.Domain;

namespace SolidR.TestFx.FixtureHelpers
{
    public class IgnoreEntitiesReferenceProperties : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as PropertyInfo;

            if (pi == null)
            {
                return new NoSpecimen(request);
            }

            var isReferecingEntity = pi.PropertyType
                    .GetInterfaces()
                    .Any(t => t == typeof(IEntity));

            if (isReferecingEntity)
            {
                return null;
            }

            return new NoSpecimen(request);
        }
    }
}
