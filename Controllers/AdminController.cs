using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Services;

namespace WebApplication3.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly IMaintenanceService _maintenanceService;
    
    public AdminController(IMaintenanceService maintenanceService)
    {
        _maintenanceService = maintenanceService;
    }
    
    public IActionResult AdminPage()
    {
        // Ваш код для страницы админа
        return View();
    }
    
    public IActionResult RequestsList()
    {
        var maintenanceRequests = _maintenanceService.GetMaintenanceRequests();

        return View("RequestsList", maintenanceRequests);
    }

}
    