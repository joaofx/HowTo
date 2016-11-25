using System;
using System.Reflection;
using Ploeh.AutoFixture.Kernel;

namespace SolidR.TestFx.FixtureHelpers
{
    public class IdOmitterBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            var property = request as PropertyInfo;

            if (property == null)
            {
                return new NoSpecimen();
            }

            if (IsId(property))
            {
                return Activator.CreateInstance(property.PropertyType);
            }

            if (IsIdString(property))
            {
                return "0";
            }

            return new NoSpecimen();
        }

        private bool IsIdString(PropertyInfo property)
        {
            return property.Name.EndsWith("Id") && property.PropertyType == typeof(string);
        }

        private static bool IsId(PropertyInfo property)
        {
            return property.Name.EndsWith("Id") && (
                property.PropertyType == typeof(long) || 
                property.PropertyType == typeof(long?));
        }
    }
}
