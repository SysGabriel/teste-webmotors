using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMotors.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Editar()
        {
            ViewBag.Title = "Editar";

            return View();
        }

        public ActionResult Deletar()
        {
            ViewBag.Title = "Deletar";

            return View();
        }
    }
}
