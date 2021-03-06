﻿using GuildCars.Data.Interfaces;
using GuildCars.Data.Repositories.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Factories
{
     public class ColorRepoFactory
    {
        public static IColorsRepo GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "EF":
                    //dont forget to inherit from your interface
                    return new ColorsRepo();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
