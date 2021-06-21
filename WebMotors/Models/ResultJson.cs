using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMotors.Models
{
    public class ResultJson
    {
        public List<Marca> Marcas { get; set; }
        public List<Modelo> Modelos { get; set; }
        public List<Versao> Versoes { get; set; }
    }
}