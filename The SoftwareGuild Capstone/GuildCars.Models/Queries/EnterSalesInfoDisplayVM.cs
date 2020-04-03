using GuildCars.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class EnterSalesInfoDisplay
    {
        public Sale NewSale { get; set; }
        public List<PurchaseType> PurchaseTypes { get; set; }
        public List<State> States { get; set; }
        public List<Vehicle> Vehicle { get; set; }
        public int StateID { get; set; }
        public int PurchaseTypeID { get; set; }
    }
}
