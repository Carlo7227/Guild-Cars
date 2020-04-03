using GuildCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repositories.EF
{
    public class RolesRepo
    {
        GuildCarsEntities context;

        public RolesRepo()
        {
            context = new GuildCarsEntities();
        }

        public List<Role> GetAll()
        {
            var query = from m in context.Roles
                        select m;

            return query.ToList();
        }
    }
}
