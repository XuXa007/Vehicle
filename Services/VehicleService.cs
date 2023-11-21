using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Services
{
    public class VehicleService
    {
        private readonly DBContext _dbContext;

        public VehicleService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _dbContext.Vehicles.ToList();
        }

        public Vehicle GetVehicleById(int id)
        {
            return _dbContext.Vehicles.Find(id);
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _dbContext.Vehicles.Add(vehicle);
            _dbContext.SaveChanges();
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            _dbContext.Entry(vehicle).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteVehicle(int id)
        {
            var vehicle = _dbContext.Vehicles.Find(id);
            if (vehicle != null)
            {
                _dbContext.Vehicles.Remove(vehicle);
                _dbContext.SaveChanges();
            }
        }
    }
}