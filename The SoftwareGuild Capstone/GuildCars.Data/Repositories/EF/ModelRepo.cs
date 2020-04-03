using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repositories.EF
{
    public class ModelRepo : IModelRepo
    {
        GuildCarsEntities context;

        public ModelRepo()
        {
            context = new GuildCarsEntities();
        }

        public IEnumerable<Model> GetAllModels()
        {
            var query = from m in context.Models
                        select m;

            return query.ToList();
        }
    }
}
