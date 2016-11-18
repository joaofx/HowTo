using HtmlTags;

namespace SolidR.Core.Html
{
    public static class SelectTagExtensions
    {
        public static HtmlTag EmptyOption(this SelectTag htmlTag, string text = "")
        {
            htmlTag.InsertFirst(new HtmlTag("option").Value(string.Empty).Text(text));
            return htmlTag;
        }
    }
}
