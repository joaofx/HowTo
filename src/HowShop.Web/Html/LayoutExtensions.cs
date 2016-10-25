using System.Web.Mvc;
using HtmlTags;

namespace HowShop.Web.Html
{
    public static class LayoutExtensions
    {
        public static HtmlTag NoData(this HtmlHelper helper, string message)
        {
            return new HtmlTag("div")
                .AddClass("alert")
                .AddClass("alert-warning")
                .Text(message);
        }
    }
}