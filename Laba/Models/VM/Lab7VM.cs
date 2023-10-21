using Laba.DataStructures;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Laba.Models.VM
{
    public class Lab7VM
    {
        public PriorityQueue Queue { get; set; }

        public double? MinElement { get; set; }
        public double? MaxElement { get; set; }
        [Display(Name = "Priority")]
        public int? PriorityToEnqueue { get; set; }
        [Display(Name = "Value")]
        public double? ValueToEnqueue { get; set; }
        public double? DequeueResult { get; set; }
        public double? PeekResult { get; set; }
        [Display(Name = "Value")]
        
        public double? ElementByIndex { get; set; }
        public int? IndexInput { get; set; }
        
        public int? Index { get; set; }
        public double? ElementInput { get; set; }
    }
}
