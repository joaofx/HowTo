using HowShop.Web.HtmlConventions;
using HtmlTags.Conventions;
using SolidR.Mvc;
using StructureMap;

namespace HowShop.Web.Boot
{
    public class HtmlTagRegistry : Registry
    {
        public HtmlTagRegistry()
        {
            var htmlConventionLibrary = new HtmlConventionLibrary();
            new SolidrConventions().Apply(htmlConventionLibrary);
            new HowShopHtmlConventions().Apply(htmlConventionLibrary);
            new DefaultHtmlConventions().Apply(htmlConventionLibrary);
            For<HtmlConventionLibrary>().Use(htmlConventionLibrary);
        }
    }
}
