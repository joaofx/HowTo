using System.Web.Mvc;
using Newtonsoft.Json;

namespace SolidR.Mvc
{
    public class HandleAjaxPostException : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                var result = new ContentResult();

                App.Log.Error(filterContext.Exception);

                var errorMessage = "An error ocurred while the system was processing your request. Try again otherwise contact the Support";

                var content = JsonConvert.SerializeObject(
                    new
                    {
                        ErrorMessage = errorMessage,
                        Exception = filterContext.Exception
                    },
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

                result.Content = content;
                result.ContentType = "application/json";

                filterContext.HttpContext.Response.StatusCode = 500;
                filterContext.Result = result;
                filterContext.ExceptionHandled = true;
            }
        }
    }
}
