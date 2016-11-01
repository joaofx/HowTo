using HowShop.Core.Concerns;
using HtmlTags.Conventions;
using HtmlTags.Conventions.Elements;

namespace HowShop.Web.Html.Conventions
{
    public class LanguageDropDownModifier : IElementModifier
    {
        public bool Matches(ElementRequest token)
        {
            return token.Accessor.PropertyType == typeof (Language);
        }

        public void Modify(ElementRequest request)
        {
            request.ModifyWithDropDown(
                Language.GetAll(), 
                x => x.Id,
                x => x.Name);
        }
    }
}