using System.Net.Mail;
using System.Reflection;
using Ploeh.AutoFixture.Kernel;

namespace SolidR.TestFx.SpecimenBuilders
{
    public class EmailSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            var propertyInfo = request as PropertyInfo;

            if (propertyInfo != null)
            {
                if (propertyInfo.Name == "Email" && propertyInfo.PropertyType == typeof(string))
                {
                    var mailAddress = (MailAddress) context.Resolve(typeof (MailAddress));
                    return mailAddress.Address;
                }
            }
            return new NoSpecimen();
        }
    }
}
