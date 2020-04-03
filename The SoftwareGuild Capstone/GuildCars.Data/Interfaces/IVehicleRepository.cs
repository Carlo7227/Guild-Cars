using GuildCars.Data;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetAll();
        IEnumerable<Vehicle> GetFeaturedVehicles();
        Vehicle GetVehicle(int id);
        void CreateVehicle(Vehicle vehicle);
        void DeleteVehicle(int id);
        void UpdateVehicle(Vehicle vehicle);
        IEnumerable<Vehicle> SearchNewVehicles(VehicleSearchParameters parameters);
        IEnumerable<Vehicle> SearchUsedVehicles(VehicleSearchParameters parameters);
        IEnumerable<VehicleInventoryDetail> GetVehicleInventory();

    }
}
