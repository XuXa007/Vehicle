using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class VehicleController : Controller
    {
        private readonly DBContext _dbContext;

        public VehicleController(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        

        public IActionResult VehicleList()
        {
            var vehicles = _dbContext.Vehicles.ToList();
            return View(vehicles);
        }
        
        
        
        public IActionResult Create()
        {
            var vehicle = new Vehicle();
            return View(vehicle);
        }
        
        [HttpPost]
        public IActionResult Create(Vehicle cVehicle)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Vehicles.Add(cVehicle);
                _dbContext.SaveChanges();
                return RedirectToAction("VehicleList");
            }

            return View(cVehicle);
        }
        
        public  IActionResult Edit(int id)
        {
            var vehicle =  _dbContext.Vehicles.FirstOrDefault(v => v.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }
        
        // GET: Vehicle/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = _dbContext.Vehicles.Include(v => v.MaintenanceTasks)
                .FirstOrDefault(v => v.Id == id);
            
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }
        
        // POST: Vehicle/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Make,Model,RegistrationNumber")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(vehicle);
                    _dbContext.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(VehicleList));
            }
            return View(vehicle);
        }
        
        private bool VehicleExists(int id)
        {
            return _dbContext.Vehicles.Any(e => e.Id == id);
        }
    }
}