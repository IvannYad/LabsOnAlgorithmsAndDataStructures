using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.ComponentModel.DataAnnotations;

namespace Laba.Models
{
    public class SortingAlgorithResultModel<T>
    {
        [Required]
        public IEnumerable<T> Array { get; set; }

        public int Index1ToSwap { get; set; }
        public int Index2ToSwap { get; set; }
    }
}
