using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMotors.Models;
using WebMotors.Repository;

namespace WebMotors.Business
{
    public class AnuncioBusiness
    {
        AnuncioRepository repository = new AnuncioRepository();

        public AnuncioBusiness()
        {

        }

        public string AddAnuncio(Anuncio anuncio)
        {
            try
            {
                repository.AddAnuncio(anuncio);
                return "Anuncio Adicionado com Sucesso";
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}