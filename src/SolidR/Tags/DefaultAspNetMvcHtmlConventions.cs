using System;
using System.ComponentModel.DataAnnotations;
using HtmlTags;
using HtmlTags.Conventions;

namespace SolidR.Tags
{
    public class DefaultAspNetMvcHtmlConventions : HtmlConventionRegistry
    {
        public DefaultAspNetMvcHtmlConventions()
        {
            // TODO: Split this into Html5 Conventions and TwitterBootstrap Conventions. Check if is possible to compose Conventions
            Editors
                .Always
                .AddClass("form-control");

            Editors
                .IfPropertyIs<DateTime?>().ModifyWith(m => m
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

            Labels
                .Always
                .AddClass("control-label");

            Labels
                .Always
                .AddClass("col-md-2");

            Labels
                .ModifyForAttribute<DisplayAttribute>((t, a) => t.Text(a.Name));

            DisplayLabels
                .Always
                .BuildBy<DefaultDisplayLabelBuilder>();

            DisplayLabels
                .ModifyForAttribute<DisplayAttribute>((t, a) => t.Text(a.Name));

            Displays
                .IfPropertyIs<DateTime>()
                .ModifyWith(m => m.CurrentTag.Text(m.Value<DateTime>().ToShortDateString()));

            Displays
                .IfPropertyIs<DateTime?>()
                .ModifyWith(m => m.CurrentTag.Text(m.Value<DateTime?>() == null ? null : m.Value<DateTime?>().Value.ToShortDateString()));

            Displays
                .IfPropertyIs<decimal>()
                .ModifyWith(m => m.CurrentTag.Text(m.Value<decimal>().ToString("C")));
        }

        public ElementCategoryExpression DisplayLabels => 
            new ElementCategoryExpression(Library.TagLibrary.Category("DisplayLabels").Profile(TagConstants.Default));
    }
}
