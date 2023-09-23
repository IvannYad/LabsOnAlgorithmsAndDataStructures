using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Laba.Models.VM
{
    public class Lab1VM
    {
        [Required]
        public string ArrayString { get; set; }
        [Required]
        public string[] Array;
        public List<SortingAlgorithmStepResultModelLab1> SortingAlgorithmStepsResult { get; set; }
        public int TimeToSortInMiliseconds { get; set; }

        public int ComparesCount;
    }
}
