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

        public IActionResult CustomTaskEvaluating(int ArraySizeCustom, int valueToFindCustom)
        {
            using StreamWriter writer = new StreamWriter("../../Laba9/t.txt", false);
            Random r = new Random();
            var array = Enumerable.Range(1, ArraySizeCustom).Select(item => r.Next(-50, 50)).ToArray();
            writer.WriteLine($"Start array: [{string.Join(",", array)}]");
            writer.WriteLine($"Value to find: {valueToFindCustom}");
            // Find min and max.
            int min = array[0];
            int max = array[0];
            int indexMin = 0;
            int indexMax = 0;
            for (int i = 0; i < ArraySizeCustom; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                    indexMin = i;
                    continue;
                }

                if (array[i] > max)
                {
                    max = array[i];
                    indexMax = i;
                }

            }

            writer.WriteLine($"Min element: {min} at [{indexMin}] index");
            writer.WriteLine($"Max element: {max} at [{indexMax}] index");

            // Swap two elements after min.
            if (indexMin + 2 < array.Length)
            {
                int temp = array[indexMin + 1];
                array[indexMin + 1] = array[indexMin + 2];
                array[indexMin + 2] = temp;
            }

            // Find absolute sum of negative values.
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                    sum += Math.Abs(array[i]);
            }

            // Divide max element by absolute sum of negative elements.
            array[indexMax] /= sum;

            writer.WriteLine($"Array after metmorphosis: [{string.Join(",", array)}]");

            // Check if entered elemnt is in array.
            bool isInArray = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == valueToFindCustom)
                {
                    isInArray = true;
                    break;
                }
            }

            writer.WriteLine($"Is value to find in array: {isInArray}");
            return View(nameof(Index));
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
                if (start == end && arrayHolder.Array[middle] != value)
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

            return Json(new { data = arrayHolder.Array, colorsArr = colorsArr.ToArray(), numComp = numberOfComparison });
        }

        #endregion
    }
}
