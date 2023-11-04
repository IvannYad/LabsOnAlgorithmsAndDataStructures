using Laba.DataStructures;
using Microsoft.AspNetCore.Mvc;

namespace Laba.Controllers
{
    public class Lab8Controller : Controller
    {
        public IActionResult Index()
        {
            Tree tree = new();
            tree.Add(12);
            tree.Add(5);
            tree.Add(123);
            tree.Add(7); 
            tree.Add(-1);
            var a = tree.GetTraversing();
            return View();
        }
    }
}
