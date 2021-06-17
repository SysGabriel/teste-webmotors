using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMotors.Models
{
    public class Modelo
    {
        public Modelo()
        {

        }
        [JsonProperty("Id")]
        public int idModelo { get; set; }
        [JsonProperty("Name")]
        public string NomeModelo { get; set; }
    }
}