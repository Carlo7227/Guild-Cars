using GuildCars.Data.Factories;
using GuildCars.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = VehicleRepoFactory.GetRepository().GetFeaturedVehicles();
            return View(model);
        }
        public ActionResult NewInventory()
        {
            return View();
        }
        public ActionResult UsedInventory()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Specials()
        {
            var model = SpecialRepoFactory.GetRepository().GetAll();
            return View(model);
        }

        //public ActionResult Details(int id)
        //{
        //    var repo = VehicleRepoFactory.GetRepository();
        //    var model = repo.GetVehicle(id);

        //    return View(model);
        //}
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = VehicleRepoFactory.GetRepository().GetVehicle(id);

            return View(model);
        }
    }
}
