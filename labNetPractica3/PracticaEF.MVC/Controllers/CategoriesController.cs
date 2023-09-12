using PracticaEF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaEF.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoriesLogic _categoriesLogic;

        public CategoriesController()
        {
            _categoriesLogic = new CategoriesLogic();
        }

        public ActionResult Index()
        {
            var categories = _categoriesLogic.GetAll();
            return View(categories);
        }
    }
}