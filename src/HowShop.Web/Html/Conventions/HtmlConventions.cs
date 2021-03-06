﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Metadata.Edm;
using HtmlTags;
using HtmlTags.Conventions;
using HtmlTags.Extended.Attributes;
using SolidR.Core.Mvc;
using StructureMap;

namespace HowShop.Web.Html.Conventions
{
    public class HtmlConventions : HtmlConventionRegistry
    {
        public ElementCategoryExpression DisplayLabels =>
            new ElementCategoryExpression(Library.TagLibrary.Category("DisplayLabels").Profile(TagConstants.Default));

        public HtmlConventions()
        {
            Editors.Always.AddClass("form-control");

            ConfigEditors();
            ConfigLabels();
            ConfigDisplays();
            ConfigDisplayLabels();
        }

        private void ConfigDisplayLabels()
        {
            DisplayLabels.Always.BuildBy<DefaultDisplayLabelBuilder>();
            DisplayLabels.ModifyForAttribute<DisplayAttribute>((t, a) => t.Text(a.Name));
        }

        private void ConfigDisplays()
        {
            Displays.IfPropertyIs<DateTime>().ModifyWith(m => m.CurrentTag.Text(m.Value<DateTime>().ToShortDateString()));
            Displays.IfPropertyIs<decimal>().ModifyWith(m => m.CurrentTag.Text(m.Value<decimal>().ToString("C")));
        }

        private void ConfigLabels()
        {
            Labels.Always.AddClass("control-label");
            Labels.Always.AddClass("col-md-2");

            Labels.ModifyForAttribute<DisplayAttribute>((t, a) => t.Text(a.Name));
            Labels.Modifier<RequiredPropertyModifier>();

            Labels.IfPropertyNameEnds("Id").ModifyWith(m => m.CurrentTag.Text(m.Accessor.Name.RemoveLast(2)));
        }

        private void ConfigEditors()
        {
            Editors.Always.AddClass("form-control");

            // TODO: Scan all modifiers?
            Editors.Modifier<EnumDropDownModifier>();
            //Editors.Modifier<LookupDropDownModifier>();
            Editors.BuilderPolicy<CategorySelectElementBuilder>();

            Editors.Modifier<CurrencyDropDownModifier>();
            Editors.Modifier<LanguageDropDownModifier>();
            Editors.Modifier<CultureDropDownModifier>();
            Editors.Modifier<TimeZoneDropDownModifier>();
            
            Editors.IfPropertyIs<DateTime?>().ModifyWith(m => m
                  .CurrentTag
                  .AddPattern("9{1,2}/9{1,2}/9999")
                  .Data("provide", "datepicker")
                  .AddClass("datepicker")
                  .Data("date-format", "mm/dd/yyyy")
                  .Value(m.Value<DateTime?>() != null ? m.Value<DateTime>().ToShortDateString() : string.Empty));

            Editors
                .If(er => er.Accessor.Name.EndsWith("id", StringComparison.OrdinalIgnoreCase))
                .BuildBy(a => new HiddenTag().Value(a.StringValue()));

            Editors
                .IfPropertyIs<byte[]>()
                .BuildBy(a => new HiddenTag().Value(Convert.ToBase64String(a.Value<byte[]>())));

            Editors
                .If(er => er.Accessor.Name.EndsWith("password", StringComparison.OrdinalIgnoreCase))
                .ModifyWith(x => x.CurrentTag.Attr("type", "password"));

            Editors
                .IfPropertyIs<bool>()
                .ModifyWith(m =>
                {
                    m.CurrentTag.Attr("class", "").Attr("type", "checkbox").Attr("value", "true");
                    m.WrapWith(new HtmlTag("label"));
                });

            Editors.IfPropertyIs<decimal>()
                .ModifyWith(m => m.CurrentTag.Value(m.Value<decimal>() == 0 ? string.Empty : m.Value<decimal>().ToString("F2")));
        }
    }
}