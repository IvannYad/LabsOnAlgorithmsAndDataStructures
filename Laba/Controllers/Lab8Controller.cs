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
            _tree.Add(1);
            _tree.Add(12);
            _tree.Add(-4); 
            _tree.Add(11);
            return View();
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
                return Json(new int[2] { 1, 2});
            }
        }
        #endregion
    }
}
