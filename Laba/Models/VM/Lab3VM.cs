using System.ComponentModel.DataAnnotations;

namespace Laba.Models.VM
{
    public class Lab3VM
    {
        [Required]
        public string ArrayString { get; set; }
        [Required]
        public int[] Array;
        public List<SortingAlgorithmStepResultModelLab3> SortingAlgorithmStepsResult { get; set; }
        public int TimeToSortInTicks { get; set; }

        public int ComparesCount { get; set; }
    }
}
