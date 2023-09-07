using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Laba.Models
{
    public class Laba1VM
    {
        [Required]
        public string ArrayString { get; set; }
        [Required]
        public string Type { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Types { get; set; }
        public Type[] Array { get; set; }
        public IEnumerable<SortingAlgorithResultModel<string>> SortingAlgorithmStepsResult { get; set; }
    }
}
