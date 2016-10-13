using HtmlTags.Conventions;
using SolidR.Tags;
using StructureMap;

namespace SolidR.Boot
{
    public class HtmlTagRegistry : Registry
    {
        public HtmlTagRegistry()
        {
            var htmlConventionLibrary = new HtmlConventionLibrary();
            new DefaultAspNetMvcHtmlConventions().Apply(htmlConventionLibrary);
            new DefaultHtmlConventions().Apply(htmlConventionLibrary);
            For<HtmlConventionLibrary>().Use(htmlConventionLibrary);
        }
    }
}
