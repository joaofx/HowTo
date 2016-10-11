using System.Web.Mvc;
using HowShop.Web.Models;

namespace HowShop.Web.Controllers
{
    public class ProdutoController : Controller
    {
        [OutputCache(Duration = 3600, VaryByParam = "tag")]
        public ActionResult Lista(string tag = "")
        {
            ViewBag.Tag = tag;
            return View(Products.All(tag));
        }

        [OutputCache(Duration = 3600, VaryByParam = "id")]
        public ActionResult Mostrar(string id)
        {
            return View(Products.ById(id));
        }
    }
}