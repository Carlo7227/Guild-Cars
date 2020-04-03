using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repositories.EF
{
    public class MakeRepo : IMakeRepo
    {
        GuildCarsEntities context;

        public MakeRepo()
        {
            context = new GuildCarsEntities();
        }

        public IEnumerable<Make> GetAllMakes()
        {
            var query = from m in context.Makes
                        select m;

            return query.ToList();
        }
        public void CreateMake(Make make)
        {
            context.Makes.Add(make);
            context.SaveChanges();
        }
    }
}
