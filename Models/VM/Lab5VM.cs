using System.ComponentModel.DataAnnotations;

namespace Laba.Models.VM
{
    public class Lab5VM
    {
        [Required]
        public string ArrayString { get; set; }
        [Required]
        public int[] Array;
        public (double, int)[] ArrayWithIndexes { get; set; }
        public (double, int)[] ArrayWithAddedIndexes { get; set; }
        public List<SortingAlgorithmStepResultModelLab5> SortingAlgorithmStepsResult { get; set; }
        public int TimeToSortInTicks { get; set; }

        public int ComparesCount { get; set; }
    }
}
