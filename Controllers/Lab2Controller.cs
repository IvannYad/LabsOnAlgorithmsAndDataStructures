using Laba.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Laba.Controllers
{
    public class Lab2Controller : Controller
    {
        private readonly ISortingServiceLab2 _sortingServiceLab2;

        public Lab2Controller(ISortingServiceLab2 sortingServiceLab2)
        {
            _sortingServiceLab2 = sortingServiceLab2;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
