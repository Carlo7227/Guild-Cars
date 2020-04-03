using GuildCars.Data;
using GuildCars.Data.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index(Sale sale)
        {
            var model = SalesRepoFactory.GetRepository().GetSalesInfoPage(sale);
            return View(model);
        }
        // GET: Sales
        public ActionResult Sales()
        {
            return View();
        }
    }
}