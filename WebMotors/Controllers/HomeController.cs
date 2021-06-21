﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMotors.Services;
using WebMotors.Repository;
using WebMotors.Models;

namespace WebMotors.Controllers
{
    public class HomeController : Controller
    {
        AnuncioRepository repository = new AnuncioRepository();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            AnuncioService service = new AnuncioService();
            try
            {
                ViewBag.AnunciosSalvos = repository.GetAnuncios();
                var marcasOnline = service.GetMarcas();
                ViewBag.MarcasOnline = marcasOnline;                
            }
            catch(Exception ex)
            {
                Response.StatusCode = 200;
                throw ex;
            }
            

            return View();
        }

        public JsonResult ConsultarModelos (int marcaId)
        {
            AnuncioService service = new AnuncioService();
            try
            {
                var modelos = service.GetModelos(marcaId);
                Response.StatusCode = 200;
                return Json(modelos);
            }catch(Exception ex)
            {
                Response.StatusCode = 500;
                throw ex;
            }
        } 

        public JsonResult ConsultarVersoes (int modeloId)
        {
            AnuncioService service = new AnuncioService();
            try
            {
                var versoes = service.GetVersoes(modeloId);
                Response.StatusCode = 200;
                return Json(versoes);
            }catch(Exception ex)
            {
                Response.StatusCode = 500;
                throw ex;
            }

        }

        [HttpPost]
        public JsonResult Adicionar(Anuncio anuncio)
        {
            AnuncioService service = new AnuncioService();
            ViewBag.AnunciosSalvos = repository.GetAnuncios();
            try
            {
                repository.AddAnuncio(anuncio);
                Response.StatusCode = 200;
                return Json("Adicionado com sucesso");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                throw ex;
            }
            
        }

        [HttpPost]
        public JsonResult Editar(Anuncio anuncio)
        {
            ViewBag.Title = "Editar";
            try
            {
                repository.UpdateAnuncio(anuncio);
                Response.StatusCode = 200;
                return Json("Editado com Sucesso");
            }catch(Exception ex)
            {
                Response.StatusCode = 500;
                throw ex;
            }

            
        }

        [HttpPost]
        public JsonResult Deletar(int id)
        {
            ViewBag.Title = "Deletar";
            try
            {
                repository.DeleteAnuncio(id);
                Response.StatusCode = 200;
                return Json("Deletado com sucesso");
            }
            catch(Exception ex)
            {
                Response.StatusCode = 500;
                throw ex;
            }
            
        }

        //public JsonResult SalvarMarca
    }
}
