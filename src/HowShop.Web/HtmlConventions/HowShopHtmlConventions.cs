using System;
using System.Collections.Generic;
using System.Linq;
using HowShop.Core.Domain;
using HtmlTags;
using HtmlTags.Conventions;
using HtmlTags.Conventions.Elements;
using NodaMoney;
using SolidR.Core.Domain;
using SolidR.Core.Mvc;

namespace HowShop.Web.HtmlConventions
{
    public class HowShopHtmlConventions : HtmlConventionRegistry
    {
        public HowShopHtmlConventions()
        {
            Editors.Always.AddClass("form-control");

            Editors.IfPropertyIs<DateTime?>().ModifyWith(m => m
                    .CurrentTag
                    .AddPattern("9{1,2}/9{1,2}/9999")
                    .Data("provide", "datepicker")
                    .AddClass("datepicker")
                    .Data("date-format", "mm/dd/yyyy")
                    .Value(m.Value<DateTime?>() != null ? m.Value<DateTime>().ToShortDateString() : string.Empty));

            Editors.Modifier<CurrencyDropDownModifier>();

            Labels.Always.AddClass("control-label");
            Labels.Always.AddClass("col-md-2");

            Displays.IfPropertyIs<decimal>()
                .ModifyWith(m => m.CurrentTag.Text(m.Value<decimal>().ToString("C")));
            
            // TODO: unit tests to test conventions
            Editors.IfPropertyIs<decimal>()
                .ModifyWith(m => m.CurrentTag.Value(m.Value<decimal>() == 0 ? string.Empty : m.Value<decimal>().ToString("F2")));
        }

        public class CurrencyDropDownModifier : IElementModifier
        {
            public bool Matches(ElementRequest token)
            {
                return token.Accessor.PropertyType == typeof (Currency);
            }

            public void Modify(ElementRequest request)
            {
                request.CurrentTag.RemoveAttr("type");
                request.CurrentTag.TagName("select");
                request.CurrentTag.AddClass("col-lg-8");

                var value = request.Value<Currency>();

                foreach (var currency in request.Get<Currencies>().GetAll())
                {
                    var optionTag = new HtmlTag("option")
                        .Value(currency.Code)
                        .Text($"{currency.Code} {currency.Symbol} - {currency.EnglishName}");

                    if (value == currency)
                        optionTag.Attr("selected");

                    request.CurrentTag.Append(optionTag);
                }
            }
        }
    }
}