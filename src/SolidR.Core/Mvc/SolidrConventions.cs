using System;
using System.ComponentModel.DataAnnotations;
using HtmlTags;
using HtmlTags.Conventions;

namespace SolidR.Core.Mvc
{
    public class SolidrConventions : HtmlConventionRegistry
    {
        public ElementCategoryExpression DisplayLabels =>
            new ElementCategoryExpression(Library.TagLibrary.Category("DisplayLabels").Profile(TagConstants.Default));

        public SolidrConventions()
        {
            Editors
                .If(er => er.Accessor.Name.EndsWith("id", StringComparison.OrdinalIgnoreCase))
                .BuildBy(a => new HiddenTag().Value(a.StringValue()));

            Editors
                .IfPropertyIs<byte[]>()
                .BuildBy(a => new HiddenTag().Value(Convert.ToBase64String(a.Value<byte[]>())));
            
            Editors
                .If(er => er.Accessor.Name.EndsWith("password", StringComparison.OrdinalIgnoreCase))
                .ModifyWith(x => x.CurrentTag.Attr("type", "password"));

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
        }
    }
}
