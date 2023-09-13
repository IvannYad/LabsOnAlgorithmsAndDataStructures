using Laba.Models;
using Laba.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Laba.Controllers
{
    public class Lab2Controller : Controller
    {
        private readonly ISortingServiceLab2 _sortingServiceLab2;
        private readonly IPrepareCollectionService<string[], double[][]> _prepareCollectionService;

        public Lab2Controller(ISortingServiceLab2 sortingServiceLab2, IPrepareCollectionService<string[], double[][]> prepareCollectionService)
        {
            _sortingServiceLab2 = sortingServiceLab2;
            _prepareCollectionService = prepareCollectionService;
        }

        public IActionResult Index()
        {
            return View(new Lab2VM());
        }

        [HttpPost]
        public IActionResult Index(Lab2VM laba2VM, string customTaskChecked = "off")
        {

            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                laba2VM.MatrixBefore = _prepareCollectionService
                                        .GetCollectionFromString(laba2VM.MatrixString.Split("\r\n", StringSplitOptions.RemoveEmptyEntries));
                laba2VM.SortingAlgorithmStepsResult = _sortingServiceLab2.Sort(ref laba2VM.MatrixBefore, customTaskChecked is "on");
                stopwatch.Stop();

                laba2VM.TimeToSortInMiliseconds = (int)stopwatch.Elapsed.Microseconds;
                laba2VM.ComparesCount = _sortingServiceLab2.ComparesCount;
                laba2VM.SwipesCount = _sortingServiceLab2.SwipesCount;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Matrix", "Invalid matrix input");
            }
            finally
            {
                if (stopwatch.IsRunning)
                    stopwatch.Stop();
            }

            return View(laba2VM);
        }
    }
}
