using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SolidR.Mvc
{
    public static class ControllerExtensions
    {
        public static ContentResult RedirectJson(this Controller controller, string url)
        {
            return controller.JsonNet(new { redirect = url });
        }

        public static ActionResult RedirectToActionJson<TController>(
            this Controller controller, Expression<Action<TController>> action) where TController : Controller
        {
            return controller.JsonNet(new
            {
                redirect = controller.Url.Action(action)
            });
        }

        public static ActionResult RedirectToActionJson<TController>(this TController controller, Expression<Action<TController>> action)
            where TController : Controller
        {
            return controller.JsonNet(new
            {
                redirect = controller.Url.Action(action)
            });
        }

        public static ActionResult RedirectToActionJson<TController>(this TController controller, string action)
            where TController : Controller
        {
            return controller.JsonNet(new
            {
                redirect = controller.Url.Action(action)
            });
        }

        public static ContentResult JsonNet(this Controller controller, object model)
        {
            var serialized = JsonConvert.SerializeObject(model, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return new ContentResult
            {
                Content = serialized,
                ContentType = "application/json"
            };
        }

        public static RedirectToRouteResult RedirectToAction<TController>(
            this TController controller,
            Expression<Action<TController>> action) where TController : Controller
        {
            return Microsoft.Web.Mvc.ControllerExtensions.RedirectToAction(controller, action);
        }
    }
}
