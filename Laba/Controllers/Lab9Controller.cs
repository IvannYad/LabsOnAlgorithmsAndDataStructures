using Laba.DataStructures;
using Laba.DataStructures.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Microsoft.JSInterop;
using Laba.Services.ServicesLab9;

namespace Laba.Controllers
{
    public class Lab9Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        #region API_Calls

        public IActionResult GenerateArray(int n, [FromServices] ArrayHolder arrayHolder)
        {
            Random r = new Random();
            arrayHolder.Array = Enumerable.Range(1, n).Select(item => r.Next(0, 1000)).Order().ToArray();
            var colors = Enumerable.Range(1, n).Select(item => "blue").ToArray();

            return Json(new { data = arrayHolder.Array, colors = colors });
        }

        public IActionResult GenerateSteps(int value, int start, int end, [FromServices] ArrayHolder arrayHolder)
        {
            List<string[]> colorsArr = new List<string[]>();
            int numberOfComparison = 0;
            while (start <= end)
            {
                numberOfComparison++;
                int middle = (start + end) / 2;
                if(start == end && arrayHolder.Array[middle] != value)
                {
                    colorsArr.Add(Enumerable.Range(1, arrayHolder.Array.Length)
                        .Select((item, i) => i == middle ? "red" : "blue")
                        .ToArray());
                    break;
                }

                if (arrayHolder.Array[middle] == value)
                {
                    colorsArr.Add(Enumerable.Range(1, arrayHolder.Array.Length)
                        .Select((item, i) => i == middle ? "green" : "blue")
                        .ToArray());
                    break;
                }

                if (value < arrayHolder.Array[middle])
                    end = middle - 1;
                else
                    start = middle + 1;

                colorsArr.Add(Enumerable.Range(1, arrayHolder.Array.Length)
                                        .Select((item, i) => i == middle ? "red" : (i >= start && i <= end ? "orange" : "blue"))
                                        .ToArray());
            }

            return Json(new { data = arrayHolder.Array,  colorsArr = colorsArr.ToArray(), numComp = numberOfComparison});
        }

        #endregion
    }
}
