using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.ComponentModel.DataAnnotations;

namespace Laba.Models
{
    public class SortingAlgorithmStepResultModelLab1
    {
        [Required]
        public string[] Array { get; set; }

        public int LastIndexSorted { get; set; }
        public int Index1ToSwap { get; set; }
        public int Index2ToSwap { get; set; }
    }
}
