using System.Web.Mvc;
using HtmlTags;

namespace SolidR.Mvc
{
    public static class FormExtensions
    {
        public static HtmlTag FormSummary(this HtmlHelper helper)
        {
            // TODO: Conventional way to configure FormSummary attributes. It is tight to TwitterBootstrap here
            return new HtmlTag("div")
                .AddClass("form-summary")
                .AddClass("alert")
                .AddClass("alert-danger")
                .AddClass("hidden");
        }
    }
}
