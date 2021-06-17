using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMotors.Services;
using WebMotors.Repository;

namespace WebMotors.Controllers
{
    public class HomeController : Controller
    {
        AnuncioRepository repository = new AnuncioRepository();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            AnuncioService service = new AnuncioService();
            ViewBag.MarcasOnline = service.GetMarcas();
            ViewBag.AnunciosSalvos = repository.GetAnuncios();

            return View();
        }

        public ActionResult Editar()
        {
            ViewBag.Title = "Editar";

            ViewBag.AnunciosSalvos = repository.GetAnuncios();
            return View();
        }

        public ActionResult Deletar()
        {
            ViewBag.Title = "Deletar";

            ViewBag.AnunciosSalvos = repository.GetAnuncios();
            return View();
        }

        //public JsonResult SalvarMarca
    }
}
