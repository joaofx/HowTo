using System;
using HtmlTags.Conventions;
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

            // TODO: Scan all modifiers?
            Editors.Modifier<CurrencyDropDownModifier>();
            Editors.Modifier<LanguageDropDownModifier>();
            Editors.Modifier<CultureDropDownModifier>();
            Editors.Modifier<TimeZoneDropDownModifier>();

            Labels.Always.AddClass("control-label");
            Labels.Always.AddClass("col-md-2");

            Displays.IfPropertyIs<decimal>()
                .ModifyWith(m => m.CurrentTag.Text(m.Value<decimal>().ToString("C")));
            
            // TODO: unit tests to test conventions
            Editors.IfPropertyIs<decimal>()
                .ModifyWith(m => m.CurrentTag.Value(m.Value<decimal>() == 0 ? string.Empty : m.Value<decimal>().ToString("F2")));
        }
    }
}