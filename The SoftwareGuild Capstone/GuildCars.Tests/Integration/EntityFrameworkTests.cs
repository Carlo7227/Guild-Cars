using GuildCars.Data;
using GuildCars.Data.Repositories;
using GuildCars.Data.Repositories.EF;
using GuildCars.Models.Queries;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Tests.Integration
{
    //[TestFixture]
    //public class EntityFrameworkTests
    //{
    //    [Test]
    //    public void CanLoadVehicles()
    //    {
    //        var repo = new VehicleRepoEF();
    //        var cars = repo.GetAll();

    //        Assert.AreEqual(4, cars.Count);
    //        Assert.AreEqual(78000, cars[0].SalesPrice);
    //        Assert.AreEqual(20000, cars[1].SalesPrice);
    //    }
    //    [Test]
    //    public void CanLoadColors()
    //    {
    //        var repo = new ColorsRepo();
    //        var color = repo.GetAll();

    //        Assert.AreEqual(5, color.Count);
    //        Assert.AreEqual("Blue", color[1].ColorName);
    //    }
    //    [Test]
    //    public void CanLoadMakes()
    //    {
    //        var repo = new MakeRepo();
    //        var make = repo.GetAll();

    //        Assert.AreEqual(3, make.Count);
    //    }
    //    [Test]
    //    public void CanLoadModels()
    //    {
    //        var repo = new ModelRepo();
    //        var model = repo.GetAll();

    //        Assert.AreEqual(3, model.Count);
    //    }
    //    [Test]
    //    public void CanLoadBodyTypes()
    //    {
    //        var repo = new BodyTypeRepo();
    //        var type = repo.GetAll();

    //        Assert.AreEqual(3, type.Count);
    //    }
    //    [Test]
    //    public void CanLoadSpecials()
    //    {
    //        var repo = new SpecialsRepo();
    //        var special = repo.GetAll();

    //        Assert.AreEqual(3, special.Count);
    //    }

    //    [Test]
    //    public void CanSearchNewVehicles()
    //    {
    //        //var repo = new VehicleRepoEF();

    //        ////var found = repo.SearchNewVehicles(new VehicleSearchParameters { Text = "Ford", Text = "Focus", Text = 2015.ToString() });

    //        //Assert.AreEqual(found.Count(), 2);
    //    }
    }
}
