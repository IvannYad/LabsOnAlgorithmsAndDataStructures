using Laba.Models.VM;
using Laba.Services.Interfaces.InterfacesLab3;
using Laba.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Laba.Services.Interfaces.InterfacesLab4;
using Laba.Services.ServicesLab4;
using Laba.Services.Interfaces.InterfacesLab5;
using Laba.Services.ServicesLab5;
using Laba.Services.Interfaces.InterfacesLab1;
using Laba.Services.Interfaces.InterfacesLab2;

namespace Laba.Controllers
{
    public class Lab6Controller : Controller
    {
        private readonly IOrdinarySortingService1 _ordinarySortingService1;
        private readonly IOrdinarySortingService2 _ordinarySortingService2;
        private readonly IOrdinarySortingService3 _ordinarySortingService3;
        private readonly IOrdinarySortingService4 _ordinarySortingService4;
        private readonly IOrdinarySortingService5 _ordinarySortingService5;

        public Lab6Controller(IOrdinarySortingService1 ordinarySortingService1,
            IOrdinarySortingService2 ordinarySortingService2, 
            IOrdinarySortingService3 ordinarySortingService3, 
            IOrdinarySortingService4 ordinarySortingService4, 
            IOrdinarySortingService5 ordinarySortingService5)
        {
            _ordinarySortingService1 = ordinarySortingService1;
            _ordinarySortingService2 = ordinarySortingService2;
            _ordinarySortingService3 = ordinarySortingService3;
            _ordinarySortingService4 = ordinarySortingService4;
            _ordinarySortingService5 = ordinarySortingService5;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new Lab6VM());
        }

        [HttpPost]
        public IActionResult Index(Lab5VM lab5VM)
        {
            try
            {
                lab5VM.Array = _prepareCollectionService.GetCollectionFromString(lab5VM.ArrayString);

                var tempArray = lab5VM.Array.ToArray();
                lab5VM.TimeToSortInTicks = _customSortingService5.Sort(ref tempArray);
                lab5VM.SortingAlgorithmStepsResult = _customSortingService5.Steps;
                lab5VM.ComparesCount = _customSortingService5.ComparesCount;
                lab5VM.ArrayWithIndexes = _customSortingService5.IndexesArray;
                lab5VM.ArrayWithAddedIndexes = _customSortingService5.AddedIndexesArray;

            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("ArrayString", ex.Message);
            }
            catch (Exception)
            {
                ModelState.AddModelError("ArrayString", "Invalid array input");
            }

            return View(lab5VM);
        }

    }
}
