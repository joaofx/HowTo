using System;
using System.Collections.Generic;
using HtmlTags;
using HtmlTags.Conventions;

namespace HowShop.Web.Html.Conventions
{
    /// <summary>
    /// TODO: unit tests
    /// TODO: unit tests when current value is null
    /// TODO: tagBuilder as function
    /// </summary>
    public static class ElementRequestExtensions
    {
        public static void ModifyWithDropDown<TType>(
            this ElementRequest request, 
            IEnumerable<TType> items,
            Func<TType, string> getId,
            Func<TType, string> getDisplay)
        {
            request.CurrentTag.RemoveAttr("type");
            request.CurrentTag.TagName("select");

            var value = request.Value<TType>();
            
            foreach (var item in items)
            {
                var optionTag = new HtmlTag("option")
                    .Value(getId(item))
                    .Text(getDisplay(item));

                if (value != null && value.Equals(item))
                    optionTag.Attr("selected");

                request.CurrentTag.Append(optionTag);
            }
        }
    }
}