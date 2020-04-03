using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repositories.EF
{
    public class BodyTypeRepo : IBodyStyleRepo
    {
        GuildCarsEntities context;

        public BodyTypeRepo()
        {
            context = new GuildCarsEntities();
        }

        public IEnumerable<BodyType> GetAllBodyTypes()
        {
            var query = from m in context.BodyTypes
                        select m;

            return query.ToList();
        }
    }
}
