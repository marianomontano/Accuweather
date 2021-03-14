using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Repositories
{
    public static class CitiesRepository
    {
        public static List<CityModel> Ciudades { get; } = new List<CityModel>();

        public static void Agregar(List<CityModel> cityModaels)
        {
            cityModaels.ForEach(ciudad =>
            {
                if (!Ciudades.Contains(ciudad))
                    Ciudades.Add(ciudad);
            });
        }
    }
}
