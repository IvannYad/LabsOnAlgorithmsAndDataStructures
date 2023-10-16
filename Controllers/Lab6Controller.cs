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
using System.Runtime.InteropServices;

namespace Laba.Controllers
{
    public class Lab6Controller : Controller
    {
        private readonly IOrdinarySortingService1 _ordinarySortingService1;
        private readonly IOrdinarySortingService2 _ordinarySortingService2;
        private readonly IOrdinarySortingService3 _ordinarySortingService3;
        private readonly IOrdinarySortingService4 _ordinarySortingService4;
        private readonly IOrdinarySortingService5 _ordinarySortingService5;
        private readonly IPrepareCollectionService<string, int[]> _prepareCollectionService;

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
            _prepareCollectionService = new PrepareCollectionServiceLab6();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new Lab6VM());
        }

        [HttpPost]
        public IActionResult Index(Lab6VM lab6VM)
        {
            try
            {
                lab6VM.NumberOfElements = _prepareCollectionService.GetCollectionFromString(lab6VM.NumberOfElementsString);
                lab6VM.SelectionSortTimes = new double[lab6VM.NumberOfElements.Length];
                lab6VM.ShellSortTimes = new double[lab6VM.NumberOfElements.Length];
                lab6VM.QuickSortTimes = new double[lab6VM.NumberOfElements.Length];
                lab6VM.MergeSortTimes = new double[lab6VM.NumberOfElements.Length];
                lab6VM.CountSortTimes = new double[lab6VM.NumberOfElements.Length];
                var rand = new Random();
                var arrayToPass = new int[0];

                for (int i = 0; i < lab6VM.NumberOfElements.Length; i++)
                {
                    _ordinarySortingService1.PopulateBounds(lab6VM.LowerBound, lab6VM.UpperBound, lab6VM.NumberOfElements[i]);
                    _ordinarySortingService2.PopulateBounds(lab6VM.LowerBound, lab6VM.UpperBound, lab6VM.NumberOfElements[i]);
                    _ordinarySortingService3.PopulateBounds(lab6VM.LowerBound, lab6VM.UpperBound, lab6VM.NumberOfElements[i]);
                    _ordinarySortingService4.PopulateBounds(lab6VM.LowerBound, lab6VM.UpperBound, lab6VM.NumberOfElements[i]);
                    _ordinarySortingService5.PopulateBounds(lab6VM.LowerBound, lab6VM.UpperBound, lab6VM.NumberOfElements[i]);

                    lab6VM.SelectionSortTimes[i] = _ordinarySortingService1.Sort(ref arrayToPass);
                    lab6VM.ShellSortTimes[i] = _ordinarySortingService2.Sort(ref arrayToPass);
                    lab6VM.QuickSortTimes[i] = _ordinarySortingService3.Sort(ref arrayToPass);
                    lab6VM.MergeSortTimes[i] = _ordinarySortingService4.Sort(ref arrayToPass);
                    lab6VM.CountSortTimes[i] = _ordinarySortingService5.Sort(ref arrayToPass);
                }

            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("NumberOfElementsString", ex.Message);
            }
            catch (Exception)
            {
                ModelState.AddModelError("NumberOfElementsString", "Invalid array input");
            }

            return View(lab6VM);
        }
    }
}
