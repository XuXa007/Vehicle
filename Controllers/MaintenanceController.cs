using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers;

public class MaintenanceController : Controller
{
    private readonly List<MaintenanceRequest> _maintenanceRequests = new List<MaintenanceRequest>();

    private readonly IMaintenanceService _maintenanceService;

    public MaintenanceController(IMaintenanceService maintenanceService)
    {
        _maintenanceService = maintenanceService;
    }
    public IActionResult Index()
    {
        return View(_maintenanceRequests);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(MaintenanceRequest model)
    {
        if (ModelState.IsValid)
        {
            model.RequestDate = DateTime.Now;
            model.IsCompleted = false;

            // Добавление нового запроса в список
            _maintenanceRequests.Add(model);

            return RedirectToAction("Index");
        }

        // В случае ошибок валидации возвращаем пользователя на форму
        return View(model);
    }
    
    public IActionResult RequestsList()
    {
        // Здесь может быть ваш код для получения списка запросов
        var maintenanceRequests = _maintenanceService.GetMaintenanceRequests(); // Замените на ваш сервис для работы с запросами

        return View(maintenanceRequests);
    }
}
