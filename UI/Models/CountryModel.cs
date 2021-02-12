using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class CountryModel
    {
        public string ID { get; set; }
        public string EnglishName { get; set; }
        public List<CityModel> Ciudades { get; set; } = new List<CityModel>();
        
    }
}
