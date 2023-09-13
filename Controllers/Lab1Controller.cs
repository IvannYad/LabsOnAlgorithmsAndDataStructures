using Laba.Models;
using Laba.Services.Interfaces;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Laba.Controllers
{
    public class Lab1Controller : Controller
    {
        private readonly ISortingServiceLab1 _sortingServiceLab1;
        private readonly IPrepareCollectionService<string, string[]> _prepareCollectionService;

        public Lab1Controller(ISortingServiceLab1 sortingServiceLab1, IPrepareCollectionService<string, string[]> prepareCollectionService)
        {
            _sortingServiceLab1 = sortingServiceLab1;
            _prepareCollectionService = prepareCollectionService;
        }
        public IActionResult Index()
        {
            return View(new Lab1VM());
        }

        [HttpPost]
        public IActionResult Index(Lab1VM laba1VM, string customTaskChecked = "off")
        {
            
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                laba1VM.Array = _prepareCollectionService.GetCollectionFromString(laba1VM.ArrayString);
                laba1VM.SortingAlgorithmStepsResult = _sortingServiceLab1.Sort(ref laba1VM.Array, customTaskChecked is "on");
                stopwatch.Stop();

                laba1VM.TimeToSortInMiliseconds = (int)stopwatch.Elapsed.Microseconds;
                laba1VM.ComparesCount = _sortingServiceLab1.ComparesCount;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Array", "Invalid array input");
            }
            finally
            {
                if (stopwatch.IsRunning)
                    stopwatch.Stop();
            }

            return View(laba1VM);
        }
    }
}
