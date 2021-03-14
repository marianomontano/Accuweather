using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;
using UI.Utilities;

namespace UI.Controllers
{
    public class ClimaActual : Controller
    {
        private CurrentConditionsAccess _condicionesActuales;

        public ClimaActual(CurrentConditionsAccess condiciones)
        {
            this._condicionesActuales = condiciones;
        }

        // GET: ClimaActual
        public ActionResult Index(int ciudades)
        {
            if (ciudades != -1)
            {
                var condiciones = _condicionesActuales.ClimaPorCiudad(ciudades).Result; 
                return View(condiciones);
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: ClimaActual/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClimaActual/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClimaActual/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClimaActual/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClimaActual/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClimaActual/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClimaActual/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
