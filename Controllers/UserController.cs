using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

[Authorize(Roles = "User")]
public class UserController : Controller
{
    
    public IActionResult UserPage()
    {
        // Ваш код для страницы пользователя
        return View();
    }

    // Другие методы контроллера
}

