using Microsoft.AspNetCore.Mvc;

namespace MyCar.MVC.Controllers
{
    public class CarController : Controller
    {
        // GET
        public IActionResult Create()
        {
            return View();
        }
    }
}