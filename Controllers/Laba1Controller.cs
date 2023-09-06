using Microsoft.AspNetCore.Mvc;

namespace Laba.Controllers
{
    public class Laba1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
