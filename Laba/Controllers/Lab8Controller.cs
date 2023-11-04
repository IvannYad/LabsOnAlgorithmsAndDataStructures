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

        public IActionResult AddItem(double value)
        {
            _tree.Add(value);
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
        #endregion
    }
}
