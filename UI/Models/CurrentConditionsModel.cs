using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class CurrentConditionsModel
    {
        public string LocalObservationDateTime { get; set; }
        public string WeatherText { get; set; }
        public bool HasPrecipitation { get; set; }
        public string PrecipitationType { get; set; }
        public List<TemperatureModel> Temperature { get; set; }
    }
}
