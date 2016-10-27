using System.Reflection;
using Ploeh.AutoFixture.Kernel;

namespace SolidR.TestFx.FixtureHelpers
{
    public class IsDeletedBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            var property = request as PropertyInfo;

            if (property == null)
            {
                return new NoSpecimen(request);
            }

            if (property.Name.Equals("IsDeleted"))
            {
                return false;
            }

            return new NoSpecimen(request);
        }
    }
}
