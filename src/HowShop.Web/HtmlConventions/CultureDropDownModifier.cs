using HowShop.Core.Concerns;
using HtmlTags.Conventions;
using HtmlTags.Conventions.Elements;

namespace HowShop.Web.HtmlConventions
{
    public class CultureDropDownModifier : IElementModifier
    {
        public bool Matches(ElementRequest token)
        {
            return token.Accessor.PropertyType == typeof (Culture);
        }

        public void Modify(ElementRequest request)
        {
            request.ModifyWithDropDown(
                Culture.GetAll(),
                x => x.Id,
                x => x.Name);
        }
    }
}