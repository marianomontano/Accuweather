using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;
using UI.Repositories;
using UI.Utilities;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LocationAccess _locationAccess;


        public HomeController(ILogger<HomeController> logger, LocationAccess locationAccess)
        {
            _logger = logger;
            _locationAccess = locationAccess;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if(RegionRepository.Regiones.Count < 1)
            {
                await _locationAccess.RegionesGetAll();
            }
            

            var regiones = new List<SelectListItem>();

            RegionRepository.Regiones.ForEach(x =>
            {
                regiones.Add(new SelectListItem(x.EnglishName, x.ID));
            });

            ViewBag.Regiones = regiones;
            return View();
        }

        public async Task<IActionResult> FiltrarPaisesAsync(string regionID)
        {
            if(CountriesRepository.Paises.Any(x => x.RegionID == regionID) == false)
            {
                await _locationAccess.PaisesGetByRegion(regionID);
            }

            var paises = CountriesRepository.Paises.Where(x => x.ID == regionID);

            return Json(paises.Select(p => new
            {
                id = p.ID,
                name = p.EnglishName
            }).ToList());
        }

        public async Task<IActionResult> FiltrarCiudadesAsync(string paisID)
        {
            if(CitiesRepository.Ciudades.Any(x => x.CountryID == paisID) == false)
            {
                await _locationAccess.CiudadesGetByPais(paisID);
            }

            var ciudades = CitiesRepository.Ciudades.Where(x => x.CountryID == paisID);

            return Json(ciudades.Select(p => new
            {
                key = p.Key,
                name = p.EnglishName
            }).ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
