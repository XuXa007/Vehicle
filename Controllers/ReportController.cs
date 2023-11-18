using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication3.Data;

namespace WebApplication3.Controllers;

public class ReportController : Controller
{
    private readonly DBContext _dbContext;
    
    public ReportController(DBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult ReportList()
    {
        var reports = _dbContext.Reports.Include(r => r.User).ToList();
        return View(reports);
        
    }
}