using GuildCars.Data.Interfaces;
using GuildCars.Models.Queries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repositories.EF
{

    public class SalesRepo : ISalesRepo
    {
        GuildCarsEntities context;

        public SalesRepo()
        {
            context = new GuildCarsEntities();
        }

        public void CreateSale(Sale sale)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> GetAllSales()
        {
            var query = from m in context.Sales
                        select m;

            return query.ToList();
        }

        public EnterSalesInfoDisplay GetSalesInfoPage(Sale sale)
        {
            EnterSalesInfoDisplay display = new EnterSalesInfoDisplay();
            display.NewSale = new Sale();
            display.States = context.States.ToList();
            display.PurchaseTypes = context.PurchaseTypes.ToList();
            return display;
        }
    }
}
