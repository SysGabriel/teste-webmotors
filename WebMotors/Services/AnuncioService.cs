using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using WebMotors.Models;

namespace WebMotors.Services
{
    public class AnuncioService
    {
        private RestClient Client { get; set; }
        private string Token { get; set; }

        public AnuncioService()
        {
            
        }

        private RestRequest CreateRequest(string endPoint, Method method)
        {
            var request = new RestRequest(endPoint, method);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Accept", "application/json");
            return request;
        }

        public Marca GetMarcas()
        {
            var request = CreateRequest("/api/OnlineChallenge/Make", Method.GET);
            try
            {
                var response = Client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<Marca>(response.Content);
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        

    }
}