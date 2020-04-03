using GuildCars.Data.Interfaces;
using GuildCars.Data.Repositories.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Factories
{
    public class BodyStyleRepoFactory
    {
        public static IBodyStyleRepo GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "EF":
                    return new BodyTypeRepo();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
