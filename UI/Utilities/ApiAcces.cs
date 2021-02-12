using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using UI.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace UI
{
    public class ApiAcces
    {
        public HttpClient Cliente { get; set; }
        private  static string Url;
        private static string ApiKey;
        private IConfiguration _configuration;
        public ApiAcces(IConfiguration configuration)
        {
            _configuration = configuration;
            ApiKey = _configuration["Private:ApiKey"];
            Url = _configuration["Private:Url"];
        }
        public async Task<List<RegionModel>> RegionesGetAll()
        {
            Cliente = new HttpClient();

            using (var response = await Cliente.GetAsync(Url + $"regions?apikey={ApiKey}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string regionesjson = await response.Content.ReadAsStringAsync();
                    var regiones = JsonConvert.DeserializeObject<List<RegionModel>>(regionesjson);
                    return regiones;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


    }
}
