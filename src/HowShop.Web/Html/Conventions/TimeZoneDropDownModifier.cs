using System;
using HtmlTags.Conventions;
using HtmlTags.Conventions.Elements;

namespace HowShop.Web.Html.Conventions
{
    public class TimeZoneDropDownModifier : IElementModifier
    {
        public bool Matches(ElementRequest token)
        {
            return token.Accessor.PropertyType == typeof (TimeZoneInfo);
        }

        public void Modify(ElementRequest request)
        {
            request.ModifyWithDropDown(
                TimeZoneInfo.GetSystemTimeZones(),
                x => x.Id,
                x => x.DisplayName);
        }
    }
}