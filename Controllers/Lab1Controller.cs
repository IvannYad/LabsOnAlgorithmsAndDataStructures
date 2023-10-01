using Laba.Models.VM;
using Laba.Services.Interfaces;
using Laba.Services.Interfaces.InterfacesLab1;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Laba.Controllers
{
    public class Lab1Controller : Controller
    {
        private readonly ICustomSortingService1 _sortingServiceLab1;
        private readonly IPrepareCollectionService<string, string[]> _prepareCollectionService;

        public Lab1Controller(ICustomSortingService1 sortingServiceLab1, IPrepareCollectionService<string, string[]> prepareCollectionService)
        {
            _sortingServiceLab1 = sortingServiceLab1;
            _prepareCollectionService = prepareCollectionService;
        }
        public IActionResult Index()
        {
            return View(new Lab1VM());
        }

        [HttpPost]
        public IActionResult Index(Lab1VM laba1VM)
        {
            
            try
            {
                laba1VM.Array = _prepareCollectionService.GetCollectionFromString(laba1VM.ArrayString);
                laba1VM.TimeToSortInTicks = _sortingServiceLab1.Sort(ref laba1VM.Array);
                laba1VM.SortingAlgorithmStepsResult = _sortingServiceLab1.Steps;
                laba1VM.ComparesCount = _sortingServiceLab1.ComparesCount;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Array", "Invalid array input");
            }
            
            return View(laba1VM);
        }
    }
}
