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
using Laba.DataStructures;

namespace Laba.Controllers
{
    public class Lab7Controller : Controller
    {
        public Lab7VM LabVM { get; set; }
        public Lab7Controller(Lab7VM lab7VM)
        {
            LabVM = lab7VM;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(LabVM);
        }

        [HttpPost]
        public IActionResult Enqueue(Lab7VM lab7VM)
        {
            LabVM.Queue.Enqueue((int)lab7VM.PriorityToEnqueue, (double)lab7VM.ValueToEnqueue);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Dequeue()
        {
            LabVM.DequeueResult = LabVM.Queue.Dequeue();
            return RedirectToAction(nameof(Index));
        }

    }
}
