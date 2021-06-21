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

        [JsonProperty("MakeId")]
        public int MarcaId { get; set; }
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("Name")]
        public string Nome { get; set; }
    }
}