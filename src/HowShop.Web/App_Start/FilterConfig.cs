using System.Web.Mvc;
using HowShop.Web.Infra;
using SolidR.Core.Mvc;

namespace HowShop.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleValidationException());
            filters.Add(new HandleAjaxPostException());
            filters.Add(new TurbolinksAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
