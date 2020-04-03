using GuildCars.Data.Interfaces;
using GuildCars.Data.Repositories.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Factories
{
    public class SpecialRepoFactory
    {
        public static ISpecialsRepo GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "EF":
                    return new SpecialsRepo();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
