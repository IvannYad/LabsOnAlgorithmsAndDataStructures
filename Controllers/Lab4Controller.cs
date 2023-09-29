﻿using Laba.Models.VM;
using Laba.Services.Interfaces.InterfacesLab3;
using Laba.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Laba.Services.Interfaces.InterfacesLab4;

namespace Laba.Controllers
{
    public class Lab4Controller : Controller
    {
        private readonly ICustomSortingService4 _customSortingService4;
        private readonly IPrepareCollectionService<string, int[]> _prepareCollectionService;

        public Lab4Controller(ICustomSortingService4 customSortingService4, IPrepareCollectionService<string, int[]> prepareCollectionService)
        {
            _customSortingService4 = customSortingService4;
            _prepareCollectionService = prepareCollectionService;
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
                var tempArray = lab4VM.Array.ToArray();
                lab4VM.TimeToSortInMiliseconds = _customSortingService4.Sort(ref tempArray);
                lab4VM.SortingAlgorithmStepsResult = _customSortingService4.Steps;
                lab4VM.ComparesCount = _customSortingService4.ComparesCount;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ArrayString", "Invalid array input");
            }

            return View(lab4VM);
        }
    }
}
