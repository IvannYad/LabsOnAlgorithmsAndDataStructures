using System.ComponentModel.DataAnnotations;

namespace Laba.Models
{
    public class SortingAlgorithmStepResultModelLab5
    {
        [Required]
        public double[] Array { get; set; }

        public int CurrentIndex { get; set; }
    }
}
