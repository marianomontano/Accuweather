using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;
using UI.Utilities;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LocationAccess _locationAccess;
        private readonly CurrentConditionsAccess _conditionsAccess;

        public HomeController(ILogger<HomeController> logger, LocationAccess locationAccess, CurrentConditionsAccess conditionsAccess)
        {
            _logger = logger;
            _locationAccess = locationAccess;
            _conditionsAccess = conditionsAccess;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var regiones = new List<SelectListItem>();
            _locationAccess.RegionesGetAll().Result.ForEach(x =>
            {
                regiones.Add(new SelectListItem(x.EnglishName, x.ID));
            });
            ViewBag.Regiones = regiones;
            return View();
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

        public IActionResult FiltrarPaises(string regionID)
        {
            var paises = _locationAccess.PaisesGetByRegion(regionID);

            return Json(paises.Result.Select(p => new { 
                id = p.ID,
                name = p.EnglishName
            }).ToList());   
        }

        public JsonResult FiltrarCiudades(string paisID)
        {
            var ciudades = _locationAccess.CiudadesGetByPais(paisID);

            return Json(ciudades.Result.Select(p => new { 
                key = p.Key,
                name = p.EnglishName
            }).ToList());
        }
    }
}
