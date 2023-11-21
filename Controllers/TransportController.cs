using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Services;

namespace WebApplication3.Controllers;

public class TransportController : Controller
{
    private readonly VehicleService _vehicleService;

    public TransportController(VehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }
    
    

    [Authorize]
    public IActionResult Vehicles()
    {
        var vehicles = _vehicleService.GetAllVehicles();
        return View(vehicles);
    }
}