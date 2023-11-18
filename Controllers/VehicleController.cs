using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;

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
    }
}