using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace estudent.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Uvek na raspolaganju studentima.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";// "Kontakt podaci";

            return View();
        }
    }
}