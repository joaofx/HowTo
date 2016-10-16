using System.Web;
using StructureMap.Web.Pipeline;

namespace HowShop.Web.Boot
{
    public class StructureMapScopeModule : IHttpModule
    {

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, e) => StructureMapMvc.StructureMapDependencyScope.CreateNestedContainer();

            context.EndRequest += (sender, e) => 
            {
                HttpContextLifecycle.DisposeAndClearAll();
                StructureMapMvc.StructureMapDependencyScope.DisposeNestedContainer();
            };
        }
    }
}