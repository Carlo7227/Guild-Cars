using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Queries;

namespace GuildCars.Data.Repositories
{
    public class VehicleRepoEF : IVehicleRepository
    {
        GuildCarsEntities context;

        public VehicleRepoEF()
        {
            context = new GuildCarsEntities();
        }

        public void CreateVehicle(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
            context.SaveChanges();
        }

        public void DeleteVehicle(int id)
        {
            Vehicle car = context.Vehicles.Find(id);
            if (car != null)
                context.Vehicles.Remove(context.Vehicles.Find(id));
            context.SaveChanges();
        }

        public IEnumerable<VehicleInventoryDetail> GetVehicleInventory()
        {
            var query = from x in context.Vehicles
                        group x by new { x.Year, x.Model.Make.MakeType, x.Model.Model1, x.IsNew }

                            into grp
                        select new VehicleInventoryDetail
                        {
                            IsNew = grp.Key.IsNew == 1 ? true : false,
                            Year = grp.Key.Year,
                            Model = grp.Key.Model1,
                            Make = grp.Key.MakeType,
                            StockValue = grp.Sum(t => t.SalesPrice),
                            Count = grp.Count()
                        };

            return query.ToList();
        }

        public List<Vehicle> GetAll()
        {
            var query = from m in context.Vehicles
                        select m;

            return query.ToList();
        }

        public IEnumerable<Vehicle> GetFeaturedVehicles()
        {
            var query = context.Vehicles.Where(v => v.IsFeatured == true);
            return query;
        }

        public Vehicle GetVehicle(int VehicleID)
        {
            return context.Vehicles.FirstOrDefault(v => v.VehicleID == VehicleID);
        }

        public IEnumerable<Vehicle> SearchNewVehicles(VehicleSearchParameters parameters)
        {
            IQueryable<Vehicle> query = context.Vehicles;

            query = query.Where(v => v.Model.Make.MakeType.Contains(parameters.Text) ||
                v.Year.ToString().Contains(parameters.Text) ||
                v.Model.Model1.Contains(parameters.Text) &&
                (v.SalesPrice < parameters.MaxPrice && v.SalesPrice > parameters.MinPrice) &&
                (v.Year < parameters.MaxYear && v.Year > parameters.MinYear));

            return query.ToList();
        }

        public IEnumerable<Vehicle> SearchUsedVehicles(VehicleSearchParameters parameters)
        {
            IQueryable<Vehicle> query = context.Vehicles.Where(q => q.IsNew == 0);

            query = query.Where(v => v.Model.Make.MakeType.Contains(parameters.Text) ||
                v.Year.ToString().Contains(parameters.Text) ||
                v.Model.Model1.Contains(parameters.Text) &&
                (v.SalesPrice < parameters.MaxPrice && v.SalesPrice > parameters.MinPrice) &&
                (v.Year < parameters.MaxYear && v.Year > parameters.MinYear));

            return query.ToList();
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            context.Entry(vehicle).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
