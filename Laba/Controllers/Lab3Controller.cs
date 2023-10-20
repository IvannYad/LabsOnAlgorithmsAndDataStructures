using Laba.Models.VM;
using Laba.Services.Interfaces;
using Laba.Services.Interfaces.InterfacesLab3;
using Laba.Services.ServicesLab3;
using Microsoft.AspNetCore.Mvc;

namespace Laba.Controllers
{
    public class Lab3Controller : Controller
    {
        private readonly ICustomSortingService3 _customSortingService3;
        private readonly IPrepareCollectionService<string, int[]> _prepareCollectionService;

        public Lab3Controller(ICustomSortingService3 customSortingService3)
        {
            _customSortingService3 = customSortingService3;
            _prepareCollectionService = new PrepareCollectionServiceLab3();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new Lab3VM());
        }

        [HttpPost]
        public IActionResult Index(Lab3VM lab3VM)
        {
            try
            {
                lab3VM.Array = _prepareCollectionService.GetCollectionFromString(lab3VM.ArrayString);
                var tempArray = lab3VM.Array.ToArray();
                lab3VM.TimeToSortInTicks = _customSortingService3.Sort(ref tempArray);
                lab3VM.SortingAlgorithmStepsResult = _customSortingService3.Steps;
                lab3VM.ComparesCount = _customSortingService3.ComparesCount;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ArrayString", "Invalid array input");
            }

            return View(lab3VM);
        }
    }
}
