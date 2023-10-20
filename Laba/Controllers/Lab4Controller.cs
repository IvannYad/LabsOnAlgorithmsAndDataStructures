using Laba.Models.VM;
using Laba.Services.Interfaces.InterfacesLab3;
using Laba.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Laba.Services.Interfaces.InterfacesLab4;
using Laba.Services.ServicesLab4;

namespace Laba.Controllers
{
    public class Lab4Controller : Controller
    {
        private readonly ICustomSortingService4 _customSortingService4;
        private readonly IPrepareCollectionService<string, (string, long)[]> _prepareCollectionService;

        public Lab4Controller(ICustomSortingService4 customSortingService4)
        {
            _customSortingService4 = customSortingService4;
            _prepareCollectionService = new PrepareCollectionServiceLab4();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new Lab4VM());
        }

        [HttpPost]
        public IActionResult Index(Lab4VM lab4VM)
        {
            try
            {
                lab4VM.Array = _prepareCollectionService.GetCollectionFromString(lab4VM.ArrayString);
                lab4VM.Average = lab4VM.Array.Average(i => i.Item2);
                lab4VM.Array = lab4VM.Array.Where(i => i.Item2 <= lab4VM.Average).ToArray();

                var tempArray = lab4VM.Array.ToArray();
                lab4VM.TimeToSortInTicks = _customSortingService4.Sort(ref tempArray);
                lab4VM.SortingAlgorithmStepsResult = _customSortingService4.Steps;
                lab4VM.ComparesCount = _customSortingService4.ComparesCount;
            }
            catch (Exception)
            {
                ModelState.AddModelError("ArrayString", "Invalid array input");
            }

            return View(lab4VM);
        }
    }
}
