using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class CurrentConditionsModel
    {
        [Display(Name = "Hora de observación")]
        [DataType(DataType.DateTime)]
        public DateTime LocalObservationDateTime { get; set; }

        [Display(Name = "Condición climática")]
        public string WeatherText { get; set; }

        [Display(Name = "Precipitación actualmente")]
        public bool HasPrecipitation { get; set; }

        [Display(Name = "Precipitación en mm3")]
        public PrecipitationSummaryModel PrecipitationSummary { get; set; }

        [Display(Name = "Tipo de precipitación")]
        public string PrecipitationType { get; set; }

        [Display(Name = "Temperatura")]
        public TemperatureModel Temperature { get; set; }

        [Display(Name = "Sensación Térmica")]
        public TemperatureModel RealFeelTemperature { get; set; }

        [Display(Name ="Viento")]
        public WindModel Wind { get; set; }

        [Display(Name = "Presión atmosférica")]
        public PressureModel Pressure { get; set; }
    }
}
