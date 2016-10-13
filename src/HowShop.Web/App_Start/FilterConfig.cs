using System.Web.Mvc;
using SolidR.Mvc;

namespace HowShop.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleValidationException());
            filters.Add(new HandleAjaxPostException());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
