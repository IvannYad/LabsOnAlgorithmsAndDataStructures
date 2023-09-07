using Laba.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Laba.Controllers
{
    public class Laba1Controller : Controller
    {
        public IActionResult Index()
        {
            var labaVm = new Laba1VM()
            {
                Types = new[]
                {
                    new SelectListItem { Text = "int", Value = "int" },
                    new SelectListItem { Text = "double", Value = "double" },
                    new SelectListItem { Text = "string", Value = "string" },
                }
            };
            return View(labaVm);
        }
    }
}
