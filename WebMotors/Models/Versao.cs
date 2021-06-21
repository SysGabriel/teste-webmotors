using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebMotors.Models
{
    public class Versao
    {
        public Versao()
        {

        }
        [JsonProperty("ModelId")]
        public int ModeloId { get; set; }
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("Name")]
        public string Nome { get; set; }
    }
}