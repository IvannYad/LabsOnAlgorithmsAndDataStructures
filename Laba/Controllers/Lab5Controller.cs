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
    public class Lab5Controller : Controller
    {
        private readonly ICustomSortingService5 _customSortingService5;
        private readonly IPrepareCollectionService<string, int[]> _prepareCollectionService;

        public Lab5Controller(ICustomSortingService5 customSortingService5)
        {
            _customSortingService5 = customSortingService5;
            _prepareCollectionService = new PrepareCollectionServiceLab5();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new Lab5VM());
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
            catch(ArgumentException ex)
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
