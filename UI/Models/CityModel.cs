using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class CityModel
    {
        public int Key { get; set; }
        public string EnglishName { get; set; }
        public CountryModel Country { get; set; }
    }
}
