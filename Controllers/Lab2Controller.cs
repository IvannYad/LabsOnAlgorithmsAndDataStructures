using Laba.Models.VM;
using Laba.Services.Interfaces;
using Laba.Services.Interfaces.InterfacesLab2;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Laba.Controllers
{
    public class Lab2Controller : Controller
    {
        private readonly ICustomSortingService2 _sortingServiceLab2;
        private readonly IPrepareCollectionService<string[], double[][]> _prepareCollectionService;

        public Lab2Controller(ICustomSortingService2 sortingServiceLab2, IPrepareCollectionService<string[], double[][]> prepareCollectionService)
        {
            _sortingServiceLab2 = sortingServiceLab2;
            _prepareCollectionService = prepareCollectionService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new Lab2VM());
        }

        [HttpPost]
        public IActionResult Index(Lab2VM laba2VM)
        {

            try
            {
                laba2VM.Matrix = _prepareCollectionService
                                        .GetCollectionFromString(laba2VM.MatrixString.Split("\r\n", StringSplitOptions.RemoveEmptyEntries));
                if (!laba2VM.Matrix.All(m => m.Length == laba2VM.Matrix[0].Length))
                {
                    ModelState.AddModelError("MatrixString", "Matrix must have all rows the same length");
                    return View(laba2VM);
                }

                laba2VM.TimeToSortInMiliseconds = _sortingServiceLab2.Sort(ref laba2VM.Matrix);
                laba2VM.SortingAlgorithmStepsResult = _sortingServiceLab2.Steps;
                laba2VM.ComparesCount = _sortingServiceLab2.ComparesCount;
                laba2VM.SwipesCount = _sortingServiceLab2.SwipesCount;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("MatrixString", "Invalid matrix input");
            }
            
            return View(laba2VM);
        }
    }
}
