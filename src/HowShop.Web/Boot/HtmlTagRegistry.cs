using HowShop.Web.Html.Conventions;
using HtmlTags.Conventions;
using SolidR.Core.Mvc;
using StructureMap;

namespace HowShop.Web.Boot
{
    public class HtmlTagRegistry : Registry
    {
        public HtmlTagRegistry()
        {
            var htmlConventionLibrary = new HtmlConventionLibrary();
            new HowShopHtmlConventions().Apply(htmlConventionLibrary);
            new DefaultHtmlConventions().Apply(htmlConventionLibrary);
            For<HtmlConventionLibrary>().Use(htmlConventionLibrary);
        }
    }
}
