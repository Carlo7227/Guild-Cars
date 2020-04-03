using GuildCars.Data.Interfaces;
using GuildCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repositories.EF
{
    public class SpecialsRepo : ISpecialsRepo
    {
        GuildCarsEntities context;

        public SpecialsRepo()
        {
            context = new GuildCarsEntities();
        }

        public void CreateSpecial(Special special)
        {
            context.Specials.Add(special);
            context.SaveChanges();
        }

        public List<Special> GetAll()
        {
            var query = from m in context.Specials
                        select m;

            return query.ToList();
        }
    }
}
