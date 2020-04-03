using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repositories.EF
{
    public class ColorsRepo : IColorsRepo
    {
        GuildCarsEntities context;

        public ColorsRepo()
        {
            context = new GuildCarsEntities();
        }

        public IEnumerable<Color> GetAllColors()
        {
            var query = from m in context.Colors
                        select m;

            return query.ToList();
        }
    }
}
