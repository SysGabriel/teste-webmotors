using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMotors.Models
{
    public class Marca
    {
        public Marca()
        {

        }

        [JsonProperty("Id")]
        public int IdMarca { get; set; }
        [JsonProperty("Name")]
        public string NomeMarca { get; set; }
    }
}