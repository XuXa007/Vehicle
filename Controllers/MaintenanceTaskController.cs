using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;

namespace WebApplication3.Controllers;

public class MaintenanceTaskController : Controller
{
    private readonly DBContext _dbContext;
    
    public MaintenanceTaskController(DBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult MaintenanceTaskList()
    {
        var tasks = _dbContext.MaintenanceTasks.Include(t => t.Vehicle).ToList();
        return View(tasks);
    }
}