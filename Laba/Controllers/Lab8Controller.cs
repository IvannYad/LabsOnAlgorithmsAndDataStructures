using Laba.DataStructures;
using Laba.DataStructures.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Laba.Controllers
{
    public class Lab8Controller : Controller
    {
        private readonly ITree _tree;

        public Lab8Controller(ITree tree)
        {
            _tree = tree;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddItem(double valueToAdd)
        {
            try
            {
                _tree.Add(valueToAdd);
            }
            catch (ArgumentException ex)
            {
                TempData["error"] = ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult IfExists(double valueToCheck)
        {
            try
            {
                if (_tree.IfExists(valueToCheck))
                    TempData["success"] = "Value is  in tree";
                else
                    TempData["error"] = "Value is not in tree";
            }
            catch (NullReferenceException ex)
            {
                TempData["error"] = ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        #region API_Calls
        public IActionResult GetPackedArray()
        {
            try
            {
                var jsonObject = _tree.GetPackedArray();
                return Json(jsonObject);
            }
            catch (NullReferenceException)
            {
                return Json(new double[0]);
            }
        }

        public IActionResult Traverse()
        {
            try
            {
                var jsonObject = _tree.GetTraversing();
                return Json(string.Join(" -> ", jsonObject.Select(p => $"<b>{p}</b>")));
            }
            catch (NullReferenceException)
            {
                return Json(new double[0]);
            }
        }
        #endregion
    }
}
