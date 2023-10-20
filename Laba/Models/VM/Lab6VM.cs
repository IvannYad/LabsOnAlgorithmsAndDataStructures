using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Laba.Models.VM
{
    public class Lab6VM
    {
        [Required]
        public string NumberOfElementsString { get; set; }
        public int[] NumberOfElements { get; set; }
        [Required]
        [Range(1, 1000)]
        public int LowerBound { get; set; }
        [Required]
        [Range(1, 1000)]
        public int UpperBound { get; set; }
        
        public bool IsDataPopulated { get; set; }
        
        public double[] SelectionSortTimes { get; set; }
        public double[] ShellSortTimes { get; set; }
        public double[] QuickSortTimes { get; set; }
        public double[] MergeSortTimes { get; set; }
        public double[] CountSortTimes { get; set; }
    }
}
