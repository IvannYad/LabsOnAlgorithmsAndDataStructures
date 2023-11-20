using Laba.DataStructures;
using Laba.DataStructures.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Microsoft.JSInterop;
using Laba.Services.ServicesLab9;
using System.Net;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Laba.Controllers
{
    public class Lab10Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region API_Calls

        public async Task<IActionResult> GenerateText(int paragraphsCount, string textArea, [FromServices] string[] texts)
        {
            HttpClient client = new();
            string text = await client.GetStringAsync($"https://loripsum.net/api/{paragraphsCount}/short");
            if (textArea == "textArea1")
            {
                texts[0] = text;
                return Json(text);
            }

            texts[1] = text;
            return Json(text);
        }

        public IActionResult FindWord([FromServices] string[] texts)
        {
            var wordsWithCount = Regex.Replace(texts[0]!, "<.*?>", "")?.Split(" ", StringSplitOptions.RemoveEmptyEntries)?
                .GroupBy(p => p).Select(group => new KeyValuePair<string, int>(group.Key, group.Count()));
            string? mostFrequentWord = wordsWithCount?.MaxBy(pair => pair.Value).Key;
            texts[0] = texts[0]!.Replace($" {mostFrequentWord!} ", $"<b style='color: red;'> {mostFrequentWord} </b>");
            return Json(new { word = mostFrequentWord, newText = texts[0] });
        }

        public IActionResult FindPrefix(string word)
        {
            int prefix = 0;
            for (int i = 1; i < word.Length; i++)
            {
                var tempWord = word[..(i + 1)];
                for (int j = 0; j < i; j++)
                {
                    string prefWord = tempWord[..(j + 1)];
                    string sufWord = tempWord[^(j + 1)..];
                    if (prefWord == sufWord)
                    {
                        prefix = j + 1;
                    }
                }
            }

            return Json(prefix);
        }

        #endregion
    }
}
