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

        public ActionResult Index(int marcaId)
        {
            ViewBag.Title = "Home Page";
            AnuncioService service = new AnuncioService();
            ViewBag.MarcasOnline = service.GetMarcas();
            ViewBag.ModelosOnline = service.GetModelos(marcaId);
            ViewBag.AnunciosSalvos = repository.GetAnuncios();

            return View();
        }

        public ActionResult Index(int marcaId, int modeloId)
        {
            ViewBag.Title = "Home Page";
            AnuncioService service = new AnuncioService();
            ViewBag.MarcasOnline = service.GetMarcas();
            ViewBag.ModelosOnline = service.GetModelos(marcaId);
            ViewBag.VersoesOnline = service.GetVersoes(modeloId);
            ViewBag.AnunciosSalvos = repository.GetAnuncios();

            return View();
        }
        [HttpPost]
        public JsonResult Adicionar(int marcaId, int modeloId, int )
        {
            ViewBag.Title = "Home Page";
            AnuncioService service = new AnuncioService();
            ViewBag.MarcasOnline = service.GetMarcas();
            ViewBag.AnunciosSalvos = repository.GetAnuncios();

            return Json("Adicionado com sucesso");
        }

        [HttpPost]
        public JsonResult Editar()
        {
            ViewBag.Title = "Editar";

            
            return Json("Editado com Sucesso");
        }

        [HttpPost]
        public JsonResult Deletar(int id)
        {
            ViewBag.Title = "Deletar";

            return Json("Deletado com sucesso");
        }

        //public JsonResult SalvarMarca
    }
}
