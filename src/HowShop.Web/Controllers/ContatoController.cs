using System.Web.Mvc;

namespace HowShop.Web.Controllers
{
    public class ContatoController : Controller
    {
        [OutputCache(Duration = 3600, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }
    }
}