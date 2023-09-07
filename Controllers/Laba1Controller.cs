using Laba.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Laba.Controllers
{
    public class Laba1Controller : Controller
    {
        public IActionResult Index()
        {
            return View(new Laba1VM());
        }

        [HttpPost]
        public IActionResult Index(Laba1VM laba1VM, string customTaskChecked = "off")
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                laba1VM.Array = laba1VM.ArrayString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                laba1VM.SortingAlgorithmStepsResult = Sort(ref laba1VM.Array, customTaskChecked is "on");
                stopwatch.Stop();
                laba1VM.TimeToSortInMiliseconds = (int)stopwatch.Elapsed.Microseconds;
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

        public IEnumerable<SortingAlgorithResultModel<string>> Sort(ref string[] array, bool customTaskChecked)
        {
            var result = new List<SortingAlgorithResultModel<string>>();
            string[] tempArray;
            if (customTaskChecked)
                array = array.Where(p => p.Length <= 8).ToArray();
                
            tempArray = (string[])array.Clone();
            for (int i = 0; i < tempArray.Length - 1; i++)
            {
                var minIndex = FindMinIndex(tempArray[i..]) + i;
                Swap(ref tempArray[i], ref tempArray[minIndex]);
                result.Add(new SortingAlgorithResultModel<string>() { Index1ToSwap = i, Index2ToSwap = minIndex, Array = (string[])tempArray.Clone(), LastIndexSorted = i - 1 });
            }

            return result;
        }

        private int FindMinIndex(string[] array)
        {
            string min = array[0];
            int kMin = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].CompareTo(min) == -1)
                {
                    min = array[i];
                    kMin = i;
                }
            }

            return kMin;
        }

        private void Swap(ref string a, ref string b)
        {
            string t = a;
            a = b;
            b = t;
        }
    }
}
