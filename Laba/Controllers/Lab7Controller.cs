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
            try
            {
                LabVM.DequeueResult = LabVM.Queue.Dequeue();
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(nameof(LabVM.DequeueResult), ex.Message);
            }
            catch
            {
                ModelState.AddModelError(nameof(LabVM.DequeueResult), "Error");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Peek()
        {
            try
            {
                LabVM.PeekResult = LabVM.Queue.Peek();
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(nameof(LabVM.PeekResult), ex.Message);
            }
            catch
            {
                ModelState.AddModelError(nameof(LabVM.PeekResult), "Error");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult FindMin()
        {
            try
            {
                LabVM.MinElement = LabVM.Queue.MinElement();
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(nameof(LabVM.MinElement), ex.Message);
            }
            catch
            {
                ModelState.AddModelError(nameof(LabVM.MinElement), "Error");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult FindMax()
        {
            try
            {
                LabVM.MaxElement = LabVM.Queue.MaxElement();
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(nameof(LabVM.MaxElement), ex.Message);
            }
            catch
            {
                ModelState.AddModelError(nameof(LabVM.MaxElement), "Error");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult FindIndex(Lab7VM lab7VM)
        {
            try
            {
                LabVM.Index = LabVM.Queue.IndexOf((double)lab7VM.ElementInput);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(nameof(LabVM.ElementInput), ex.Message);
            }
            catch
            {
                ModelState.AddModelError(nameof(LabVM.ElementInput), "Invalid input");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult FindElement(Lab7VM lab7VM)
        {
            try
            {
                LabVM.ElementByIndex = LabVM.Queue.ReturnByIndex((int)lab7VM.IndexInput);
            }
            catch (IndexOutOfRangeException ex)
            {
                ModelState.AddModelError(nameof(LabVM.IndexInput), ex.Message);
            }
            catch
            {
                ModelState.AddModelError(nameof(LabVM.IndexInput), "Invalid input");
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
