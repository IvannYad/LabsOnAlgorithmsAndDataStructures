using Laba.Models.VM;
using Laba.Services.Interfaces.InterfacesLab3;
using Laba.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Laba.Services.Interfaces.InterfacesLab4;
using Laba.Services.ServicesLab4;
using Laba.Services.Interfaces.InterfacesLab5;
using Laba.Services.ServicesLab5;


namespace Laba.Controllers
{
    public class Lab6Controller : Controller
    {
        

        [HttpGet]
        public IActionResult Index()
        {
            
            return View(new int[] { 150, 200, 300, 400, 500, 600, 700, 800, 900, 1000 });
        }

    }
}
