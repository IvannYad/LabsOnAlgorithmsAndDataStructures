using System.ComponentModel.DataAnnotations;

namespace Laba.Models
{
    public class SortingAlgorithmStepResultModelLab3
    {
        [Required]
        public double[] Array { get; set; }

        public int PivotIndex { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
    }
}
