using GuildCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface ISpecialsRepo
    {
        List<Special> GetAll();
        void CreateSpecial(Special special);
    }
}
