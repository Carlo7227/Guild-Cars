using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface ISalesRepo
    {
        IEnumerable<Sale> GetAllSales();
        void CreateSale(Sale Sale);
        EnterSalesInfoDisplay GetSalesInfoPage(Sale sale);

    }
}
