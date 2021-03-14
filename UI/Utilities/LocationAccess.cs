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
using UI.Utilities;
using UI.Repositories;

namespace UI
{
    public class LocationAccess
    {
        private HttpClient _cliente;
        private static string ApiKey;
        public LocationAccess(IConfiguration configuration, APIHelper apiHelper)
        {
            ApiKey = configuration["Private:ApiKey"];
            apiHelper.InicializarCliente();
            _cliente = apiHelper.Cliente;
        }

        public async Task RegionesGetAll()
        {
            
            using (var response = await _cliente.GetAsync($"locations/v1/regions?apikey={ApiKey}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string regionesJson = await response.Content.ReadAsStringAsync();
                    var regiones = JsonConvert.DeserializeObject<List<RegionModel>>(regionesJson);
                    RegionRepository.Agregar(regiones);
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task PaisesGetByRegion(string region)
        {

            using (var response = await _cliente.GetAsync($"locations/v1/countries/{region}?apikey={ApiKey}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string paisesJson = await response.Content.ReadAsStringAsync();
                    var paises = JsonConvert.DeserializeObject<List<CountryModel>>(paisesJson);
                    CountriesRepository.Agregar(paises, region);
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task CiudadesGetByPais(string pais)
        {
            using (var response = await _cliente.GetAsync($"locations/v1/cities/{pais}?apikey={ApiKey}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string ciudadesJson = await response.Content.ReadAsStringAsync();
                    var ciudades = JsonConvert.DeserializeObject<List<CityModel>>(ciudadesJson);
                    CitiesRepository.Agregar(ciudades);
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<CityModel> CiudadGetByNombre(string nombre)
        {
            using (var response = await _cliente.GetAsync($"locations/v1/cities/search?q={nombre}&apikey={ApiKey}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string ciudadesJson = await response.Content.ReadAsStringAsync();
                    var ciudad = JsonConvert.DeserializeObject<CityModel>(ciudadesJson);
                    return ciudad;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
