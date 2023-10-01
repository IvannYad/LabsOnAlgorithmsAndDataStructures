using System.ComponentModel.DataAnnotations;

namespace Laba.Models.VM
{
    public class Lab4VM
    {
        [Required]
        public string ArrayString { get; set; }
        [Required]
        public (string, long)[] Array;
        public List<SortingAlgorithmStepResultModelLab4> SortingAlgorithmStepsResult { get; set; }
        public double Average { get; set; }
        public int TimeToSortInMiliseconds { get; set; }

        public int ComparesCount { get; set; }
    }
}
