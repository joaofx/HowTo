using System.Web.Mvc;
using HowShop.Core.Queries;
using HowShop.Web.Models;
using MediatR;

namespace HowShop.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [OutputCache(Duration = 3600, VaryByParam = "tag")]
        public ActionResult Lista(string tag = "")
        {
            var products = _mediator.Send(new ProductList.Query());

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