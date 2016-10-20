using System.Net;
using System.Web.Mvc;
using FluentValidation;
using Newtonsoft.Json;

namespace SolidR.Core.Mvc
{
    public class HandleValidationException : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception is ValidationException)
            {
                if (filterContext.HttpContext.Request.HttpMethod == "GET")
                {
                    var result = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    filterContext.Result = result;
                }
                else
                {
                    var result = new ContentResult();
                    var exception = (ValidationException)filterContext.Exception;

                    var content = JsonConvert.SerializeObject(
                        exception.Errors,
                        new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

                    result.Content = content;
                    result.ContentType = "application/json";

                    filterContext.HttpContext.Response.StatusCode = 400;
                    filterContext.Result = result;
                }
            }
        }
    }
}
