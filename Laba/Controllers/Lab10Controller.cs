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

        public IActionResult FindMostFrequentWord([FromServices] string[] texts)
        {
            var wordsWithCount = Regex.Replace(texts[0]!, "<.*?>", "")?.Split(" ", StringSplitOptions.RemoveEmptyEntries)?
                .GroupBy(p => p).Select(group => new KeyValuePair<string, int>(group.Key, group.Count()));
            string? mostFrequentWord = wordsWithCount?.MaxBy(pair => pair.Value).Key;
            texts[0] = texts[0]!.Replace($" {mostFrequentWord!} ", $"<b style='color: red;'> {mostFrequentWord} </b>");
            return Json(new { word = mostFrequentWord, newText = texts[0] });
        }

        public IActionResult FindPrefix(string word, [FromServices] List<int> prefixFunc)
        {
            prefixFunc.Clear();
            prefixFunc.Add(0);
            for (int i = 1; i < word.Length; i++)
            {
                int prefix = 0;
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

                prefixFunc.Add(prefix);
            }

            return Json($"[{string.Join(" ", prefixFunc.Select(s => $"<b>{s}</b>"))}]");
        }

        public IActionResult FindWordInText(string word, [FromServices] string[] texts, [FromServices] List<int> prefixFunc)
        {
            var plaintext = Regex.Replace(texts[1]!, "<.*?>", "").Replace("\n", "");
            int m = word.Length; // m - length of word.
            int n = plaintext.Length; // n - length of text.
            int i = 0;
            int j = 0;
            while (i < n)
            {
                if (plaintext[i] == word[j])
                {
                    i++;
                    j++;
                    if (j == m)
                    {
                        // Word is found.
                        i = i - m;
                        break;
                    }

                }
                else
                {
                    // If we on first character in word.
                    if (j == 0)
                    {
                        i++;
                        if (i == n)
                        {
                            // End is reached.
                            i = -1;
                            break;
                        }
                    }
                    else
                        j = prefixFunc[j - 1];
                }
            }

            int indexToReturn = i;
            bool insideHTML_Tag = false;
            for (int k = 0; k < i; k++)
            {
                if (texts[1][k] == '<')
                {
                    insideHTML_Tag = true;
                }

                if (insideHTML_Tag)
                {
                    i++;
                }

                if (texts[1][k] == '>')
                {
                    insideHTML_Tag = false;
                }
            }

            var textToReturn = i != -1 ? texts[1].Insert(i, "<b style='color: green;'>").Insert(i + m + 25, "</b>") : texts[1];
            return Json(new { index = indexToReturn, text =  textToReturn});
        }

        #endregion
    }
}
