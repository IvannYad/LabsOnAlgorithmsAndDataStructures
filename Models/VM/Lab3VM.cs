using System.ComponentModel.DataAnnotations;

namespace Laba.Models.VM
{
    public class Lab3VM
    {
        [Required]
        public string ArrayString { get; set; }
        [Required]
        public int[] Matrix;
        public List<SortingAlgorithmStepResultModelLab3> SortingAlgorithmStepsResult { get; set; }
        public int TimeToSortInMiliseconds { get; set; }

        public int ComparesCount { get; set; }
    }
}
