﻿using Laba.DataStructures;
using Laba.DataStructures.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Microsoft.JSInterop;

namespace Laba.Controllers
{
    public class Lab8Controller : Controller
    {
        private readonly ITree _tree;
        private readonly IJSRuntime _js;

        public Lab8Controller(ITree tree, IJSRuntime js)
        {
            _tree = tree;
            _js = js;
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
        [HttpGet]
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

        [HttpGet]
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

        [HttpGet]
        public IActionResult FindParentAndChildren(double element)
        {
            try
            {
                var result = _tree.GetParentAndChildren(element);
                if (result is not null)
                    return Json($"<b>Parent: </b>{result.Value.parent}<br />" +
                        $"<b>Children: </b> {string.Join(',', result.Value.children)}");
            }
            catch (ArgumentException ex)
            {
                TempData["error"] = ex.Message;
            }

            return Json(new double[0]);
        }

        [HttpGet]
        public IActionResult GetSecond()
        {
            double result = 0;
            try
            {
                var jsonObject = _tree.GetTraversing();
                if (jsonObject is not null)
                {
                    jsonObject = jsonObject.Where(p => (int)p % 2 == 0).ToArray();
                    result =  jsonObject.Length < 2 ?
                        throw new InvalidOperationException("Cannot do this") :
                        jsonObject[^2];
                }
            }
            catch (NullReferenceException)
            {
                return Json(new double[0]);
            }
            catch (InvalidOperationException)
            {
                return Json(new double[0]);
            }

            return Json(result);
        }
        #endregion
    }
}
