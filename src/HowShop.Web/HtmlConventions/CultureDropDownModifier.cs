﻿using HowShop.Core.Concerns;
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

            //request.CurrentTag.RemoveAttr("type");
            //request.CurrentTag.TagName("select");

            //var value = request.Value<Culture>();

            //foreach (var currency in Culture.GetAll())
            //{
            //    var optionTag = new HtmlTag("option")
            //        .Value(currency.Id)
            //        .Text(currency.Name);

            //    if (value == currency)
            //        optionTag.Attr("selected");

            //    request.CurrentTag.Append(optionTag);
            //}
        }
    }
}