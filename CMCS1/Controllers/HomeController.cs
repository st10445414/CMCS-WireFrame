using Microsoft.AspNetCore.Mvc;

namespace CMCS1.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}
