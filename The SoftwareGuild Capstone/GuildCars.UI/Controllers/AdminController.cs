using GuildCars.Data;
using GuildCars.Data.Factories;
using GuildCars.Data.Repositories;
using GuildCars.UI.Models;
using GuildCars.UI.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Inventory()
        {
            var model = VehicleRepoFactory.GetRepository().GetVehicleInventory();
            return View(model);
        }
        [HttpGet]
        public ActionResult Add()
        {
            var model = new VehicleAddViewModel();

            var modelRepo = ModelRepoFactory.GetRepository();
            var bodyStyleRepo = BodyStyleRepoFactory.GetRepository();
            var colorRepo = ColorRepoFactory.GetRepository();
            var makeRepo = MakeRepoFactory.GetRepository();

            model.BodyTypes = new SelectList(bodyStyleRepo.GetAllBodyTypes(), "BodyStyleID", "Type");
            model.Colors = new SelectList(colorRepo.GetAllColors(), "ColorID", "ColorName");
            model.Models = new SelectList(modelRepo.GetAllModels(), "ModelsID", "Model1");
            model.Makes = new SelectList(makeRepo.GetAllMakes(), "MakeID", "MakeType");

            return View(model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Add(VehicleAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = VehicleRepoFactory.GetRepository();

                try
                {
                    //model.Vehicle.UserId = AuthorizeUtilities.GetUserId(this);

                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images");

                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        var filePath = Path.Combine(savepath, fileName + extension);

                        int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                            counter++;
                        }

                        model.ImageUpload.SaveAs(filePath);
                        model.Vehicle.ImageFileName = Path.GetFileName(filePath);
                    }

                    repo.CreateVehicle(model.Vehicle);

                    return RedirectToAction("Edit", new { id = model.Vehicle.VehicleID });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var modelRepo = ModelRepoFactory.GetRepository();
                var bodyStyleRepo = BodyStyleRepoFactory.GetRepository();
                var colorRepo = ColorRepoFactory.GetRepository();
                var makeRepo = MakeRepoFactory.GetRepository();

                model.BodyTypes = new SelectList(bodyStyleRepo.GetAllBodyTypes(), "BodyStyleID", "Type");
                model.Colors = new SelectList(colorRepo.GetAllColors(), "ColorID", "ColorName");
                model.Models = new SelectList(modelRepo.GetAllModels(), "ModelsID", "Model1");
                model.Makes = new SelectList(makeRepo.GetAllMakes(), "MakeID", "MakeType");

                return View(model);
            }
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            var model = new VehicleEditViewModel(); //make edit VM

            var modelRepo = ModelRepoFactory.GetRepository();
            var bodyStyleRepo = BodyStyleRepoFactory.GetRepository();
            var colorRepo = ColorRepoFactory.GetRepository();
            var makeRepo = MakeRepoFactory.GetRepository();
            var vehicleRepo = VehicleRepoFactory.GetRepository();

            model.BodyTypes = new SelectList(bodyStyleRepo.GetAllBodyTypes(), "BodyStyleID", "Type");
            model.Colors = new SelectList(colorRepo.GetAllColors(), "ColorID", "ColorName");
            model.Models = new SelectList(modelRepo.GetAllModels(), "ModelsID", "Model1");
            model.Makes = new SelectList(makeRepo.GetAllMakes(), "MakeID", "MakeType");
            model.Vehicle = vehicleRepo.GetVehicle(id);

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(VehicleEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = VehicleRepoFactory.GetRepository();

                try
                {
                    //model.Vehicle.UserId = AuthorizeUtilities.GetUserId(this);
                    var oldListing = repo.GetVehicle(model.Vehicle.VehicleID);

                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images");

                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        var filePath = Path.Combine(savepath, fileName + extension);

                        int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                            counter++;
                        }

                        model.ImageUpload.SaveAs(filePath);
                        model.Vehicle.ImageFileName = Path.GetFileName(filePath);

                        var oldPath = Path.Combine(savepath, oldListing.ImageFileName);
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    else
                    {
                        // they did not replace the old file, so keep the old file name
                        model.Vehicle.ImageFileName = oldListing.ImageFileName;
                    }

                    repo.UpdateVehicle(model.Vehicle);

                    return RedirectToAction("Edit", new { id = model.Vehicle.VehicleID });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var modelRepo = ModelRepoFactory.GetRepository();
                var bodyStyleRepo = BodyStyleRepoFactory.GetRepository();
                var colorRepo = ColorRepoFactory.GetRepository();
                var makeRepo = MakeRepoFactory.GetRepository();

                model.BodyTypes = new SelectList(bodyStyleRepo.GetAllBodyTypes(), "BodyStyleID", "Type");
                model.Colors = new SelectList(colorRepo.GetAllColors(), "ColorID", "ColorName");
                model.Models = new SelectList(modelRepo.GetAllModels(), "ModelsID", "Model1");
                model.Makes = new SelectList(makeRepo.GetAllMakes(), "MakeID", "MakeType");

                return View(model);
            }
        }
    }
}