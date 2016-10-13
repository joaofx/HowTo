﻿using System.Web.Mvc;
using HowShop.Core.Commands;
using HowShop.Core.Queries;
using HowShop.Web.Models;
using MediatR;
using SolidR.Mvc;

namespace HowShop.Web.Controllers
{
    public class AdminProductController : Controller
    {
        private readonly IMediator _mediator;

        public AdminProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ActionResult Index()
        {
            var result = _mediator.Send(new ProductList.Query());
            return View(result);
        }

        public ActionResult New()
        {
            return View("Edit", new ProductEdit.Command());
        }

        [HttpPost]
        public ActionResult Edit(ProductEdit.Command command)
        {
            _mediator.Send(command);
            return this.RedirectToActionJson(c => c.Index());
        }
    }
}