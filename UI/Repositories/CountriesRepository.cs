using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Repositories
{
    public class CountriesRepository
    {
        private static LocationAccess _locationAccess;
        public static List<CountryModel> Paises { get; } = new List<CountryModel>();

        public CountriesRepository(LocationAccess locationAccess)
        {
            _locationAccess = locationAccess;
        }


        public static async Task Agregar(List<CountryModel> countryModels, string region)
        {
            foreach(var pais in countryModels)
            {
                pais.RegionID = region;

                if (!Paises.Contains(pais))
                    Paises.Add(pais);
            }
        }
    }
}
