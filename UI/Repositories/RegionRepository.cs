using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Repositories
{
    public class RegionRepository
    {
        private static LocationAccess _locationAccess;
        public static List<RegionModel> Regiones { get; } = new List<RegionModel>();

        public RegionRepository(LocationAccess locationAccess)
        {
            _locationAccess = locationAccess;
        }

        public static async Task Agregar(List<RegionModel> regionModels)
        {
            foreach(var region in regionModels)
            {
                if (!Regiones.Contains(region))
                    Regiones.Add(region);

                await _locationAccess.PaisesGetByRegion(region.ID);
            }
        }
    }
}
