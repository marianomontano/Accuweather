using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Repositories
{
    public class RegionRepository
    {
        public static List<RegionModel> Regiones { get; } = new List<RegionModel>();

        public static void Agregar(List<RegionModel> regionModels)
        {
            regionModels.ForEach(region => 
            {
                if (!Regiones.Contains(region))
                    Regiones.Add(region);
            });
        }
    }
}
