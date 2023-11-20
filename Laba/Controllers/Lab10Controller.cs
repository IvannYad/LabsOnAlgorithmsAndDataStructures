using Laba.DataStructures;
using Laba.DataStructures.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Microsoft.JSInterop;
using Laba.Services.ServicesLab9;
using System.Net;

namespace Laba.Controllers
{
    public class Lab10Controller : Controller
    {
        private string? _text1;
        private string? _text2;
        public IActionResult Index()
        {
            return View();
        }

        #region API_Calls

        public async Task<IActionResult> GenerateText(int paragraphsCount, string textArea)
        {
            HttpClient client = new();
            string text = await client.GetStringAsync($"https://loripsum.net/api/{paragraphsCount}/short");
            if (textArea == "textArea1")
            {
                _text1 = WebUtility.HtmlDecode(text);
                return Json(_text1);
            }

            _text2 = WebUtility.HtmlDecode(text);
            return Json(_text2);
        }

        #endregion
    }
}
