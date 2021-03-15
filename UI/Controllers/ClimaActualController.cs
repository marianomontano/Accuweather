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
            if (ciudades < 1)
            {
                var condiciones = _condicionesActuales.ClimaPorCiudad(ciudades).Result; 

                return View(condiciones);
            }
            else
            {
                return BadRequest();
            }
        }

        /*
        var condiciones =   new CurrentConditionsModel
                {
                    LocalObservationDateTime = DateTime.Now,
                    WeatherText = "Sunny",
                    HasPrecipitation = false,
                    PrecipitationSummary = new PrecipitationSummaryModel
                    {
                        PastHour = new MetricModel
                        {
                            Unit = "mm3",
                            Value = 0
                        },
                        Past12Hours = new MetricModel
                        {
                            Unit = "mm3",
                            Value = 0
                        },
                        Past24Hours = new MetricModel
                        {
                            Unit = "mm3",
                            Value = 0   
                        }
                    },
                    PrecipitationType = null,
                    Temperature = new TemperatureModel
                    {
                        Metric = new MetricModel
                        {
                            Unit = "C",
                            Value = 27.3
                        }
                    },
                    RealFeelTemperature = new TemperatureModel
                    {
                        Metric = new MetricModel
                        {
                            Unit = "C",
                            Value = 27.4
                        }
                    },
                    Wind = new WindModel
                    {
                        Direction = new DirectionModel
                        {
                            English = "South East"
                        }
                    },
                    Pressure = new PressureModel
                    {
                        Metric = new MetricModel
                        {
                            Unit = "mb",
                            Value = 1008.0
                        }
                    }
                };
         */

    }
}
