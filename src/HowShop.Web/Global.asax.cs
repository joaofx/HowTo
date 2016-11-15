using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HowShop.Web.Infra;
using SolidR.Core;
using SolidR.Core.Domain;
using SolidR.Core.FluentMigrator;

namespace HowShop.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.Add(typeof(Entity), new EntityModelBinder());

            var migrator = App.Container.GetInstance<IDatabaseMigrator>();
            migrator.UpdateSchema();
        }
    }
}
