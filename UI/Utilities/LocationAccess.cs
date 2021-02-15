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
    public class LocationAccess
    {
        public HttpClient Cliente { get; set; }
        private  static string Url;
        private static string ApiKey;
        private IConfiguration _configuration;
        public LocationAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            ApiKey = _configuration["Private:ApiKey"];
            Url = _configuration["Private:Url"];
        }

        public async Task<List<RegionModel>> RegionesGetAll()
        {
            Cliente = new HttpClient();

            using (var response = await Cliente.GetAsync(Url + $"locations/v1/regions?apikey={ApiKey}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string regionesJson = await response.Content.ReadAsStringAsync();
                    var regiones = JsonConvert.DeserializeObject<List<RegionModel>>(regionesJson);
                    return regiones;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<CountryModel>> PaisesGetByRegion(string region)
        {
            Cliente = new HttpClient();

            using (var response = await Cliente.GetAsync(Url + $"locations/v1/countries/{region}?apikey={ApiKey}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string paisesJson = await response.Content.ReadAsStringAsync();
                    var paises = JsonConvert.DeserializeObject<List<CountryModel>>(paisesJson);
                    return paises;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<CityModel>> CiudadesGetByPais(string pais)
        {
            Cliente = new HttpClient();

            using (var response = await Cliente.GetAsync(Url + $"locations/v1/cities/{pais}?apikey={ApiKey}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string ciudadesJson = await response.Content.ReadAsStringAsync();
                    var ciudades = JsonConvert.DeserializeObject<List<CityModel>>(ciudadesJson);
                    return ciudades;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<CityModel> CiudadGetByNombre(string nombre)
        {
            Cliente = new HttpClient();

            using (var response = await Cliente.GetAsync(Url + $"locations/v1/cities/search?q={nombre}&apikey={ApiKey}"))
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
