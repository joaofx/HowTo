using System;
using System.Linq;
using HtmlTags.Conventions;
using HtmlTags.Conventions.Elements;

namespace HowShop.Web.Html.Conventions
{
    public class EnumDropDownModifier : IElementModifier
    {
        public bool Matches(ElementRequest token)
        {
            return token.Accessor.PropertyType.IsEnum;
        }

        public void Modify(ElementRequest request)
        {
            var enumType = request.Accessor.PropertyType;

            //request.ModifyWithDropDown(
            //    Enum.GetValues(enumType.GetType()).Cast<SomeEnum>();,
            //    x => x.,
            //    x => x.DisplayName);
        }
    }
}