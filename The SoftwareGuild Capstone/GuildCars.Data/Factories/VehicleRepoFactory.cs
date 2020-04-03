using GuildCars.Data.Interfaces;
using GuildCars.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Factories
{
    public static class VehicleRepoFactory
    {
        public static IVehicleRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "EF":
                    return new VehicleRepoEF();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
