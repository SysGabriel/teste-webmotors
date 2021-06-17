using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using RestSharp;

namespace WebMotors.Models
{
    public class Anuncio
    {
        public Anuncio()
        {

        }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("Make")]
        public string Marca { get; set; }
        [JsonProperty("Model")]
        public string Modelo { get; set; }
        [JsonProperty("Version")]
        public string Versao { get; set; }
        [JsonProperty("YearModel")]
        public int Ano { get; set; }
        [JsonProperty("KM")]
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }

    }
}