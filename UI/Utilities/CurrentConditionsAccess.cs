using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Utilities
{
    public class CurrentConditionsAccess
    {
        public HttpClient Cliente { get; set; }
        private static string Url;
        private static string ApiKey;
        private IConfiguration _configuration;
        public CurrentConditionsAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            ApiKey = _configuration["Private:ApiKey"];
            Url = _configuration["Private:Url"];
        }

        public async Task<CurrentConditionsModel> CondicionesActuales(int cityKey)
        {
            Cliente = new HttpClient();

            using (var response = await Cliente.GetAsync(Url + $"currentconditions/v1/{cityKey}?apikey={ApiKey}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string condicionesJson = await response.Content.ReadAsStringAsync();
                    var condicionesActuales = JsonConvert.DeserializeObject<CurrentConditionsModel>(condicionesJson);
                    return condicionesActuales;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
