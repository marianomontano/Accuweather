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
        public static HttpClient Cliente;
        private static string ApiKey;
        public CurrentConditionsAccess(IConfiguration configuration, APIHelper  apiHelper)
        {
            ApiKey = configuration["Private:ApiKey"];
            apiHelper.InicializarCliente();
            Cliente = apiHelper.Cliente;
        }

        public async Task<CurrentConditionsModel> ClimaPorCiudad(int cityKey)
        {
            using (var response = await Cliente.GetAsync($"currentconditions/v1/{cityKey}?apikey={ApiKey}&lang=es-es"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string condicionesJson = await response.Content.ReadAsStringAsync();
                    var condicionesActuales = JsonConvert.DeserializeObject<List<CurrentConditionsModel>>(condicionesJson);
                    return condicionesActuales[0];
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
