using System;
using HtmlTags;
using HtmlTags.Conventions;
using HtmlTags.Conventions.Elements;
using HtmlTags.Extended.Attributes;

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
            // TODO: if it is Enum? add blank option, otherwise don't
            var enumType = request.Accessor.PropertyType;

            request.CurrentTag.RemoveAttr("type");
            request.CurrentTag.TagName("select");
            request.CurrentTag.Append(new HtmlTag("option"));

            foreach (var value in Enum.GetValues(enumType))
            {
                var optionTag = AttributesExtensions.Value(new HtmlTag("option"), value.ToString())
                    .Text(Enum.GetName(enumType, value));

                request.CurrentTag.Append(optionTag);
            }
        }
    }
}